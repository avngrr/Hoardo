using System;
using System.ComponentModel;

namespace Client.WpfApp.UI.Base;
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public static explicit operator ViewModelBase(Type v)
    {
        throw new NotImplementedException();
    }
}
