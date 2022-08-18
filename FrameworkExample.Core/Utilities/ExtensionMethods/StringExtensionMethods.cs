namespace WorkVitCenter.Core.Utilities.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string ToReplacePercisionLeftRight(this string str)
        {
            if (str.IsNotNullOrEmpty())
            {
                if (str.StartsWith(","))
                {
                    str = str.Substring(1, str.Length - 1);
                }
                if (str.EndsWith(","))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            else
            {
                str = string.Empty;
            }
            return str;
        }
    }
}
