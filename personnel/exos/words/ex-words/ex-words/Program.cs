using System.Text.RegularExpressions;

namespace ex_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Affichage
            Action<string> PrintWord = word => Console.WriteLine(word);

            //1
            Console.WriteLine("### 1");
            //A
            Console.WriteLine("\n## A");
            string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };
            double avg = words.Average(w => w.Length);
            string[] wordsToKeep = words.Where(w => w.Length >= 4 && !w.Contains('x') && w.Length == avg).ToArray();

            //dans l’ordre inverse de celui naturellement calculé
            Console.WriteLine("\n# REVERSE");
            string[] wordsToKeepReverse = wordsToKeep.Reverse().ToArray();

            Array.ForEach(wordsToKeepReverse, PrintWord);
            //triés a-z
            Console.WriteLine("\n# AZ");
            string[] wordsToKeepAZ = wordsToKeep.OrderBy(w => w).ToArray();

            Array.ForEach(wordsToKeepAZ, PrintWord);

            //triés z-a
            Console.WriteLine("\n# ZA");
            string[] wordsToKeepZA = wordsToKeep.OrderByDescending(w => w).ToArray();

            Array.ForEach(wordsToKeepZA, PrintWord);

            //B
            Console.WriteLine("\n## B");
            string[] wordsB = { "whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune", "My kingdom for a horse !", "Ooops I did it again" };

            Array.ForEach(wordsB.Skip(1).SkipLast(2).ToArray(), PrintWord);

            //C
            Console.WriteLine("\n## C");
            string[] wordsC = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };

            Array.ForEach(wordsC.SkipWhile(w => !Regex.IsMatch(w, "[a-zA-Z]")).ToArray(), PrintWord);
            Console.WriteLine("On ne peut pas s'en sortir avec un SkipWhile, car la validation cesse de s'effectuer lorsqu'on trouve un élément à garder");

            //D
            Console.WriteLine("\n## D");
            string[] wordsD = { "i am the winner", "hello", "monde", "vert", "rouge", "bleu", "i am the looser" };

            Console.WriteLine("The winner is : " + wordsD.First());
            Console.WriteLine("The looser is : " + wordsD.Last());

            //Partie 2
            Console.WriteLine("\n### 2");

            // http://www.gymomath.ch/javmath/corona/3OC/Fr%C3%A9quences%20d'apparition.pdf
            Dictionary<char, double> letterReparition = new Dictionary<char, double> { { 'a', 0.084 }, { 'b', 0.0106 }, { 'c', 0.0303 }, { 'd', 0.0418 }, { 'e', 0.1726 }, { 'f', 0.0112 }, { 'g', 0.0127 }, { 'h', 0.0092 }, { 'i', 0.0734 }, { 'j', 0.0031 }, { 'k', 0.0005 }, { 'l', 0.0601 }, { 'm', 0.0296 }, { 'n', 0.0713 }, { 'o', 0.0526 }, { 'p', 0.0301 }, { 'q', 0.0099 }, { 'r', 0.0655 }, { 's', 0.0808 }, { 't', 0.0707 }, { 'u', 0.0574 }, { 'v', 0.0132 }, { 'w', 0.0004 }, { 'x', 0.0045 }, { 'y', 0.0030 }, { 'z', 0.0012 } };

            Dictionary<char, int> letterInWord = new Dictionary<char, int>();

            char[] word = Console.ReadLine().ToLower().ToCharArray();

            Action<char> CountChars = c =>
            {
                if (letterInWord.ContainsKey(c))
                {
                    letterInWord[c] += 1;
                    return;
                }
                letterInWord.Add(c, 1);
            };

            Array.ForEach(word, CountChars);

            double epsilon = 0;

            letterInWord.ToList().ForEach(p => epsilon += letterReparition[p.Key] / letterInWord[p.Key]);

            Console.WriteLine(epsilon);

            Console.ReadLine();
        }
    }
}