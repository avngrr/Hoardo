﻿using System;
using System.Windows.Input;

namespace Client.WpfApp.Commands;
public abstract class BaseCommand : ICommand
{
    public event EventHandler CanExecuteChanged;
    public virtual bool CanExecute(object parameter) => true;
    public abstract void Execute(object parameter);
    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, new EventArgs());
    }
}
