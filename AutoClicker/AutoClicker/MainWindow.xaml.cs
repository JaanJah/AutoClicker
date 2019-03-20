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
        private int count = 0;
        private GlobalKeyboardHook _globalKeyboardHook;

        public MainWindow()
        {
            InitializeComponent();
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
            Loaded += MainWindow_Loaded;
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {

            if (e.KeyboardData.VirtualCode != GlobalKeyboardHook.VkF8)
                return;

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                ControlClicker();
                e.Handled = true;
            }
        }

        public void Dispose()
        {
            _globalKeyboardHook?.Dispose();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        //private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.F8)
        //    {
        //        ControlClicker();
        //    }
        //}

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
            Close();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            ControlClicker();
        }

        private void ControlClicker()
        {
            Clicker clicker = new Clicker();
            count++;
            if (count % 2 == 1)
            {
                clicker.ClickerActive = true;
                clicker.StartClicker();
                StartBtn.Content = "Stop autoclicker";
            }
            if (count % 2 == 0)
            {
                clicker.StopClicker();
                StartBtn.Content = "Start autoclicker";
            }
        }
    }
}
