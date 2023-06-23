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
    }
}
