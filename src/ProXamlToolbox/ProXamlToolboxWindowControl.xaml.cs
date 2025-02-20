﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace ProXamlToolbox
{
	public partial class ProXamlToolboxWindowControl : UserControl
	{
		private readonly DTE dte;

		public ProXamlToolboxWindowControl()
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			this.InitializeComponent();
			dte = Package.GetGlobalService(typeof(DTE)) as DTE;

			this.DataContext = new ToolboxViewModel();
		}

		private void OnToolboxItemMoved(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (sender is FrameworkElement fe && fe.DataContext is ProToolboxItem pti)
				{
					// Ensure what it dropped is formatted correctly
					var insertLogic = new InsertLogic(
						-1,
						-1,
						pti,
						new ToolboxSettings
						{
							IncludeXName = IncludeXName.IsChecked ?? false,
							PreferCommands = PreferCommands.IsChecked ?? false,
							IncludeA11y = IncludeA11y.IsChecked ?? false,
						});

					var textToInsert =
						insertLogic.MakeTextReplacements(pti.DefaultContent)
								   .Replace(ProToolboxItem.CursorPlaceholder, string.Empty);

					DragDrop.DoDragDrop(fe, textToInsert, DragDropEffects.Copy);
				}
			}
		}

		private void OnToolboxItemMouseDown(object sender, MouseButtonEventArgs e)
		{
			ThreadHelper.ThrowIfNotOnUIThread();

			if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
			{
				if (sender is FrameworkElement fe && fe.DataContext is ProToolboxItem pti)
				{
					Document activeDoc = dte.ActiveDocument;

					TextSelection selection = activeDoc.Selection as TextSelection;

					var insertLogic = new InsertLogic(
						selection.ActivePoint.Line,
						selection.ActivePoint.LineCharOffset,
						pti,
						new ToolboxSettings
						{
							IncludeXName = IncludeXName.IsChecked ?? false,
							PreferCommands = PreferCommands.IsChecked ?? false,
							IncludeA11y = IncludeA11y.IsChecked ?? false,
						});

					var (TextToInsert, InsertionLine, InsertionLineOffset) = insertLogic.GetFormattedTextAndOffsets(pti.DefaultContent);

					selection.Insert(TextToInsert);

					if (InsertionLine > -1)
					{
						// Add 1 to position offset as VS starts counting from 1
						selection.MoveToLineAndOffset(InsertionLine, InsertionLineOffset + 1);
					}
				}
			}
		}
	}
}
