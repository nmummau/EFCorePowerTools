using System;
using System.Collections.Generic;
using EFCorePowerTools.Common.Models;
using EFCorePowerTools.Contracts.EventArgs;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface ICompareOptionsViewModel : IViewModel
{
    public event EventHandler<CloseRequestedEventArgs> CloseRequested;

    public void AddDatabaseConnections(IEnumerable<DatabaseConnectionModel> connections);

    public void AddContextTypes(IEnumerable<string> contextTypes);

    public (DatabaseConnectionModel Connection, IEnumerable<string> ContextTypes) GetSelection();
}