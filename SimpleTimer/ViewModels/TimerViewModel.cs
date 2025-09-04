using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Uwp.Notifications;
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

        [ObservableProperty]
        private string timeName;

        private DispatcherTimer timer;

        // 在TimerViewModel中添加字段保存ConfigModel
        private ConfigModel _lastConfig;

        public TimerViewModel()
        {
            WeakReferenceMessenger.Default.Register(this);
            //默认时间
            TimeName = "未配置时间段";
            RemainingTime = TimeSpan.FromMinutes(0);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        //Implement the Receive method required by IRecipient<ConfigModel>
        public void Receive(ConfigModel config)
        {
            _lastConfig = config;
            TimeName = config.TimeList[0].TimeName;
            RemainingTime = config.TimeList[0].TimeLength;
            StartCountdown();
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
                if (_lastConfig.TimeIntervalCount >= 1)
                {
                    for (int i = 1; i < _lastConfig.TimeIntervalCount; i++)
                    {
                        //检查是否需要切换为下一个内含时间段的名称
                        if (_lastConfig.TimeList[i].IsIncludePrevious &&
                        RemainingTime == _lastConfig.TimeList[i].TimeLength)
                        {
                            ringBell("当前时间段：" + _lastConfig.TimeList[i].TimeName);
                            TimeName = _lastConfig.TimeList[i].TimeName;
                        }
                    }
                }
            }
            else
            {
                ringBell("计时结束");
                timer.Stop();
            }
        }
        private void ringBell(string text)
        {
            new ToastContentBuilder()
            .AddText("TimeIsLand")
            .AddText(text)
            .SetBackgroundActivation()
            .Show();
        }
    }
}
