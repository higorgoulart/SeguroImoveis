using System.IO;

namespace SeguroImoveis.Utils
{
    public static class DirectoryUtils
    {
        public static string GetParent(string path)
        {
            var parent = Directory.GetParent(path);

            if (parent == null) return path;

            return parent.FullName;
        }
    }
}
