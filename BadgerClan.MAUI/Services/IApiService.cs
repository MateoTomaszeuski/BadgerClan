namespace BadgerClan.MAUI.Services;

public interface IApiService
{
    Task<string> ActivateRunAndGun(string api);
    Task<string> ActivateDoNothing(string api);
    Task<string> ActivateRunAway(string api);
    Task<string> ActivateReGroup(string api);
}
