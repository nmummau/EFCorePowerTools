using System;
using System.Windows.Input;
using EFCorePowerTools.Common.Models;
using EFCorePowerTools.Contracts.EventArgs;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IAdvancedModelingOptionsViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public ICommand OkCommand { get; }

    public ICommand CancelCommand { get; }

    public ModelingOptionsModel Model { get; }

    public void ApplyPresets(ModelingOptionsModel presets);
}