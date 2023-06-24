using System.Windows;
using System.Windows.Controls;

namespace ProXamlToolbox
{
    public partial class ProXamlToolboxWindowControl : UserControl
    {
        public ProXamlToolboxWindowControl()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "ProXamlToolboxWindow");
        }
    }
}