using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace WorkVitCenter.Core.Utilities.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static dynamic SelectlistOf<T>()
        {
            Type type = typeof(T);
            return type.IsEnum ? System.Enum.GetValues(type).Cast<System.Enum>().Select(x => new { id = x.ToInt32(), text = x.GetDescription() }) : null;
        }



        public static string GetDescription(this System.Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return value.ToString();

            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }

    }
}