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
    private ApiInfo selectedApi;

    [ObservableProperty]
    private string newApiName;

    [ObservableProperty]
    private string newApiUrl;

    [ObservableProperty]
    private ObservableCollection<ApiInfo> apiList = new();

    private readonly IApiService apiService;

    public MainPageViewModel(IApiService apiService)
    {
        ActiveMode = "Do Nothing";
        this.apiService = apiService;
    }

    [RelayCommand]
    public async Task ActivateRunAndGun()
    {
        ActiveMode = await apiService.ActivateRunAndGun(SelectedApi.ApiUrl);
    }
    [RelayCommand]
    public async Task ActivateDoNothing()
    {
        ActiveMode = await apiService.ActivateDoNothing(SelectedApi.ApiUrl);
    }
    [RelayCommand]
    public async Task ActivateRunAway()
    {
        ActiveMode = await apiService.ActivateRunAway(SelectedApi.ApiUrl);
    }
    [RelayCommand]
    public async Task ActivateReGroup()
    {
        ActiveMode = await apiService.ActivateReGroup(SelectedApi.ApiUrl);
    }

    [RelayCommand]
    public async Task AddApi()
    {
        ApiList.Add(new() { ApiName = NewApiName, ApiUrl = NewApiUrl });
        NewApiName = "";
        NewApiUrl = "";
    }
}
