using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using SlackAPI;
using TalkToAI.Models;

namespace TalkToAI.Controllers;

[ApiController]
[Route("[controller]")]
public class SlackController : ControllerBase
{
    private readonly IOpenAIService _openAiService;
    private readonly ILogger<SlackController> _logger;

    public SlackController(IServiceProvider serviceProvider, ILogger<SlackController> logger)
    {
        _openAiService = serviceProvider.GetRequiredService<IOpenAIService>();
        _logger = logger;
    }

    [Route("callback")]
    [HttpPost]
    public IActionResult Callback([FromBody] dynamic json)
    {
        string jsonString = json.ToString();
        var data = JsonSerializer.Deserialize<SlackEventDto>(jsonString);
        
        if (data?.challenge is not null)
        {
            return Ok(new { data.challenge });
        }

        Task.Run(async () =>
        {
            var completionResult = _openAiService.Completions.CreateCompletionAsStream(new CompletionCreateRequest()
            {
                Prompt = data?.@event.text,
                Model = OpenAI.GPT3.ObjectModels.Models.TextDavinciV3,
                Temperature = 0.3F,
                MaxTokens = 4000
            });

            var botOauthToken = Environment.GetEnvironmentVariable("SLACK_BOT_AUTH_TOKEN");
            var client = new SlackTaskClient(botOauthToken);

            var text = string.Empty;
            await foreach (var completion in completionResult)
            {
                if (completion.Successful)
                {
                    text += completion.Choices.FirstOrDefault()?.Text;

                    if (text.StartsWith('\n'))
                    {
                        text = string.Empty;
                    }

                    if (!text.EndsWith('\n')) continue;

                    await client.PostMessageAsync(
                        data?.@event.channel,
                        text
                    );

                    text = string.Empty;
                }
                else
                {
                    if (completion.Error == null)
                    {
                        throw new Exception("Unknown Error");
                    }

                    _logger.LogError($"{completion.Error.Code}: {completion.Error.Message}");
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                await client.PostMessageAsync(
                    data?.@event.channel,
                    text
                );
            }
        });

        return Ok();
    }
}