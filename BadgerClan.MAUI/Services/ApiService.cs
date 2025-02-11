using BadgerClan.MAUI.Models;
using BadgerClan.Shared;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace BadgerClan.MAUI.Services;

public class ApiService() : IApiService
{
    public async Task<string> ActivateRunAndGun(ApiInfo api)
    {
        if (api.ApiType == ApiType.gRPC)
        {
            var client = new StrategyService(api.ApiUrl);
            var reply = await client.service.ChangeStrat(new StrategyRequest { Strategy = "runandgun" });
            return reply.Message;
        }
        else
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(api.ApiUrl) };
            var response = await client.GetAsync("/RunAndGun");
            if (response.IsSuccessStatusCode)
                return "Run and Gun";
            else return "";
        }
    }

    public async Task<string> ActivateDoNothing(ApiInfo api)
    {
        if (api.ApiType == ApiType.gRPC)
        {
            var client = new StrategyService(api.ApiUrl);
            var reply = await client.service.ChangeStrat(new StrategyRequest { Strategy = "" });
            return reply.Message;
        }
        else
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(api.ApiUrl) };

            var response = await client.GetAsync("/DoNothing");
            if (response.IsSuccessStatusCode)
                return "Do Nothing";
            else return "";
        }
    }

    public async Task<string> ActivateRunAway(ApiInfo api)
    {
        if (api.ApiType == ApiType.gRPC)
        {
            var client = new StrategyService(api.ApiUrl);
            var reply = await client.service.ChangeStrat(new StrategyRequest { Strategy = "runaway" });
            return reply.Message;
        }
        else
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(api.ApiUrl) };
            var response = await client.GetAsync("/RunAway");
            if (response.IsSuccessStatusCode)
                return "RunAway";
            else return "";
        }
    }

    public async Task<string> ActivateReGroup(ApiInfo api)
    {
        if (api.ApiType == ApiType.gRPC)
        {
            var client = new StrategyService(api.ApiUrl);
            var reply = await client.service.ChangeStrat(new StrategyRequest { Strategy = "regrup" });
            return reply.Message;
        }
        else
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(api.ApiUrl) };
            var response = await client.GetAsync("/regroup");
            if (response.IsSuccessStatusCode)
                return "ReGroup";
            else return "";
        }
    }

}
