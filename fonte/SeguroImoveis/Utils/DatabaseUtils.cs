namespace SeguroImoveis.Utils
{
    public class DatabaseUtils
    {
        public static string GetScript(string name)
        {
            var path = Directory.GetCurrentDirectory();

            while (!path.EndsWith("fonte"))
                path = DirectoryUtils.GetParent(path);

            return File.ReadAllText($@"{DirectoryUtils.GetParent(path)}\scripts\{name}");
        }
    }
}
