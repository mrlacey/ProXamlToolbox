using Microsoft.VisualStudio.Imaging.Interop;

namespace ProXamlToolbox
{
    public class ProToolboxItem
    {
        public const string CursorPlaceholder = "*|*";
        public const string XNamePlaceholder = " [XN]";

        public TargetPlatform Platforms { get; set; } = TargetPlatform.MauiAndWinui;

        public ImageMoniker ImageMoniker { get; set; }

        public string DisplayedText { get; set; }

        public string DefaultContent { get; set; }
    }
}
