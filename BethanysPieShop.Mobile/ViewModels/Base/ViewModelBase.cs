using BethanysPieShop.Mobile.Services.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BethanysPieShop.Mobile.ViewModels.Base;

public abstract partial class ViewModelBase : ObservableValidator, IViewModelBase
{
    public INavigationService NavigationService { get; }
    
    public IAsyncRelayCommand InitializeAsyncCommand { get; }
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsLoaded))]
    private bool _isLoading;
    
    public bool IsLoaded => !IsLoading;

    [RelayCommand]
    private async Task GoBack()
        => await NavigationService.GoBack();
    
    protected ViewModelBase(INavigationService navigationService)
    {
        NavigationService = navigationService;
        InitializeAsyncCommand = new AsyncRelayCommand(
            async () =>
            {
                IsLoading = true;
                await Loading(InitializeAsync);
                IsLoading = false;
            });
    }
    
    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
    
    protected async Task Loading(Func<Task> unitOfWork)
    {
        await unitOfWork();
    }
}