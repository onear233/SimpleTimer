using CommunityToolkit.Mvvm.Messaging;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using SimpleTimer.Controls;
using SimpleTimer.Models;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Management;

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

            canvas.Visibility = Visibility.Visible;

        }





        string watermark = "仅供测试使用，非最终release版本";


        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            InitWatermark();
        }


        // 获取CPU序列号
        public static string GetCPUSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                string cpuSerialNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    cpuSerialNumber = mo["ProcessorId"].ToString().Trim();
                    break;
                }
                return cpuSerialNumber;
            }
            catch
            {
                return "";
            }
        }

        private void InitWatermark()
        {
            canvas.Children.Clear();

            FormattedText formattedText = new FormattedText(
                watermark,
                CultureInfo.GetCultureInfo("en-us"),
                System.Windows.FlowDirection.LeftToRight, // 修正：使用类型名限定
                new Typeface("Verdana"),
                24,
                Brushes.Black,
                VisualTreeHelper.GetDpi(this).PixelsPerDip
            );

            var height = 100.0;
            var width = height * Math.Sqrt(3);

            if (width < formattedText.Width + 100)
            {
                width = formattedText.Width + 100;
                height = width / Math.Sqrt(3);
            }

            var firstRowHeight = formattedText.Width / 2;

            int colCount = (int)Math.Ceiling(ActualWidth / width);
            int rowCount = (int)Math.Ceiling((ActualHeight - firstRowHeight) / height);

            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < colCount; ++j)
                {
                    TextBlock block = new TextBlock();
                    block.Text = watermark;
                    Canvas.SetTop(block, firstRowHeight + i * height);
                    Canvas.SetLeft(block, j * width);

                    RotateTransform transform = new RotateTransform(-30, 0, 0);
                    block.RenderTransform = transform;

                    canvas.Children.Add(block);
                }
            }
        }



        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            InitWatermark();
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
            var messageDialog = new MessageBoxControl();
            messageDialog.Message.Text = "未导入任何配置文件\n要开始使用，请创建或导入已有的配置文件";
            if (configModel == null)
            {
                //指定DialogHost的Identifier
                DialogHost.Show(messageDialog, "RootDialog");
            }
            else
            {
                this.WindowState = WindowState.Minimized;
                WeakReferenceMessenger.Default.Send(configModel);
            }
        }
    }
}
