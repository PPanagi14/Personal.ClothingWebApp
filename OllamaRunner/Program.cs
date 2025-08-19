using System;
using System.Threading.Tasks;
using OllamaSharp;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new OllamaApiClient(new Uri("http://localhost:11434"));
        client.SelectedModel = "llama3.1:latest";

        string prompt = args.Length > 0
            ? string.Join(" ", args)
            : "Hello Ollama!";

        await foreach (var token in client.GenerateAsync(prompt))
            Console.Write(token.Response);

        Console.WriteLine();
    }
}
