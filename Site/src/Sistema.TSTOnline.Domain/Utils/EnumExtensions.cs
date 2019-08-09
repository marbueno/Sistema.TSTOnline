using System;
using System.ComponentModel;

namespace Sistema.TSTOnline.Domain.Utils
{
    public static class EnumExtensions
    {
        public static string ToDescriptionEmum(this Enum enumObj)
        {
            var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            if (fieldInfo == null) { return enumObj.ToString(); }

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : enumObj.ToString();
        }
    }
}
