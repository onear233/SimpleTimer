using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleTimer.Converters
{
    //索引转换器
    public class IndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                return $"文本框 {index }:";
            }
            return "文本框:";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
