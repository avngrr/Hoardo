using System;
using Client.WpfApp.Services;
using Client.WpfApp.UI.Base;

namespace Client.WpfApp.Commands;
public class NavigateCommand<TViewModel> : BaseCommand where TViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IServiceProvider _provider;

    public NavigateCommand(INavigationService navigationService, IServiceProvider serviceProvider)
    {
        _navigationService = navigationService;
        _provider = serviceProvider;
    }
    public override void Execute(object parameter)
    {

        _navigationService.CurrentViewModel = (TViewModel)_provider.GetService(typeof(TViewModel));
    }
}
