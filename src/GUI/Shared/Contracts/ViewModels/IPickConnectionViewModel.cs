using System;
using System.Windows.Input;
using EFCorePowerTools.Common.Models;
using EFCorePowerTools.Contracts.EventArgs;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IPickConnectionViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public ICommand OkCommand { get; }

    public ICommand CancelCommand { get; }

    public DatabaseConnectionModel DatabaseConnection { get; }
}