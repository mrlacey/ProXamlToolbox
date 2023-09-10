using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace ProXamlToolbox
{
    [Command(PackageIds.ProXamlToolboxWindowCommandId)]
    internal sealed class ShowToolWindow : BaseCommand<ShowToolWindow>
    {
        protected override Task ExecuteAsync(OleMenuCmdEventArgs e) =>
            ProXamlToolboxWindow.ShowAsync();
    }
}
