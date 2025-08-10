using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using SimpleTimer.Models;
using System;
using System.Windows;
using System.Windows.Threading;

namespace SimpleTimer.ViewModels
{
    public partial class TimerViewModel : ObservableObject, IRecipient<ConfigModel> // Implement IRecipient<ConfigModel>
    {
        [ObservableProperty]
        private TimeSpan remainingTime;

        private DispatcherTimer timer;

        public TimerViewModel()
        {
            WeakReferenceMessenger.Default.Register(this);
            RemainingTime = TimeSpan.FromMinutes(1);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        // Implement the Receive method required by IRecipient<ConfigModel>
        public void Receive(ConfigModel config)
        {
            MessageBox.Show(config.TimeIntervalCount.ToString());
        }

        public void StartCountdown()
        {
            timer.Start();
        }

        public void StopCountdown()
        {
            timer.Stop();
        }

        //定义tick事件
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (RemainingTime > TimeSpan.Zero)
            {
                RemainingTime -= TimeSpan.FromSeconds(1);
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
