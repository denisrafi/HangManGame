using System;
using System.Collections.Generic;

namespace HangMan.ByDenisRafi
{
    class HangManGame
    {
        static void Main()
        {
            Console.Title = ("HangMan Game");
            string secretword = "@denisrafi1";
            List<string> letterGuessed = new List<string>();
            int live = 5;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome To HangMan Game");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Guess for a {0} Letter Word ", secretword.Length);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You Have {0} Live", live);
            Isletter(secretword, letterGuessed);
            while (live > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                if (letterGuessed.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Entered Letter [{0}] already", input);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Try a Different Word");
                    GetAlphabet(input);
                    continue;
                }
                letterGuessed.Add(input);
                if (IsWord(secretword, letterGuessed))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(secretword);
                    Console.WriteLine("Congratulations");
                    break;
                }
                else if (secretword.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Nice Entry");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string letters = Isletter(secretword, letterGuessed);
                    Console.Write(letters);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Letter Not in My Word");
                    live -= 1;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You Have {0} Live", live);
                }
                Console.WriteLine();
                if (live == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Game Over \nMy Secret Word is [ {0} ]", secretword);
                    break;
                }
            }
            Console.ReadKey();
        }
        static bool IsWord(string secreword, List<string> letterGuessed)
        {
            bool word = false;
            for (int i = 0; i < secreword.Length; i++)
            {
                string c = Convert.ToString(secreword[i]);
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }              
                else
                {                   
                    return word = false;
                }
            }
            return word;
        } 
        static string Isletter(string secretword, List<string> letterGuessed)
        {
            string correctletters = "";
            for (int i = 0; i < secretword.Length; i++)
            {
                string c = Convert.ToString(secretword[i]);
                if (letterGuessed.Contains(c))
                {                   
                    correctletters += c;
                }
                else
                {                  
                    correctletters += "_ ";
                }
            }
            return correctletters;
        }
        static void GetAlphabet(string letters)
        {
            List<string> alphabet = new List<string>();
            for (int i = 1; i <= 26; i++)
            {
                char alpha = Convert.ToChar(i + 96);
                alphabet.Add(Convert.ToString(alpha));
            }
            int num = 49;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Letters Left are :");
            for (int i = 0; i < num; i++)
            {
                if (letters.Contains(letters))
                {
                    alphabet.Remove(letters);
                    num -= 1;
                }
                Console.Write("[" + alphabet[i] + "] ");
            }
            Console.WriteLine();
        }       
    }
}