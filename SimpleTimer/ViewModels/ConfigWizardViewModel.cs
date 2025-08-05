using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleTimer.Models;
using System;
using System.Windows.Input;

namespace SimpleTimer.ViewModels
{
    partial class ConfigWizardViewModel : ObservableObject
    {
        [ObservableProperty]
        private int slideIndex = 0;

        private ConfigModel configModel { get; set; }

        [ObservableProperty]
        private string configName;

        [ObservableProperty]
        private int timeIntervalCount;

        public ICommand AddConfigCommand { get; set; }
        

        public ConfigWizardViewModel()
        {
            AddConfigCommand = new RelayCommand(AddConfig, CanAddConfig);
        }

        private bool CanAddConfig()
        {
            return true;
        }

        private void AddConfig()
        {
            ConfigModel configModel = new ConfigModel();
            configModel.Name = ConfigName;
            configModel.TimeIntervalCount = TimeIntervalCount;
        }
    }
}
