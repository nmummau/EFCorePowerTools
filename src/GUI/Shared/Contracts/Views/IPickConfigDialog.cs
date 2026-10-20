using System.Collections.Generic;
using EFCorePowerTools.Common.Models;

namespace EFCorePowerTools.Contracts.Views;

public interface IPickConfigDialog : IDialog<ConfigModel>
{
    public void PublishConfigurations(IEnumerable<ConfigModel> configurations);
}