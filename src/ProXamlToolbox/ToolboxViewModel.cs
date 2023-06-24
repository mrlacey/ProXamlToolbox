using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Imaging;

namespace ProXamlToolbox
{
    internal class ToolboxViewModel
    {
        public ToolboxViewModel()
        {
            Items = GetDefaultItems();
        }

        public ObservableCollection<ProToolboxItem> Items { get; set; }

        private ObservableCollection<ProToolboxItem> GetDefaultItems()
        {
            return new ObservableCollection<ProToolboxItem> {
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Grid,
                    DisplayedText = "Grid",
                    DefaultContent = "<Grid [XN] RowDefinitions=\"Auto,Auto,*\" ColumnDefinitions=\"*,*\">\r\n*|*\r\n</Grid>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Label,
                    DisplayedText = "Label",
                    DefaultContent = "<Label [XN] Text=\"CHANGEME\"[A11Y]SemanticProperties.HeadingLevel=\"Level1\" />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.TextBox,
                    DisplayedText = "Entry",
                    DefaultContent = "<Entry [XN] Text=\"{Binding PropertyName}\" Placeholder=\"CHANGEME\" />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Button,
                    DisplayedText = "Button",
                    DefaultContent = "<Button [XN][EVNT]Clicked=\"OnButtonClicked\"[CMD]Command=\"{Binding CommandName}\" Text=\"click me\"[A11Y]SemanticProperties.Hint=\"Add a description of what happens when clicked\" />\r\n",
                },
            };
        }
    }
}