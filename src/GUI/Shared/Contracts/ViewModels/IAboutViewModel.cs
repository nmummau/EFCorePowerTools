using System;
using System.Windows.Input;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IAboutViewModel : IViewModel
{
    public event EventHandler CloseRequested;

    public ICommand LoadedCommand { get; }

    public ICommand OkCommand { get; }

    public ICommand OpenSourcesCommand { get; }

    public ICommand OpenMarketplaceCommand { get; }

    public string Version { get; }
}