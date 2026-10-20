namespace EFCorePowerTools.Common.DAL;

public interface IOperatingSystemAccess
{
    public void StartProcess(string fileName);

    public void SetClipboardText(string text);
}