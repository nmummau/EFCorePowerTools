using System.Collections.Generic;
using EFCorePowerTools.Contracts.Models;

namespace EFCorePowerTools.Contracts.Views;

public interface IPickProjectDialog : IDialog<ProjectModel>
{
    public void PublishProjects(IEnumerable<ProjectModel> projects);
}