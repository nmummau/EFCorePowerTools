using EFCorePowerTools.Wizard;

namespace EFCorePowerTools.Contracts.Wizard;

public interface IWizardView
{
    public void WizardReturnInvoke(object sender, WizardReturnEventArgs e);

    public bool? ShowDialog();
}