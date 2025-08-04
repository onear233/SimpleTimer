using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleTimer.ViewModels
{
    partial class ConfigWizardViewModel : ObservableObject
    {
        [ObservableProperty]
        private int slideIndex = 0;   
        

        [ObservableProperty]
        private string test = "adsadsad";    
    }
}
