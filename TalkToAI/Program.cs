using OpenAI.GPT3.Extensions;

// const string apiKey = "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";
var apiKey = Environment.GetEnvironmentVariable("OPEN_API_KEY");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenAIService(settings => { settings.ApiKey = apiKey; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();