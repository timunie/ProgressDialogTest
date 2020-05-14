using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressDialogTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var myResources = new ResourceDictionary();
            var style = new Style(typeof(MetroProgressBar));

            style.Setters.Add(new Setter(MetroProgressBar.EllipseDiameterProperty, 30d));

            myResources.Add(typeof(MetroProgressBar), style);

            var ok = await this.ShowProgressAsync("", "", settings: new MetroDialogSettings
            {
                DialogMessageFontSize = 12,
                CustomResourceDictionary = myResources,
                AnimateShow = false,
                AnimateHide = false,
                ColorScheme = this.MetroDialogOptions.ColorScheme,
            });
            ok.SetIndeterminate();
        }
    }
}
