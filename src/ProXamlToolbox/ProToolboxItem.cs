using Microsoft.VisualStudio.Imaging.Interop;

namespace ProXamlToolbox
{
    internal class ProToolboxItem
    {
        public const string CursorPlaceholder = "*|*";

        public TargetPlatform Platforms { get; set; } = TargetPlatform.MauiAndWinui;

        public ImageMoniker ImageMoniker { get; set; }

        public string DisplayedText { get; set; }

        public string DefaultContent { get; set; }
    }
}
