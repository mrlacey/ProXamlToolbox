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

		// TODO: add validation tests of all default item content
		private ObservableCollection<ProToolboxItem> GetDefaultLayoutItems()
		{
			return new ObservableCollection<ProToolboxItem> {
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.LayoutPanel,
					DisplayedText = "AbsoluteLayout",
					DefaultContent = "<AbsoluteLayout [XN]>\r\n*|*\r\n</AbsoluteLayout>",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.BorderElement,
					DisplayedText = "Border",
					DefaultContent = "<Border [XN]>\r\n*|*\r\n</Border>",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Carousel,
					DisplayedText = "CarouselView",
					DefaultContent = "<CarouselView [XN] ItemsSource=\"{Binding PropertyName}\">\r\n<CarouselView.ItemsLayout>\r\n<LinearItemsLayout Orientation=\"Horizontal\" />\r\n</CarouselView.ItemsLayout>\r\n<CarouselView.ItemTemplate>\r\n<DataTemplate>\r\n*|*\r\n</DataTemplate>\r\n</CarouselView.ItemTemplate>\r\n</CarouselView>",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.ListView,
					DisplayedText = "CollectionView",
					DefaultContent = "<CollectionView [XN] ItemsSource=\"{Binding PropertyName}\" SelectionMode=\"Single\"[CMD]SelectionChangedCommand=\"{Binding CommandName}\"[EVNT]SelectionChanged=\"OnSelectionChanged\">\r\n<CollectionView.ItemTemplate>\r\n<DataTemplate>\r\n*|*\r\n</DataTemplate>\r\n</CollectionView.ItemTemplate>\r\n<CollectionView.EmptyView>\r\n<ContentView>\r\n<StackLayout HorizontalOptions=\"CenterAndExpand\"\r\nVerticalOptions=\"CenterAndExpand\">\r\n<Label Text=\"Nothing to see here.\"\r\n />\r\n</StackLayout>\r\n</ContentView>\r\n</CollectionView.EmptyView>\r\n</CollectionView>",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.FrameSet,
					DisplayedText = "ContentView",
					DefaultContent = "<ContentView [XN]>\r\n*|*\r\n</ContentView>",
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
					ImageMoniker = KnownMonikers.ListView,
					DisplayedText = "ListView",
					DefaultContent = "<ListView [XN] ItemsSource=\"{Binding PropertyName}\" IsPullToRefreshEnabled=\"True\"[CMD]RefreshCommand=\"{Binding CommandName}\"[EVNT]ItemSelected=\"OnItemSelected\">\r\n<ListView.ItemTemplate>\r\n<DataTemplate>\r\n*|*\r\n</DataTemplate>\r\n</ListView.ItemTemplate>\r\n</ListView>",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Refresh,
					DisplayedText = "RefreshView",
					DefaultContent = "<RefreshView [XN] IsRefreshing=\"{Binding IsRefreshing}\" Command=\"{Binding RefreshCommand}\" >\r\n*|*\r\n</RefreshView>",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.ScrollBox,
					DisplayedText = "ScrollView",
					DefaultContent = "<ScrollView [XN]>\r\n*|*\r\n</ScrollView>",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.TouchableDevice,
					DisplayedText = "SwipeView",
					DefaultContent = "<SwipeView [XN] ><SwipeView.LeftItems>\r\n<SwipeItem Text=\"ChangeThis\"[CMD]Command=\"{Binding CommandName}\"[EVNT]Invoked=\"OnSwipeItemInvoked\" />\r\n</SwipeView.LeftItems>\r\n*|*\r\n</SwipeView>\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.AppearanceGrid,
					DisplayedText = "TableView",
					DefaultContent = "<TableView [XN] Intent=\"Menu\">\r\n<TableRoot>\r\n*|*\r\n</TableRoot>\r\n</TableView>\r\n",
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
					ImageMoniker = KnownMonikers.Activity,
					DisplayedText = "ActivityIndicator",
					DefaultContent = "<ActivityIndicator [XN] IsRunning=\"True\" IsVisible=\"True\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Box,
					DisplayedText = "BoxView",
					DefaultContent = "<BoxView [XN] Color=\"Red\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.WebApplication,
					DisplayedText = "BlazorWebView",
					DefaultContent = "<BlazorWebView [XN] HostPage=\"wwwroot/index.html\">\r\n<BlazorWebView.RootComponents>\r\n<RootComponent Selector=\"#app\" ComponentType=\"{x:Type local:Main}\" />\r\n</BlazorWebView.RootComponents>\r\n</BlazorWebView>\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Button,
					DisplayedText = "Button",
					DefaultContent = "<Button [XN][EVNT]Clicked=\"OnButtonClicked\"[CMD]Command=\"{Binding CommandName}\" Text=\"click me\"[A11Y]SemanticProperties.Hint=\"Add a description of what happens when clicked\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.CheckBoxChecked,
					DisplayedText = "CheckBox",
					DefaultContent = "<CheckBox [XN] IsChecked=\"True\"[EVNT]CheckedChanged=\"OnCheckboxCheckedChanged\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.DateTimePicker,
					DisplayedText = "DatePicker",
                    //DefaultContent = "<DatePicker [XN] Date=\"{x:Static sys:DateTime.Now}\" />\r\n",
                    DefaultContent = "<DatePicker [XN] />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Editor,
					DisplayedText = "Editor",
					DefaultContent = "<Editor [XN] Placeholder=\"CHANGEME\" AutoSize=\"TextChanges\" Keyboard=\"Default\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.TextBox,
					DisplayedText = "Entry",
					DefaultContent = "<Entry [XN] Text=\"{Binding PropertyName}\" Placeholder=\"CHANGEME\" Keyboard=\"Default\" ClearButtonVisibility=\"WhileEditing\"  />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.ContentPlaceholder,
					DisplayedText = "GraphicsView",
					DefaultContent = "<GraphicsView [XN] HeightRequest=\"250\" WidthRequest=\"350\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Image,
					DisplayedText = "Image",
					DefaultContent = "<Image [XN] Source=\"PATH-TO-IMAGE\" HeightRequest=\"100\" WidthRequest=\"100\" Aspect=\"AspectFill\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.ImageButton,
					DisplayedText = "ImageButton",
					DefaultContent = "<ImageButton [XN] Source=\"PATH-TO-IMAGE\"[EVNT]Clicked=\"OnButtonClicked\"[CMD]Command=\"{Binding CommandName}\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Label,
					DisplayedText = "Label",
					DefaultContent = "<Label [XN] Text=\"CHANGEME\"[A11Y]SemanticProperties.HeadingLevel=\"Level1\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.MapTileLayer,
					DisplayedText = "Map",
					DefaultContent = "<!-- Make sure you add the NuGet package Microsoft.Maui.Controls.Maps -->\r\n<map:Map [XN] />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.PasswordBox,
					DisplayedText = "Password",
					DefaultContent = "<Entry [XN] Text=\"{Binding Password}\" IsPassword=\"True\" Keyboard=\"Default\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Picker,
					DisplayedText = "Picker",
					DefaultContent = "<Picker [XN] Title=\"Pick something\" ItemsSource=\"{Binding Items}\" ItemDisplayBinding=\"{Binding ItemName}\" SelectedItem=\"{Binding SelectedItem}\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.ProgressBar,
					DisplayedText = "ProgressBar",
					DefaultContent = "<ProgressBar [XN] Progress=\"{Binding Progress}\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.RadioButton,
					DisplayedText = "RadioButton",
					DefaultContent = "<RadioButton [XN] Content=\"Set This\" GroupName=\"ChangeThis\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Search,
					DisplayedText = "SearchBar",
					DefaultContent = "<SearchBar [XN] Placeholder=\"Search items...\"[CMD]SearchCommand=\"{Binding PerformSearch}\"[EVNT]SearchButtonPressed=\"OnSearchPressed\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.Slider,
					DisplayedText = "Slider",
					DefaultContent = "<Slider [XN] ValueChanged=\"OnSliderValueChanged\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.ButtonGroup,
					DisplayedText = "Stepper",
					DefaultContent = "<Stepper [XN] Minimum=\"0\" Maximum=\"100\" Increment=\"10\" />\r\n",
				},
				new ProToolboxItem
				{
					ImageMoniker = KnownMonikers.ToggleButton,
					DisplayedText = "Switch",
					DefaultContent = "<Switch [XN] OnColor=\"Orange\" />\r\n",
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
					DefaultContent = "<WebView [XN] Source=\"https://github.com/sponsors/mrlacey/\" />\r\n",
				},
			};
		}
	}
}
