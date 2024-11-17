using System;

namespace ProXamlToolbox
{
	[Flags]
	public enum TargetPlatform
	{
		Maui = 1,
		WinUI = 2,
		Wpf = 4,
		MauiAndWinui = Maui | WinUI,
	}
}
