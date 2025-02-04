using System.Collections.ObjectModel;
using System.Net.Http;

namespace BadgerClan.MAUI.Services;

public class ApiService(): IApiService
{
    public async Task<string> ActivateRunAndGun(string api)
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(api) };


        var response = await client.GetAsync("/RunAndGun");
        if (response.IsSuccessStatusCode)
            return "Run and Gun";
        else return "";
    }

    public async Task<string> ActivateDoNothing(string api)
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(api) };

        var response = await client.GetAsync("/DoNothing");
        if (response.IsSuccessStatusCode)
            return "Do Nothing";
        else return "";
    }

    public async Task<string> ActivateRunAway(string api)
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(api) };
        var response = await client.GetAsync("/RunAway");
        if (response.IsSuccessStatusCode)
            return "RunAway";
        else return "";
    }

    public async Task<string> ActivateReGroup(string api)
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(api) };


        var response = await client.GetAsync("/ReGroup");
        if (response.IsSuccessStatusCode)
            return "ReGroup";
        else return "";
    }

}
