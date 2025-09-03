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
        }
    }
}