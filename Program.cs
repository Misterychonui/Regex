using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            string text2;

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                text = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader("input2.txt"))
            {
                text2 = sr.ReadToEnd();
            }
            Regex1(text);
            Console.WriteLine("---------------------");
            Regex2(text2);           
            Console.ReadKey();
        }
        static void Regex1(string text)
        {         
            Regex r = new Regex(@"https?://(\w+)?/?:?(\d+)?/?(\w+/)*\w+.(\w){3,4}/?");
            Match url = r.Match(text);           
            while (url.Success)
            {
                Console.WriteLine(url);
                url = url.NextMatch();
            }
           
        }
        static void Regex2(string text2)
        {
            string output = Regex.Replace(text2, "[^a-z,0-9,^а-я,^А-Я,^A-Z, ., !, ?]", "  ");
            string pat  = Regex.Replace(output, @"(\ +)/?", " ");
            string pat2 = Regex.Replace(pat, @"(\.+)/?", ". ");
            string pat3 = Regex.Replace(pat2, @"(\!+)/?", "! ");
            string pat4 = Regex.Replace(pat3, @"(\?+)/?", "? ");
            Console.WriteLine(pat4);
        }
    }
}
