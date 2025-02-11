using BadgerClan.Logic;
using BadgerClan.Shared;
using BadgerClan.Shared.Moves;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Server;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCodeFirstGrpc();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000, o => o.Protocols = HttpProtocols.Http2); // gRPC
    options.ListenLocalhost(5001, o => o.Protocols = HttpProtocols.Http1); // REST
});
var app = builder.Build();

app.MapGrpcService<StrategyService>();

app.MapGet("/", () => "Mateo's gRPC API");

app.MapPost("/", (MoveRequest request) =>
{
    app.Logger.LogInformation("Received move request for game {gameId} turn {turnNumber}", request.GameId, request.TurnNumber);
    var moves = new List<Move>();

    switch (Strategies.currentStrat)
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

public class StrategyService : IStrategyService
{
    public Task<ConfirmationReply> ChangeStrat(StrategyRequest request, CallContext context = default)
    {
        Strategies.currentStrat = request.Strategy;
        return Task.FromResult(new ConfirmationReply { Message = request.Strategy });
    }
}