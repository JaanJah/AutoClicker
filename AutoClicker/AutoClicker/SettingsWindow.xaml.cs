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
using System.Windows.Shapes;

namespace AutoClicker
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeConfig();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void ChangeConfig()
        {
            Settings settings = new Settings();
            settings.SaveConfig(clickAmount.Text, clickInfinite.IsChecked, clickInterval.Text);
        }

        private void ClickInfinite_Checked(object sender, RoutedEventArgs e) => clickAmount.IsEnabled = false;

        private void ClickInfinite_Unchecked(object sender, RoutedEventArgs e) => clickAmount.IsEnabled = true;
    }
}
