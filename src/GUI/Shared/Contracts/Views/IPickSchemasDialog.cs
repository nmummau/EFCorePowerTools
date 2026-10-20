using System.Collections.Generic;
using RevEng.Common;

namespace EFCorePowerTools.Contracts.Views;

public interface IPickSchemasDialog : IDialog<SchemaInfo[]>
{
    public void AddSchemas(IEnumerable<SchemaInfo> schemas);
}