using System.Collections.Generic;

namespace SimpleTimer.Models
{
    partial class ConfigModel
    {
        /*
         * 配置文件模型
         * 1.每个配置文件包含配置文件的名称和时间段的数量
         * 2.每个时间段有一个名字，并有一个时间长度和是否包含在上一个时间的bool值
         */

        //配置文件名称
        private string _name;

        //时间段的数量
        private int _timeIntervalCount;

        //时间的对象列表，每一个TimeList对象表示一个时间段，使用一个List来存储
        private List<TimeList> _timeList;

        public string Name { get => _name; set => _name = value; }
        public int TimeIntervalCount { get => _timeIntervalCount; set => _timeIntervalCount = value; }
        internal List<TimeList> TimeList { get => _timeList; set => _timeList = value; }
    }
}
