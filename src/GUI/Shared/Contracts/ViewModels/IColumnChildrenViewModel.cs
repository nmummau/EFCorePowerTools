using System.Collections.ObjectModel;
using RevEng.Common;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IColumnChildrenViewModel : IObjectTreeEditableViewModel, IObjectTreeSelectableViewModel, IViewModel
{
    public string Schema { get; set; }

    public bool HasPrimaryKey { get; }

    public ObjectType ObjectType { get; set; }

    public ObjectTypeIcon ObjectTypeIcon { get; }

    public ObservableCollection<IColumnInformationViewModel> Columns { get; }

    public bool IsVisible { get; set; }

    public string ModelDisplayName { get; set; }
}