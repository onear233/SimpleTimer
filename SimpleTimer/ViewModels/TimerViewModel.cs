using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SimpleTimer.ViewModels
{
    public partial class TimerViewModel : ObservableObject
    {
        [ObservableProperty]
        private TimeSpan remainingTime;

        private DispatcherTimer timer;

        public TimerViewModel()
        {
            RemainingTime = TimeSpan.FromMinutes(1);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
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
