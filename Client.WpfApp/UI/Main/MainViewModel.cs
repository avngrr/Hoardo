using System.Windows.Input;
using Client.WpfApp.Services;
using Client.WpfApp.UI.Base;
using Client.WpfApp.UI.Home;
using Client.WpfApp.UI.Movies;
using Client.WpfApp.UI.TvShows;

namespace Client.WpfApp.UI.Main;
public class MainViewModel : ViewModelBase
{
    public readonly INavigationService _navigationService;
    public ViewModelBase CurrentViewModel => _navigationService.CurrentViewModel;
    public ICommand NavigateHome { get; private set; }
    public ICommand NavigateMovies { get; private set; }
    public ICommand NavigateTvShows { get; private set; }
    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _navigationService.CurrentViewModel = new HomeViewModel();
        NavigateHome = _navigationService.NavigateCommand<HomeViewModel>();
        NavigateMovies = _navigationService.NavigateCommand<MoviesViewModel>();
        NavigateTvShows = _navigationService.NavigateCommand<TvShowsViewModel>();
    }
    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
