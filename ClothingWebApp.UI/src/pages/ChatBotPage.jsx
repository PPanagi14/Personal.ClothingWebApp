import {Hero}  from "../components/Hero";
import {ChatBot} from "../components/ChatBot";

const Index = () => {
  return (
    <div className="min-h-screen bg-gradient-background">
      {/* Hero Section */}
      <Hero />
      
      {/* Chat Section */}
      <section id="chat-section" className="py-20 px-4">
        <div className="max-w-6xl mx-auto text-center mb-12">
          <h2 className="text-4xl md:text-5xl font-bold mb-4 bg-gradient-primary bg-clip-text text-transparent">
            Try It Now
          </h2>
          <p className="text-xl text-muted-foreground max-w-2xl mx-auto">
            Start a conversation with our AI assistant and experience the magic of intelligent dialogue.
          </p>
        </div>
        
        <div className="flex justify-center">
          <ChatBot />
        </div>
      </section>
    </div>
  );
};

export default Index;