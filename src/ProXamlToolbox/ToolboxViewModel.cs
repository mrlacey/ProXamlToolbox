using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Imaging;

namespace ProXamlToolbox
{
    internal class ToolboxViewModel
    {
        public ToolboxViewModel()
        {
            LayoutItems = GetDefaultLayoutItems();
            ControlItems = GetDefaultControlItems();
        }

        // TODO: Support proper grouped item lists
        public ObservableCollection<ProToolboxItem> LayoutItems { get; set; }

        public ObservableCollection<ProToolboxItem> ControlItems { get; set; }

        private ObservableCollection<ProToolboxItem> GetDefaultLayoutItems()
        {
            return new ObservableCollection<ProToolboxItem> {
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.FrameSet,
                    DisplayedText = "ContentView",
                    DefaultContent = "<ContentView [XN]>\r\n*|*\r\n</ContentView>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.FrameContainer,
                    DisplayedText = "Frame",
                    DefaultContent = "<Frame [XN]>\r\n*|*\r\n</ContentView>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.ScrollBox,
                    DisplayedText = "ScrollView",
                    DefaultContent = "<ScrollView [XN]>\r\n*|*\r\n</ScrollView>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.LayoutPanel,
                    DisplayedText = "AbsoluteLayout",
                    DefaultContent = "<AbsoluteLayout [XN]>\r\n*|*\r\n</AbsoluteLayout>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.FlowLayoutPanel,
                    DisplayedText = "FlexLayout",
                    DefaultContent = "<FlexLayout [XN]>\r\n*|*\r\n</FlexLayout>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Grid,
                    DisplayedText = "Grid",
                    DefaultContent = "<Grid [XN] RowDefinitions=\"Auto,Auto,*\" ColumnDefinitions=\"*,*\">\r\n*|*\r\n</Grid>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.AlignVerticalStretch,
                    DisplayedText = "HorizontalStackLayout",
                    DefaultContent = "<HorizontalStackLayout [XN]>\r\n*|*\r\n</HorizontalStackLayout>",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.AlignHorizontalStretch,
                    DisplayedText = "VerticalStackLayout",
                    DefaultContent = "<VerticalStackLayout [XN]>\r\n*|*\r\n</VerticalStackLayout>",
                },
            };
        }

        private ObservableCollection<ProToolboxItem> GetDefaultControlItems()
        {
            return new ObservableCollection<ProToolboxItem> {
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Box,
                    DisplayedText = "BoxView",
                    DefaultContent = "<BoxView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Activity,
                    DisplayedText = "ActivityIndicator",
                    DefaultContent = "<ActivityIndicator [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.WebApplication,
                    DisplayedText = "BlazorWebView",
                    DefaultContent = "<BlazorWebView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.BorderElement,
                    DisplayedText = "Border",
                    DefaultContent = "<Border [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Button,
                    DisplayedText = "Button",
                    DefaultContent = "<Button [XN][EVNT]Clicked=\"OnButtonClicked\"[CMD]Command=\"{Binding CommandName}\" Text=\"click me\"[A11Y]SemanticProperties.Hint=\"Add a description of what happens when clicked\" />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Carousel,
                    DisplayedText = "CarouselView",
                    DefaultContent = "<CarouselView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.CheckBoxChecked,
                    DisplayedText = "CheckBox",
                    DefaultContent = "<CheckBox [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.ListView,
                    DisplayedText = "CollectionView",
                    DefaultContent = "<CollectionView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.DateTimePicker,
                    DisplayedText = "DatePicker",
                    DefaultContent = "<DatePicker [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Editor,
                    DisplayedText = "Editor",
                    DefaultContent = "<Editor [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.TextBox,
                    DisplayedText = "Entry",
                    DefaultContent = "<Entry [XN] Text=\"{Binding PropertyName}\" Placeholder=\"CHANGEME\" />\r\n",
                },
                new ProToolboxItem
                {
                    //ImageMoniker = KnownMonikers.ListView,
                    DisplayedText = "GraphicsView",
                    DefaultContent = "<GraphicsView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Image,
                    DisplayedText = "Image",
                    DefaultContent = "<Image [XN] Source=\"PATH-TO-IMAGE\" />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.ImageButton,
                    DisplayedText = "ImageButton",
                    DefaultContent = "<ImageButton [XN] Source=\"PATH-TO-IMAGE\" />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Label,
                    DisplayedText = "Label",
                    DefaultContent = "<Label [XN] Text=\"CHANGEME\"[A11Y]SemanticProperties.HeadingLevel=\"Level1\" />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.ListView,
                    DisplayedText = "ListView",
                    DefaultContent = "<ListView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.MapTileLayer,
                    DisplayedText = "Map",
                    DefaultContent = "<!-- Make sure you add the NuGet package Microsoft.Maui.Controls.Maps -->\r\n<map:Map [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Picker,
                    DisplayedText = "Picker",
                    DefaultContent = "<Picker [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.ProgressBar,
                    DisplayedText = "ProgressBar",
                    DefaultContent = "<ProgressBar [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.RadioButton,
                    DisplayedText = "RadioButton",
                    DefaultContent = "<RadioButton [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Refresh,
                    DisplayedText = "RefreshView",
                    DefaultContent = "<RefreshView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Search,
                    DisplayedText = "SearchBar",
                    DefaultContent = "<SearchBar [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.Slider,
                    DisplayedText = "Slider",
                    DefaultContent = "<Slider [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.ButtonGroup,
                    DisplayedText = "Stepper",
                    DefaultContent = "<Stepper [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    //ImageMoniker = KnownMonikers.ToggleButton,
                    DisplayedText = "SwipeView",
                    DefaultContent = "<SwipeView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.ToggleButton,
                    DisplayedText = "Switch",
                    DefaultContent = "<Switch [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.AppearanceGrid,
                    DisplayedText = "TableView",
                    DefaultContent = "<TableView [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.TimePicker,
                    DisplayedText = "TimePicker",
                    DefaultContent = "<TimePicker [XN] />\r\n",
                },
                new ProToolboxItem
                {
                    ImageMoniker = KnownMonikers.WebApplication,
                    DisplayedText = "WebView",
                    DefaultContent = "<WebView [XN] />\r\n",
                },
            };
        }
    }
}