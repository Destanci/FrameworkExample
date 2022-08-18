using System;

namespace WorkVitCenter.Core.Utilities.ExtensionMethods
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Datetime to string. (e.g 16.05.2016 21:30)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns>string 16.05.2016 21:30</returns>
        public static string DateTimeToString(this DateTime datetime)
        {
            var result = datetime.ToString("dd.MM.yyyy HH:mm");
            return result;
        }


    }
}