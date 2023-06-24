using System;

namespace ProXamlToolbox
{
    [Flags]
    public enum TargetPlatform
    {
        Maui = 1,
        WinUI = 2,
        MauiAndWinui = Maui | WinUI,
    }
}