using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Client.Wpf.ViewModels;
public class MainViewModel : ViewModelBase
{
    private ViewModelBase _viewModel;
    private readonly IServiceProvider _serviceProvider;
    public ICommand NavCmd { get; private set; }
    public ViewModelBase CurrentView
    {
        get => _viewModel;
        set => SetProperty(ref _viewModel, value);
    }
    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        ChangeView(typeof(HomeViewModel));
        NavCmd = new RelayCommand<Type>(vm => ChangeView(vm));
    }
    private void ChangeView(object parameter)
    {
        _viewModel = (ViewModelBase)_serviceProvider.GetService((Type)parameter);
        OnPropertyChanged(nameof(CurrentView));
    }
}
