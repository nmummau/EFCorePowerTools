using System.Collections.ObjectModel;
using RevEng.Common;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface ISchemaInformationViewModel : IObjectTreeSelectableViewModel, IViewModel
{
    public string Name { get; set; }

    public bool IsVisible { get; }

    public ObservableCollection<ITableInformationViewModel> Objects { get; }

    public Schema ReplacingSchema { get; set; }
}