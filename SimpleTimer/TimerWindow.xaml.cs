using SimpleTimer.Models;
using System.Windows;
using System.Windows.Input;

namespace SimpleTimer
{
    /// <summary>
    /// TimerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TimerWindow : Window
    {
        private ConfigModel Config { get; set; }
        public TimerWindow(ConfigModel config)
        {
            InitializeComponent();
            this.Config = config;
        }

        //窗口拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
