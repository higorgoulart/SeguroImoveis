using System;
using System.Globalization;
using System.IO;

namespace SeguroImoveis.Utils
{
    public static class DatabaseUtils
    {
        public static string GetScript(string name)
        {
            var path = Directory.GetCurrentDirectory();

            while (!path.EndsWith("fonte"))
                path = DirectoryUtils.GetParent(path);

            return File.ReadAllText($@"{DirectoryUtils.GetParent(path)}\scripts\{name}");
        }

        public static string FormatToDate(string date)
        {
            return DateTime.Parse(date).ToString("yyyy-MM-dd");
        }

        public static string FormatToDecimal(string value)
        {
            return Convert.ToDecimal(value, new CultureInfo("pt-BR")).ToString(new CultureInfo("en-US"));
        }
    }
}
