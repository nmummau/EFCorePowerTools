using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EFCorePowerTools.Contracts.EventArgs;
using RevEng.Common;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IPickSchemasViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public ICommand OkCommand { get; }

    public ICommand CancelCommand { get; }

    public ICommand AddCommand { get; }

    public ICommand RemoveCommand { get; }

    public ObservableCollection<SchemaInfo> Schemas { get; }
}