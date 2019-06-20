namespace LittleExtensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class LittleExtensions
    {
        public static string BasePath = "";

        public static IEnumerable<string> rfi(this string fname, int idx)
        {
            var fd = fname.rf();
            var r = new HashSet<string>();
            foreach (var d in fd)
            {
                var ts = d.ts();
                if (ts.Length <= idx)
                    Console.WriteLine("ERROR: {0}", d);
                r.Add(ts[idx]);
            }
            return r;
        }
        public static List<T> WrapInList<T>(this T a)
        {
            return new List<T> { a };
        }

        public static HashSet<T> tohash<T>(this IEnumerable<T> l)
        {
            return new HashSet<T>(l);
        }

        public static void wf(this IEnumerable<string> l, string path)
        {
            if (path[path.Length - 4] != '.') path += ".tsv";
            File.WriteAllLines(path, l);
        }

        public static void wf<K, V>(this IDictionary<K, V> l, string path)
        {
            if (path[path.Length - 4] != '.') path += ".tsv";
            File.WriteAllLines(path, l.Select(x => x.Key + "\t" + x.Value));
        }

        public static string dtop(this string a)
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop).pc(a);
        }

        public static string pc(this string a, string b)
        {
            return Path.Combine(a, b);
        }

        public static string[] ts(this string a)
        {
            return a.Split('\t');
        }

        public static string ts(this string a, int idx)
        {
            return a.Split('\t')[idx];
        }
        public static List<string> ss(this string a, string b)
        {
            return a.Split(new[] { b }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static string rq(this string a)
        {
            return a.Trim('"');
        }

        public static string rcf(this string a)
        {
            return File.ReadAllText(a);
        }

        public static List<string> rf(this string a)
        {
            if (a[a.Length - 4] != '.') a += ".tsv";
            return File.ReadAllLines(a).ToList();
        }
    }
}
