using System;

namespace ProXamlToolbox
{
    [Flags]
    internal enum TargetPlatform
    {
        Maui = 1,
        WinUI = 2,
        MauiAndWinui = Maui | WinUI,
    }
}