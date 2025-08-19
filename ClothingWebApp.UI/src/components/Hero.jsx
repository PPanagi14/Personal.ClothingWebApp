import { MessageCircle, Sparkles, Zap } from "lucide-react";
import { Button } from  "@mui/material";;

export const Hero = () => {
  const scrollToChat = () => {
    const chatSection = document.getElementById('chat-section');
    if (chatSection) {
      chatSection.scrollIntoView({ behavior: 'smooth' });
    }
  };

  return (
    <div className="relative min-h-screen flex items-center justify-center bg-gradient-background overflow-hidden">
      {/* Background Effects */}
      <div className="absolute inset-0">
        <div className="absolute top-1/4 left-1/4 w-64 h-64 bg-primary/20 rounded-full blur-3xl animate-pulse"></div>
        <div className="absolute bottom-1/4 right-1/4 w-80 h-80 bg-primary-glow/20 rounded-full blur-3xl animate-pulse [animation-delay:1s]"></div>
      </div>

      <div className="relative z-10 text-center px-4 max-w-4xl mx-auto">
        {/* Hero Content */}
        <div className="animate-fade-in">
          

          <h1 className="text-6xl md:text-8xl font-bold mb-6 bg-gradient-to-r from-foreground to-foreground/70 bg-clip-text text-transparent leading-tight">
            Chat with Intelligence
            
          </h1>

          <p className="text-xl md:text-2xl text-muted-foreground mb-8 max-w-2xl mx-auto leading-relaxed">
            Experience the future of conversation with our advanced AI assistant. 
            Get instant answers, creative help, and intelligent solutions.
          </p>

          <div className="flex flex-col sm:flex-row gap-4 justify-center items-center mb-12">
            <Button 
              onClick={scrollToChat}
              size="lg" 
              className="bg-gradient-primary hover:shadow-glow transition-all duration-300 group"
            >
              <MessageCircle className="w-5 h-5 mr-2 group-hover:animate-bounce" />
              Start Chatting
            </Button>
            <Button 
              variant="outline" 
              size="lg"
              className="border-primary/20 hover:border-primary/40 hover:bg-primary/5"
            >
              <Zap className="w-5 h-5 mr-2" />
              Learn More
            </Button>
          </div>

          {/* Features */}
          <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mt-16">
            <div className="bg-chat-background/50 backdrop-blur-sm border border-chat-border rounded-2xl p-6 hover:border-primary/30 transition-colors animate-fade-in [animation-delay:0.2s]">
             
              <h3 className="text-lg font-semibold mb-2 text-foreground">Natural Conversations</h3>
              <p className="text-muted-foreground text-sm">
                Chat naturally with our AI that understands context and provides human-like responses.
              </p>
            </div>

            <div className="bg-chat-background/50 backdrop-blur-sm border border-chat-border rounded-2xl p-6 hover:border-primary/30 transition-colors animate-fade-in [animation-delay:0.4s]">
              <div className="w-12 h-12 bg-gradient-primary rounded-xl flex items-center justify-center mb-4 mx-auto">
                <Zap className="w-6 h-6 text-primary-foreground" />
              </div>
              <h3 className="text-lg font-semibold mb-2 text-foreground">Lightning Fast</h3>
              <p className="text-muted-foreground text-sm">
                Get instant responses with our optimized AI engine that thinks and responds in real-time.
              </p>
            </div>

            <div className="bg-chat-background/50 backdrop-blur-sm border border-chat-border rounded-2xl p-6 hover:border-primary/30 transition-colors animate-fade-in [animation-delay:0.6s]">
              <div className="w-12 h-12 bg-gradient-primary rounded-xl flex items-center justify-center mb-4 mx-auto">
                <Sparkles className="w-6 h-6 text-primary-foreground" />
              </div>
              <h3 className="text-lg font-semibold mb-2 text-foreground">Creative & Smart</h3>
              <p className="text-muted-foreground text-sm">
                From creative writing to problem-solving, our AI adapts to help with any task.
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};