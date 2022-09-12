using System;
using System.Windows.Input;
using Client.WpfApp.Commands;
using Client.WpfApp.UI.Base;

namespace Client.WpfApp.Services;
public interface INavigationService
{
    ViewModelBase CurrentViewModel { get; set; }

    event Action CurrentViewModelChanged;
    NavigateCommand<T> NavigateCommand<T>() where T : ViewModelBase;
    ICommand NavigateCommand(ViewModelBase v);
}
