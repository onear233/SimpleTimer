using SimpleTimer.ViewModels;
using System.Windows;

namespace SimpleTimer
{
    /// <summary>
    /// ConfigWizard.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWizard : Window
    {
        public ConfigWizard()
        {
            InitializeComponent();
            this.DataContext = new ConfigWizardViewModel();
        }



        /*
         * FOR TEST PURPOSES ONLY
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
