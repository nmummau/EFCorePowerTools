using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EFCorePowerTools.Common.Models;
using EFCorePowerTools.Contracts.EventArgs;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IPickConfigViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public ICommand LoadedCommand { get; }

    public ICommand OkCommand { get; }

    public ICommand CancelCommand { get; }

    public ObservableCollection<ConfigModel> Configurations { get; }

    public ConfigModel SelectedConfiguration { get; set; }
}