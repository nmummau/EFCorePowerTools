using EFCorePowerTools.Common.Models;

namespace EFCorePowerTools.Contracts.Views;

public interface IAdvancedModelingOptionsDialog : IDialog<ModelingOptionsModel>
{
    public IAdvancedModelingOptionsDialog ApplyPresets(ModelingOptionsModel presets);
}