using System.Collections.ObjectModel;
using RevEng.Common;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IObjectTreeRootItemViewModel : IObjectTreeSelectableViewModel, IViewModel
{
    public bool IsVisible { get; }

    public ObservableCollection<ISchemaInformationViewModel> Schemas { get; }

    public ObjectTypeIcon ObjectTypeIcon { get; }

    public ObjectType ObjectType { get; set; }
}