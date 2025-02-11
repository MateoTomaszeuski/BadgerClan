using BadgerClan.MAUI.Models;

namespace BadgerClan.MAUI.Services;

public interface IApiService
{
    Task<string> ActivateRunAndGun(ApiInfo api);
    Task<string> ActivateDoNothing(ApiInfo api);
    Task<string> ActivateRunAway(ApiInfo api);
    Task<string> ActivateReGroup(ApiInfo api);
}
