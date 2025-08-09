using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using SimpleTimer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SimpleTimer.ViewModels
{
    public partial class TextItem : ObservableObject
    {
        [ObservableProperty]
        private string value;
    }

    partial class ConfigWizardViewModel : ObservableObject
    {
        //ObservableProperty
        [ObservableProperty]
        private int slideIndex = 0;

        [ObservableProperty]
        private string configName = "NewConfig";

        [ObservableProperty]
        private int timeIntervalCount = 1;

        //Command
        public ICommand AddConfigCommand { get; set; }
        public ICommand SaveConfigCommand { get; set; }


        //存储第二页文本框内容的集合
        public ObservableCollection<TextItem> TextValues { get; } = new ObservableCollection<TextItem>();

        //存储第三页DataGrid内容的集合
        [ObservableProperty]
        private ObservableCollection<TimeList> timelineItems = new ObservableCollection<TimeList>();



        public ConfigModel configModel = new ConfigModel();

        public ConfigWizardViewModel()
        {
            AddConfigCommand = new RelayCommand(AddConfig);
            SaveConfigCommand = new RelayCommand(SaveConfig);
        }

        // 添加配置
        private void AddConfig()
        {
            configModel.Name = ConfigName;
            configModel.TimeIntervalCount = TimeIntervalCount;
            UpdateTextBoxes();
            TimelineItems = GenerateData();
        }

        private void SaveConfig()
        {
            configModel.TimeList = TimelineItems.ToList();
            string json = JsonConvert.SerializeObject(configModel, Formatting.Indented);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "所有文件 (*.*)|*.*";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.FileName = configModel.Name;
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, json);
            }
        }

        // 更新文本框集合
        private void UpdateTextBoxes()
        {
            // 只在集合为空时初始化
            if (TextValues.Count != TimeIntervalCount)
            {
                TextValues.Clear();
                for (int i = 0; i < TimeIntervalCount; i++)
                {
                    TextValues.Add(new TextItem());
                }
            }
        }

        //获取所有文本框内容
        public List<string> GetAllTextValues()
        {
            return TextValues.Select(tv => tv.Value).ToList();
        }

        // 获取特定索引的文本框内容
        public string GetTextValueAt(int index)
        {
            if (index >= 0 && index < TextValues.Count)
                return TextValues[index].Value;
            return string.Empty;
        }

            
        private ObservableCollection<TimeList> GenerateData()
        {
            ObservableCollection<TimeList> timeLists = new ObservableCollection<TimeList>();
            for (int i = 0; i < configModel.TimeIntervalCount; i++)
            {
                timeLists.Add(new TimeList
                {
                    TimeIndex = i + 1,
                    IsIncludePrevious = false,
                    TimeName = GetTextValueAt(i),
                    TimeLength = TimeSpan.FromMinutes(5 * (i + 1))
                });
            }
            return timeLists;
        }
    }
}
