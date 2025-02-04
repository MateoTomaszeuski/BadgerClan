using BadgerClan.MAUI.Models;
using BadgerClan.MAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BadgerClan.MAUI.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string activeMode;

    [ObservableProperty]
    private ObservableCollection<ApiInfo> selectedApis;

    [ObservableProperty]
    private string newApiName;

    [ObservableProperty]
    private string newApiUrl;

    [ObservableProperty]
    private ObservableCollection<ApiInfo> apiList = new();

    private readonly IApiService apiService;

    public MainPageViewModel(IApiService apiService)
    {
        this.apiService = apiService;
    }

    [RelayCommand]
    public async Task ActivateRunAndGun()
    {
        foreach (var api in ApiList)
        {
            await apiService.ActivateRunAndGun(api.ApiUrl);
        }
    }

    [RelayCommand]
    public async Task ActivateDoNothing()
    {
        foreach (var api in ApiList)
        {
            await apiService.ActivateDoNothing(api.ApiUrl);
        }
    }

    [RelayCommand]
    public async Task ActivateRunAway()
    {
        foreach (var api in ApiList)
        {
            await apiService.ActivateRunAway(api.ApiUrl);
        }
    }

    [RelayCommand]
    public async Task ActivateReGroup()
    {
        foreach (var api in ApiList)
        {
            await apiService.ActivateReGroup(api.ApiUrl);
        }

    }

    [RelayCommand]
    public async Task AddApi()
    {
        ApiList.Add(new() { ApiName = NewApiName, ApiUrl = NewApiUrl });
        NewApiName = "";
        NewApiUrl = "";
    }
}
