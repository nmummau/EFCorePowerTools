using System.Windows.Input;

namespace EFCorePowerTools.Contracts.ViewModels;

public interface IObjectTreeSelectableViewModel
{
    public bool? IsSelected { get; }

    public ICommand SetSelectedCommand { get; }
}