using System.Collections.Generic;
using EFCorePowerTools.Common.Models;

namespace EFCorePowerTools.Contracts.Views;

public interface ICompareOptionsDialog : IDialog<(DatabaseConnectionModel Connection, IEnumerable<string> ContextTypes)>
{
    public void AddConnections(IEnumerable<DatabaseConnectionModel> connections);

    public void AddContextTypes(IEnumerable<string> contextTypes);
}