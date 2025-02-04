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
    private string selectedApi;

    [ObservableProperty]
    private string newApiName;

    [ObservableProperty]
    private string newApiUrl;

    [ObservableProperty]
    private ObservableCollection<(string ApiName,string ApiUrl)> apiList;
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
    public async Task AddApi()
    {
        ApiList.Add((NewApiName, NewApiUrl));
        NewApiName = "";
        NewApiUrl = "";
    }
}
