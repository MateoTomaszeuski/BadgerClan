using BadgerClan.Api.Moves;
using BadgerClan.Logic;
using BadgerClan.Logic.Bot;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/RunAndGun", (HttpContext context) =>
{
    app.Logger.LogInformation("Received Run and Gun Activation Request");
    Strategies.Strategy = "runandgun";
});


app.MapGet("/DoNothing", (HttpContext context) =>
{
    app.Logger.LogInformation("Received Do Nothing Activation Request");
    Strategies.Strategy = "";
});

app.MapGet("/RunAway", (HttpContext context) =>
{
    app.Logger.LogInformation("Received Run Away Activation Request");
    Strategies.Strategy = "runaway";
});
app.MapGet("/ReGroup", (HttpContext context) =>
{
    app.Logger.LogInformation("Received Run Away Activation Request");
    Strategies.Strategy = "regroup";
});

app.MapGet("/",(HttpContext context) => "Hello World");

app.MapPost("/", (MoveRequest request) =>
{
    app.Logger.LogInformation("Received move request for game {gameId} turn {turnNumber}", request.GameId, request.TurnNumber);
    var moves = new List<Move>();

    switch (Strategies.Strategy)
    {
        case "runandgun":
            Strategies.RunAndGun(request, moves);
            app.Logger.LogInformation("Run and Gun strategy returned.");
            break;
        case "runaway":
            Strategies.RunAway(request, moves);
            app.Logger.LogInformation("Run Away strategy returned.");
            break;
        case "regroup":
            Strategies.ReGroup(request, moves);
            app.Logger.LogInformation("ReGroup strategy returned.");
            break;
        default:
            app.Logger.LogInformation("Do nothing strategy returned.");
            moves = new List<Move>();
            break;
    }
    return new MoveResponse(moves);

});

app.Run();

