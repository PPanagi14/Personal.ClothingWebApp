import { useState, useRef, useEffect } from "react";
import { Send, Sparkles } from "lucide-react";
import { Button } from  "@mui/material";
import { TextField } from  "@mui/material";
import { ChatMessage } from "./ChatMessage";
import { askOllama } from "../auth/authService";



export const ChatBot = () => {
  const [messages, setMessages] = useState([
    {
      id: "1",
      text: "👋 Hi! I'm your AI assistant. Ask me anything!",
      isUser: false,
      timestamp: new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }),
    },
  ]);
  const [inputValue, setInputValue] = useState("");
  const [isTyping, setIsTyping] = useState(false);
  const messagesEndRef = useRef(null);

  const scrollToBottom = () => {
    messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
  };

  useEffect(() => {
    scrollToBottom();
  }, [messages]);



  const handleKeyPress = (e) => {
    if (e.key === "Enter" && !e.shiftKey) {
      e.preventDefault();
      handleSendMessage();
    }
  };
  
  const handleSendMessage = async () => {
  if (!inputValue.trim()) return;

  const userMessage = {
      id: Date.now().toString(),
      text: inputValue,
      isUser: true,
      timestamp: new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }),
    };
  setMessages(prev => [...prev, userMessage]);
  setInputValue("");
  setIsTyping(true);

  try {
    const res= await askOllama(userMessage.text)
    debugger
    if (!res.status==200) throw new Error("Network error");

    const data = await res.data;
    const botResponse = {
      id: Date.now().toString(),
      text: data.response,
      isUser: false,
      timestamp: new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
    };
    setMessages(prev => [...prev, botResponse]);
  } catch (err) {
    console.error(err);
    setMessages(prev => [...prev, {
      id: "error",
      text: "Something went wrong 🤖",
      isUser: false,
      timestamp: new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
    }]);
  } finally {
    setIsTyping(false);
  }
};



  return (
    <div className="w-full max-w-2xl mx-auto h-[600px] bg-gradient-chat backdrop-blur-lg border border-chat-border rounded-3xl shadow-chat overflow-hidden animate-fade-in">
      {/* Header */}
      <div className="bg-chat-background/50 backdrop-blur-sm border-b border-chat-border p-4">
        <div className="flex items-center gap-3">
          <div className="w-10 h-10 rounded-full bg-gradient-primary flex items-center justify-center animate-glow">
            <Sparkles className="w-5 h-5 text-primary-foreground" />
          </div>
          <div>
            <h3 className="font-semibold text-foreground">AI Assistant</h3>
            <p className="text-sm text-muted-foreground">
              {isTyping ? "Typing..." : "Online"}
            </p>
          </div>
        </div>
      </div>

      {/* Messages */}
      <div className="flex-1 overflow-y-auto p-4 space-y-4 h-[440px]">
        {messages.map((message) => (
          <ChatMessage
            key={message.id}
            message={message.text}
            isUser={message.isUser}
            timestamp={message.timestamp}
          />
        ))}
        {isTyping && (
          <div className="flex gap-3 animate-slide-up">
            <div className="flex-shrink-0 w-8 h-8 rounded-full bg-primary flex items-center justify-center">
              <Sparkles className="w-4 h-4 text-primary-foreground" />
            </div>
            <div className="bg-chat-bot px-4 py-3 rounded-2xl">
              <div className="flex gap-1">
                <div className="w-2 h-2 bg-muted-foreground rounded-full animate-bounce [animation-delay:0ms]"></div>
                <div className="w-2 h-2 bg-muted-foreground rounded-full animate-bounce [animation-delay:150ms]"></div>
                <div className="w-2 h-2 bg-muted-foreground rounded-full animate-bounce [animation-delay:300ms]"></div>
              </div>
            </div>
          </div>
        )}
        <div ref={messagesEndRef} />
      </div>

      {/* Input */}
      <div className="p-4 bg-chat-background/50 backdrop-blur-sm border-t border-chat-border">
        <div className="flex gap-2">
          <TextField
            value={inputValue}
            onChange={(e) => setInputValue(e.target.value)}
            onClick={handleKeyPress}
            placeholder="Type your message..."
            className="flex-1 bg-chat-bot border-chat-border focus:border-primary focus:ring-primary/20"
            disabled={isTyping}
          />
          <Button
            onClick={handleSendMessage}
            disabled={!inputValue.trim() || isTyping}
            size="icon"
            className="bg-gradient-primary hover:shadow-glow transition-all duration-300"
          >
            <Send className="w-4 h-4" />
          </Button>
        </div>
      </div>
    </div>
  );
};