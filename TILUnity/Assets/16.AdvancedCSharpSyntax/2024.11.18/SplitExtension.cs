public static class SplitExtension
{
    public static string[] Split(this string strs, char separator)
    {
        string[] str = strs.Split(separator);
        for (int i = 0; i < str.Length; i++)
            str[i] = str[i].ToUpper();
        return str;
    }
}
