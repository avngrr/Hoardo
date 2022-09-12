using System;
using System.Collections;
using System.Windows.Input;
using Client.WpfApp.Commands;
using Client.WpfApp.UI.Base;

namespace Client.WpfApp.Services;
public class NavigationService : INavigationService
{
    public event Action CurrentViewModelChanged;
    private ViewModelBase _currentViewModel;
    private Hashtable _navigationCommands;
    private readonly IServiceProvider _provider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _provider = serviceProvider;
    }

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }
    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
    public NavigateCommand<T> NavigateCommand<T>() where T : ViewModelBase
    {
        if (_navigationCommands == null) _navigationCommands = new Hashtable();
        var type = typeof(T).Name;
        if (!_navigationCommands.ContainsKey(type))
        {
            NavigateCommand<T> command = (NavigateCommand<T>)_provider.GetService(typeof(NavigateCommand<T>));
            _navigationCommands.Add(type, command);
        }
        return _navigationCommands[type] as NavigateCommand<T>;
    }

    public ICommand NavigateCommand(ViewModelBase v)
    {
        Type navType = typeof(NavigateCommand<>);
        var command = navType.MakeGenericType(v.GetType());
        return (ICommand)Activator.CreateInstance(command);
    }
}
