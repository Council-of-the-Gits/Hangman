using System;
using System.IO;
using System.Collections.Generic;

namespace assignment2
{
    class Program
    {
        const int ListLength = 20;

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }

            string filename = args[0];

            Program myProgram = new Program();

            myProgram.Start(filename);
        }

        void Start(string filename)
        {
            // Creating a new instance of the class HangmanGame
            HangmanGame hangman = new HangmanGame();

            // Declaring the list words and filling it with the ListOfWords method
            List<string> words = ListOfWords(filename);

            // Selecting a word form the list words via the SelectWord method
            string selectedWord = SelectWord(words);

            // Initializing the game
            hangman.Init(selectedWord);

            // Activating the game and printing win or lose 
            if (PlayHangman(hangman))
            {
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine($"Too bad, you did not guess the word({hangman.secretWord})");
            }

            // Wait until the user gives input
            Console.ReadKey();
        }

        bool PlayHangman(HangmanGame hangman)
        {
            // Declaring amount of attemps
            int Attemps = 8;

            // Declaring a list for the entered letters
            List<char> enteredLetters = new List<char>();

            // Declaring a list for the already existing letters
            List<char> blacklistLetters = new List<char>();

            //Checks if the word has been guessed
            do
            {
                // Read letter and check if they have been used already
                char letter = ReadLetter(blacklistLetters);

                // Adding the letter to the entered List
                enteredLetters.Add(letter);

                // Checks if the letter is in the secret word
                if (hangman.ContainsLetter(letter))
                {
                    // Processes the letter if it is in the secret word
                    hangman.ProcessLetter(letter);
                }
                else
                {
                    // Decreasing the attempts amount when letter not in secret word
                    Attemps--;
                }

                // Displays the entered letters
                DisplayLetters(enteredLetters);

                // Displays the amount attempts left
                Console.WriteLine($"Attempts left: {Attemps}");

                // Displays the so-far guessed word 
                DisplayWord(hangman.guessedWord);

                Console.WriteLine();

            } while (!hangman.IsGuessed() && Attemps != 0);

            // Checking if the user won by guessing or if he is out of attempts
            if (Attemps == 0)
            {
                return false;
            }
            return true;
        }

        char ReadLetter(List<char> blacklistLetters)
        {
            char letter;

            // Runs the code when a letter is in the blacklist
            do
            {
                // Ask user for input
                Console.Write("Enter a letter to guess: ");

                // Read input letters from user
                letter = Convert.ToChar(Console.ReadLine());

            } while (blacklistLetters.Contains(letter));

            // Add letter to the list
            blacklistLetters.Add(letter);

            // Return the letter
            return letter;
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write($"Entered letters: ");

            // Prints all the guessed letters
            foreach (char c in letters)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }

        void DisplayWord(string word)
        {
            Console.WriteLine();

            // Prints all letters of the word
            foreach (char c in word)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }

        string SelectWord(List<string> words)
        {
            Random rnd = new Random();

            // Creating a random value between 0 and 20
            int randomNumber = rnd.Next(0, ListLength);

            // Selecting a random word from the list words
            string selectedWord = words[randomNumber];

            // Returning the selected word
            return selectedWord;
        }

        List<string> ListOfWords(string filename)
        {
            // Declaring the list ListOfWords
            List<string> ListOfWords = new List<string>();

            // Opening the files with words
            StreamReader reader = new StreamReader(filename);

            // Adding all elements to the list
            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();

                if (word.Length >= 3)
                {
                    ListOfWords.Add(word);
                }
            }

            reader.Close();

            // Returing the filled list
            return ListOfWords;
        }
    }
}