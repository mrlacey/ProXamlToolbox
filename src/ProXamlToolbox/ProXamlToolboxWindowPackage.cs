using System;
using System.Runtime.InteropServices;
using System.Threading;
using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace ProXamlToolbox
{
	/// <summary>
	/// This is the class that implements the package exposed by this assembly.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The minimum requirement for a class to be considered a valid package for Visual Studio
	/// is to implement the IVsPackage interface and register itself with the shell.
	/// This package uses the helper classes defined inside the Managed Package Framework (MPF)
	/// to do it: it derives from the Package class that provides the implementation of the
	/// IVsPackage interface and uses the registration attributes defined in the framework to
	/// register itself and its components with the shell. These attributes tell the pkgdef creation
	/// utility what data to put into .pkgdef file.
	/// </para>
	/// <para>
	/// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
	/// </para>
	/// </remarks>
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version, IconResourceID = 400)] // Info on this package for Help/About
	[Guid(PackageGuids.guidProXamlToolboxWindowPackageString)]
	[ProvideToolWindow(typeof(ProXamlToolboxWindow.Pane), Style = VsDockStyle.Tabbed, DockedWidth = 300, Window = WindowGuids.DocumentWell, Orientation = ToolWindowOrientation.Left)]
	[ProvideToolWindowVisibility(typeof(ProXamlToolboxWindow.Pane), UIContextGuid, bringToFront: true)]
	[ProvideUIContextRule(UIContextGuid,
			name: "Active editor is XAML file",
			expression: "xamlFile",
			termNames: new[] { "xamlFile" },
			termValues: new[] { "ActiveEditorContentType:XAML" })]
	[ProvideMenuResource("Menus.ctmenu", 1)]
	public sealed class ProXamlToolboxWindowPackage : ToolkitPackage
	{
		public const string UIContextGuid = "7E4B9E65-D661-4CEA-B2CD-99F5200397B4";

		protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			this.RegisterToolWindows();

			await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
			await this.RegisterCommandsAsync();
		}
	}
}
