using System.Threading.Tasks;
using EFCorePowerTools.Common.Models;
using Microsoft.VisualStudio.Data.Services;

namespace EFCorePowerTools.Common.DAL;

public interface IVisualStudioAccess
{
    public DatabaseConnectionModel PromptForNewDatabaseConnection();

    public DatabaseConnectionModel PromptForNewDacpacDatabaseDefinition();

    public Task RemoveDatabaseConnectionAsync(IVsDataConnection dataConnection);

    public void ShowMessage(string message);

    public Task StartStatusBarAnimationAsync();

    public Task StopStatusBarAnimationAsync();

    public Task SetStatusBarTextAsync(string text);

    public void ShowError(string error);

    public void OpenFile(string fileName);
}