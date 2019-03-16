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

namespace AutoClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //For testing MouseClick
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            //TODO: Get configs here
        }

        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //Testing
            if (e.Key == Key.F8)
            {
                VirtualMouse.LeftClick();
                VirtualMouse.MoveTo(100, 100);
            }
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
            Close();
        }
    }
}
