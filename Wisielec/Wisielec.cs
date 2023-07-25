using System;

namespace Wisielec
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hangmanImages = {
                @"
  +---+
  |   |
      |
      |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
                @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
            };

            string[] words = File.ReadAllLines("words.txt");
            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)];
            char[] guessedLetters = new char[wordToGuess.Length];
            int attempts = 0;
            bool isGameOver = false;

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }

            Console.WriteLine("Witaj w grze Wisielec!");
            Console.WriteLine("Zgadnij słowo: " + new string(guessedLetters));

            while (!isGameOver)
            {
                Console.WriteLine(hangmanImages[attempts]);

                Console.Write("Podaj literę: ");
                char input = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                bool isCorrectGuess = false;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == input)
                    {
                        guessedLetters[i] = input;
                        isCorrectGuess = true;
                    }
                }

                if (!isCorrectGuess)
                {
                    attempts++;
                }

                Console.WriteLine("Zgadnięte litery: " + new string(guessedLetters));

                if (Array.IndexOf(guessedLetters, '_') == -1)
                {
                    Console.WriteLine("Brawo! Odgadłeś słowo: " + wordToGuess);
                    isGameOver = true;
                }
                else if (attempts >= hangmanImages.Length)
                {
                    Console.WriteLine("Przegrałeś! Nie udało Ci się odgadnąć słowa.");
                    Console.WriteLine("Poprawne słowo to: " + wordToGuess);
                    isGameOver = true;
                }
            }
        }
    }
}