using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WorkVitCenter.Core.Utilities.Enum
{
    public class Description : Attribute
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public Description(string text)
        {
            Text = text;
        }
        public Description(string text, int value)
        {
            Text = text;
            Value = value;
        }
    }
    public class EnumProvider
    {
        public string GetDescription(System.Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }
        public string GetDescription(Type enumType, int value)
        {
            var name = System.Enum.GetName(enumType, value);
            return (name != null)
                ? GetDescription((System.Enum)System.Enum.Parse(enumType, name))
                : string.Empty;
        }
        public int GetDescriptionInt(System.Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo.Length <= 0)
                return Convert.ToInt16(en);
            var attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);

            return attrs.Length > 0
                ? Convert.ToInt16(((Description)attrs[0]).Value)
                : Convert.ToInt16(en);
        }
        public IList<Description> BindToEnum(Type enumType, bool select)
        {
            var list = new List<Description>();
            var values = System.Enum.GetValues(enumType);
            if (select) list.Add(new Description("Select One..", -1));
            var i = 0;
            foreach (int value in values)
            {
                i++;
                var item = new Description(GetDescription((System.Enum)System.Enum.Parse(enumType, value.ToString())), value);
                list.Add(item);
            }
            return list;
        }
    }
}
