using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

namespace ProXamlToolbox
{
    public class ProXamlToolboxWindow : BaseToolWindow<ProXamlToolboxWindow>
    {
        public override string GetTitle(int toolWindowId) => "Pro XAML Toolbox";

        public override Type PaneType => typeof(Pane);

        public override async Task<FrameworkElement> CreateAsync(int toolWindowId, CancellationToken cancellationToken)
        {
            await Package.JoinableTaskFactory.SwitchToMainThreadAsync();

            return new ProXamlToolboxWindowControl();
        }

        [Guid("A6830831-ECBF-434E-A60F-40A16E714429")]
        public class Pane : ToolWindowPane
        {
            public Pane()
            {
                BitmapImageMoniker = KnownMonikers.ToolBox;
            }
        }
    }
}
