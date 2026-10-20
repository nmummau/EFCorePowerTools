using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EFCorePowerTools.Contracts.EventArgs;
using EFCorePowerTools.Handlers.Compare;
using EFCorePowerTools.ViewModels;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface ICompareResultViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public bool ShowDifferencesOnly { get; set; }

    public ICommand CloseCommand { get; }

    public ICommand SetVisibilityCommand { get; }

    public ObservableCollection<CompareLogItemViewModel> Logs { get; }

    public void AddComparisonResult(IEnumerable<CompareLogModel> logs);
}