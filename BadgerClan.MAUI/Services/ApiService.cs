using System.Collections.ObjectModel;
using System.Net.Http;

namespace BadgerClan.MAUI.Services;

public class ApiService(IHttpClientFactory factory) : IApiService
{
    public string GetClientUri()
    {
        HttpClient client = factory.CreateClient("ControllerApi");

        return client.BaseAddress.OriginalString;
    }
    public async Task<string> ActivateRunAndGun()
    {
        HttpClient client = factory.CreateClient("ControllerApi");

        var response = await client.GetAsync("/RunAndGun");
        if (response.IsSuccessStatusCode)
            return "Run and Gun";
        else return "";
    }

    public async Task<string> ActivateDoNothing()
    {
        HttpClient client = factory.CreateClient("ControllerApi");

        var response = await client.GetAsync("/DoNothing");
        if (response.IsSuccessStatusCode)
            return "Do Nothing";
        else return "";
    }

    public async Task<string> ActivateRunAway()
    {
        HttpClient client = factory.CreateClient("ControllerApi");

        var response = await client.GetAsync("/RunAway");
        if (response.IsSuccessStatusCode)
            return "RunAway";
        else return "";
    }

    public async Task<string> ActivateReGroup()
    {
        HttpClient client = factory.CreateClient("ControllerApi");

        var response = await client.GetAsync("/RunAway");
        if (response.IsSuccessStatusCode)
            return "ReGroup";
        else return "";
    }

}
