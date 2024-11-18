using System;
using System.Threading;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace ProXamlToolbox
{
	public class OutputPane
	{
		private static Guid pxtPaneGuid = new Guid("002A8552-5B63-4765-9970-69B016BB9AF4");

		private static OutputPane instance;

		private readonly IVsOutputWindowPane pane;

		private OutputPane()
		{
			ThreadHelper.ThrowIfNotOnUIThread();

			if (ServiceProvider.GlobalProvider.GetService(typeof(SVsOutputWindow)) is IVsOutputWindow outWindow
			 && (ErrorHandler.Failed(outWindow.GetPane(ref pxtPaneGuid, out pane)) || pane == null))
			{
				if (ErrorHandler.Failed(outWindow.CreatePane(ref pxtPaneGuid, Vsix.Name, 1, 0)))
				{
					System.Diagnostics.Debug.WriteLine("Failed to create the Output window pane.");
					return;
				}

				if (ErrorHandler.Failed(outWindow.GetPane(ref pxtPaneGuid, out pane)) || (pane == null))
				{
					System.Diagnostics.Debug.WriteLine("Failed to get access to the Output window pane.");
				}
			}
		}

		public static OutputPane Instance => instance ??= new OutputPane();

		public async Task ActivateAsync()
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(CancellationToken.None);

			pane?.Activate();
		}

		public async Task WriteAsync(string message)
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(CancellationToken.None);

			_ = (pane?.OutputStringThreadSafe($"{message}{Environment.NewLine}"));
		}
	}

}
