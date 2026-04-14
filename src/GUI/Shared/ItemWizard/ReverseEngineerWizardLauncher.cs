using System.Collections.Generic;
using EFCorePowerTools.Handlers.ReverseEngineer;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace EFCorePowerTools.ItemWizard
{
    public class ReverseEngineerWizardLauncher : Microsoft.VisualStudio.TemplateWizard.IWizard
    {
        // Update vstemplate version reference if main assembly version changes
        // In \src\GUI\WizardItemTemplate\WizardItemTemplate.vstemplate
        void Microsoft.VisualStudio.TemplateWizard.IWizard.RunStarted(
            object automationObject,
            Dictionary<string, string> replacementsDictionary,
            Microsoft.VisualStudio.TemplateWizard.WizardRunKind runKind,
            object[] customParams)
        {
            if (PackageManager.Package != null)
            {
                var handler = new ReverseEngineerHandler(PackageManager.Package);
                handler.ReverseEngineerCodeFirstAsync().FireAndForget();
            }
        }

        // This method is only called for item templates,
        // not for project templates.
        bool Microsoft.VisualStudio.TemplateWizard.IWizard.ShouldAddProjectItem(string filePath)
        {
            return false;
        }

        // This method is called after the project is created.
        void Microsoft.VisualStudio.TemplateWizard.IWizard.RunFinished()
        {
            // Ignore
        }

        // This method is only called for item templates,
        // not for project templates.
        void Microsoft.VisualStudio.TemplateWizard.IWizard.ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            // Never called due to false above
        }

        // This method is called before opening any item that
        // has the OpenInEditor attribute.
        void Microsoft.VisualStudio.TemplateWizard.IWizard.BeforeOpeningFile(ProjectItem projectItem)
        {
            // Never called, as this is diabled
        }

        void Microsoft.VisualStudio.TemplateWizard.IWizard.ProjectFinishedGenerating(Project project)
        {
            // Never called, this is an item template
        }
    }
}