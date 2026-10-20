using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EFCorePowerTools.Common.Models;
using EFCorePowerTools.Contracts.EventArgs;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IModelingOptionsViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public ICommand OkCommand { get; }

    public ICommand CancelCommand { get; }

    public ModelingOptionsModel Model { get; }

    public IReadOnlyList<string> GenerationModeList { get; }

    public string Title { get; }

    public bool MayIncludeConnectionString { get; }

    public ObservableCollection<TemplateTypeItem> TemplateTypeList { get; }

    public int SelectedTemplateType { get; set; }

    public void ApplyPresets(ModelingOptionsModel presets);
}