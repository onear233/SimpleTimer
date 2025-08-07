using System.Windows;

namespace SimpleTimer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
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


    }
}
