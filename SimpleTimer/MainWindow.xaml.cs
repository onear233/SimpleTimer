using CommunityToolkit.Mvvm.Messaging;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using SimpleTimer.Controls;
using SimpleTimer.Models;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SimpleTimer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigModel configModel;
        public MainWindow()
        {
            new TimerWindow().Show();
            InitializeComponent();
        }

        private void ButtonRestartApp_OnClick(object sender, RoutedEventArgs e)
        {
            ShowRestartDialog();
        }

        private async void ShowRestartDialog()
        {
            //TODO
            System.Windows.Application.Current.Shutdown();
        }

        

        private void ButtonBaseToggleNavigationDrawer_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Import_Config_Button_Click(object sender, RoutedEventArgs e)
        {
            //配置导入配置文件的窗口
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "NewConfig";
            dialog.DefaultExt = ".json";
            dialog.Filter = "Simple Timer Config (.json)|*.json"; //Filter files by extension

            //打开文件选择窗口
            bool? result = dialog.ShowDialog();

            //选择了文件
            if (result == true)
            {
                string filename = dialog.FileName;
                string fileContent = File.ReadAllText(filename);
                configModel = new ConfigModel();
                configModel = JsonConvert.DeserializeObject<ConfigModel>(fileContent);
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            new ConfigWizard().Show();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new MessageBoxControl();
            sampleMessageDialog.Message.Text = "未导入任何配置文件\n要开始使用，请创建或导入已有的配置文件";
            if (configModel == null)
            {
                //指定DialogHost的Identifier
                DialogHost.Show(sampleMessageDialog, "RootDialog");
            }
            else
            {
                WeakReferenceMessenger.Default.Send(configModel);
            }
        }
    }
}
