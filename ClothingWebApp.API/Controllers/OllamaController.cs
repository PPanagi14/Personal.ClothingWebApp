using Microsoft.AspNetCore.Mvc;
using OllamaSharp;
using System.Text;

[ApiController]
[Route("api/ollama")]
public class OllamaController : ControllerBase
{
    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] ChatRequest req)
    {
        var client = new OllamaApiClient(new Uri("http://localhost:11434"));
        client.SelectedModel = "llama3.1:latest";
        var result = client.GenerateAsync(req.Prompt);

        var sb = new StringBuilder();
        await foreach (var token in result)
            sb.Append(token.Response);

        return Ok(new { response = sb.ToString() });
    }
}

public class ChatRequest
{
    public string Prompt { get; set; }
}
