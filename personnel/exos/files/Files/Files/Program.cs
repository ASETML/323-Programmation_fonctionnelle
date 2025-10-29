using System.Net.NetworkInformation;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Chemin: ");
            string chemin = Console.ReadLine();

            Console.Write("Extension (vide pour toutes): ");
            string extension = '.' + Console.ReadLine();

            ListeFichier(chemin, 0, extension);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static bool ByExtension(string c, string e)
        {
            if (e == ".") return true;
            if (c.EndsWith(e)) return true;
            return false;
        }

        static void ListeFichier(string chemin, int niveau_indentation, string extension)
        {
            try
            {
                if (File.Exists(chemin) && ByExtension(chemin, extension))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(new string(' ', niveau_indentation * 2) + $"[F][{niveau_indentation}] ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(new FileInfo(chemin).Name);
                }
                else if (Directory.Exists(chemin) && ContainsExtension(chemin, extension))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(new string(' ', niveau_indentation * 2) + $"[D][{niveau_indentation}] ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(new DirectoryInfo(chemin).Name);
                    Directory.GetFiles(chemin).ToList().ForEach(c => ListeFichier(c, niveau_indentation + 1, extension));
                    Directory.GetDirectories(chemin).ToList().ForEach(c => ListeFichier(c, niveau_indentation + 1, extension));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static bool ContainsExtension(string chemin, string extension)
        {
            if (extension != ".")
            {
                List<string> f = Directory.GetFiles(chemin).Where(x => x.EndsWith(extension)).ToList();
                if (f.Count > 0) return true;

                List<bool> b = Directory.GetDirectories(chemin).Select(x => ContainsExtension(x, extension)).ToList();
                if (b.Contains(true)) return true;
                return false;
            }
            return true;
        }
    }
}
