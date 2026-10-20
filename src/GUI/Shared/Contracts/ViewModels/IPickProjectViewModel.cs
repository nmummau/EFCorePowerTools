using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EFCorePowerTools.Contracts.EventArgs;
using EFCorePowerTools.Contracts.Models;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IPickProjectViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public ICommand LoadedCommand { get; }

    public ICommand OkCommand { get; }

    public ICommand CancelCommand { get; }

    public ObservableCollection<ProjectModel> Projects { get; }

    public ProjectModel SelectedProject { get; set; }
}