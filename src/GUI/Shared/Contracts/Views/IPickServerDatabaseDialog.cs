using System.Collections.Generic;
using EFCorePowerTools.Common.Models;
using EFCorePowerTools.Contracts.EventArgs;
using EFCorePowerTools.Contracts.ViewModels;
using RevEng.Common;

namespace EFCorePowerTools.Contracts.Views;

public interface IPickServerDatabaseDialog : IDialog<(DatabaseConnectionModel Connection, CodeGenerationMode CodeGenerationMode, bool FilterSchemas, SchemaInfo[] Schemas, string UiHint, WizardEventArgs WizardArgs)>
{
    public void PublishConnections(IEnumerable<DatabaseConnectionModel> connections);

    public void PublishDefinitions(IEnumerable<DatabaseConnectionModel> definitions);

    public void PublishSchemas(IEnumerable<SchemaInfo> schemas);

    public void PublishCodeGenerationMode(CodeGenerationMode codeGenerationMode, IList<CodeGenerationItem> allowedVersions);

    public void PublishUiHint(string uiHint);

    public (DatabaseConnectionModel Connection, CodeGenerationMode CodeGenerationMode, bool FilterSchemas, SchemaInfo[] Schemas, string UiHint, WizardEventArgs WizardArgs) GetResults();
}