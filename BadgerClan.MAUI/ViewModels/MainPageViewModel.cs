using BadgerClan.MAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BadgerClan.MAUI.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string activeMode;

    [ObservableProperty]
    private string selectedApi;

    [ObservableProperty]
    private string newApiName;

    [ObservableProperty]
    private string newApiUrl;

    [ObservableProperty]
    private ObservableCollection<(string,string)> apiList;
    private readonly IApiService apiService;

    public MainPageViewModel(IApiService apiService)
    {
        ActiveMode = "Do Nothing";
        selectedApi = "AzureApi1";
        this.apiService = apiService;
    }

    [RelayCommand]
    public async Task ActivateRunAndGun()
    {
        ActiveMode = await apiService.ActivateRunAndGun(SelectedApi);
    }
    [RelayCommand]
    public async Task ActivateDoNothing()
    {
        ActiveMode = await apiService.ActivateDoNothing(SelectedApi);
    }
    [RelayCommand]
    public async Task ActivateRunAway()
    {
        ActiveMode = await apiService.ActivateRunAway(SelectedApi);
    }
    [RelayCommand]
    public async Task ActivateReGroup()
    {
        ActiveMode = await apiService.ActivateReGroup(SelectedApi);
    }
    [RelayCommand]
    public async Task ActivateAzureApi1()
    {
        SelectedApi = "AzureApi1";
    }
    [RelayCommand]
    public async Task ActivateAzureApi2()
    {
        SelectedApi = "AzureApi2";
    }
    [RelayCommand]
    public async Task ActivateLocalApi()
    {
        SelectedApi = "LocalApi";
    }
}
