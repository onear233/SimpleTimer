using CommunityToolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using SimpleTimer.Models;
using System.IO;
using System.Windows;

namespace SimpleTimer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigModel configModel = new ConfigModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonRestartApp_OnClick(object sender, RoutedEventArgs e)
        {
            ShowRestartDialog();
        }

        private async void ShowRestartDialog()
        {
            //TODO
            Application.Current.Shutdown();
        }

        

        private void ButtonBaseToggleNavigationDrawer_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Import_Config_Button_Click(object sender, RoutedEventArgs e)
        {
            //Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "NewConfig"; //Default file name
            dialog.DefaultExt = ".json"; //Default file extension
            dialog.Filter = "Simple Timer Config (.json)|*.json"; //Filter files by extension

            //Show open file dialog box
            bool? result = dialog.ShowDialog();

            //Process open file dialog box results
            if (result == true)
            {
                string filename = dialog.FileName;
                string fileContent = File.ReadAllText(filename);
                configModel = JsonConvert.DeserializeObject<ConfigModel>(fileContent);
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new ConfigWizard().Show();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            new TimerWindow().Show();
            WeakReferenceMessenger.Default.Send(configModel);
        }
    }
}
