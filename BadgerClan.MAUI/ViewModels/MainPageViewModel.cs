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

    public IList<ApiInfo> SelectedApisAsApiInfo => SelectedApis.Cast<ApiInfo>().ToList();

    [ObservableProperty]
    private string newApiName;

    [ObservableProperty]
    private string newApiUrl;

    [ObservableProperty]
    private ApiType newApiType;

    public IEnumerable<ApiType> ApiTypes => Enum.GetValues(typeof(ApiType)).Cast<ApiType>();

    [ObservableProperty]
    private ObservableCollection<ApiInfo> apiList = new();

    [ObservableProperty]
    private ObservableCollection<object> selectedApis = new();

    private readonly IApiService apiService;

    public MainPageViewModel(IApiService apiService)
    {
        this.apiService = apiService;
    }

    [RelayCommand]
    public async Task ActivateRunAndGun()
    {
        foreach (var api in SelectedApisAsApiInfo)
        {
            await apiService.ActivateRunAndGun(api);
        }
        ActiveMode = "Run and Gun";
    }

    [RelayCommand]
    public async Task ActivateDoNothing()
    {
        foreach (var api in SelectedApisAsApiInfo)
        {
            await apiService.ActivateDoNothing(api);
        }
        ActiveMode = "Do Nothing";
    }

    [RelayCommand]
    public async Task ActivateRunAway()
    {
        foreach (var api in SelectedApisAsApiInfo)
        {
            await apiService.ActivateRunAway(api);
        }
        ActiveMode = "Run Away";
    }

    [RelayCommand]
    public async Task ActivateReGroup()
    {
        foreach (var api in SelectedApisAsApiInfo)
        {
            await apiService.ActivateReGroup(api);
        }

        ActiveMode = "Re Group";
    }

    [RelayCommand]
    public async Task AddApi()
    {
        ApiList.Add(new() { ApiName = NewApiName, ApiUrl = NewApiUrl, ApiType=newApiType });
        NewApiName = "";
        NewApiUrl = "";
        NewApiType = ApiType.REST;
    }
}
