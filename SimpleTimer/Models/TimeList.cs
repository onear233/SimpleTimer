using System;

namespace SimpleTimer.Models
{
    public class TimeList
    {
        //时间排序
        private int timeIndex;
        //是否包含在上一个时间段
        private bool isIncludePrevious;
        //时间段的名称
        private string timeName;
        //时间段的长度
        private TimeSpan timeLength;

        public int TimeIndex { get => timeIndex; set => timeIndex = value; }
        public bool IsIncludePrevious { get => isIncludePrevious; set => isIncludePrevious = value; }
        public string TimeName { get => timeName; set => timeName = value; }
        public TimeSpan TimeLength { get => timeLength; set => timeLength = value; }
    }
}
