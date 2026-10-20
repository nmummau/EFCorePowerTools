using System.Collections.Generic;
using RevEng.Common;

namespace EFCorePowerTools.Contracts.Views;

public interface IPickTablesDialog : IDialog<PickTablesDialogResult>
{
    public IPickTablesDialog AddTables(IEnumerable<TableModel> tables, IEnumerable<Schema> customReplacers);

    public IPickTablesDialog PreselectTables(IEnumerable<SerializationTableModel> tables);

    public IPickTablesDialog SqliteToolboxInstall(bool installed);
}