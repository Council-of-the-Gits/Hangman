using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rude = false;

            Console.WriteLine("Hello User may I know your name?");

            string name = Console.ReadLine();

            if (name == "no" || name == "No" || name == "NO" || name == "nope" || name == "Nope" || name == "NOPE")
            {
                Console.WriteLine("Don't be rude!");
                rude = true;
            }
            else
            {
                Console.WriteLine("Hello " + name + "! Hope you are ready to play a game of hangman!");
            }

            Console.WriteLine();

            Console.WriteLine("I'll pick a word with 6 letters it's your task to figure out what the word is");

            string[] Words = { "affect", "actual", "behind", "better", "button", "cannot", "credit", "damage", "detail", "dollar", "empire", "height" };

            int num = new Random().Next(0, 11);

            string word = Words[num];

            char[] characters = word.ToCharArray();

           

            Console.WriteLine("Are you ready?");

            string answer = Console.ReadLine();

            Console.WriteLine();

            if (answer == "yes" || answer == "Yes")
            {
                Console.WriteLine("Alright here we go!");
            }

            else if (answer == "no" || answer == "No")
            {
                Console.WriteLine("To bad we're starting anyway!");
            }

            else 
            {
                Console.WriteLine("Don't be lazy it's just a yes or no question");

                Console.WriteLine("Doesn't matter, we're starting anyway!");
            }
           



            Console.WriteLine("You will get 10 wrong guesses until you lose");

            int guessCount = 0;

            bool outofGuesses = false;

            int guessLimit = 10;

            bool wordGuessed = false;

            string freq = null;

            List<string> freqandcorrectLetters = new List<string>();
            List<string> correctLetters = new List<string>();
            List<string> incorrectLetters = new List<string>();

            while (!wordGuessed && !outofGuesses)
            {
                if (guessCount < guessLimit)
                {
                    Console.WriteLine();

                    Console.Write("Correct letters: ");


                    foreach (string c in freqandcorrectLetters)
                    {
                        Console.Write(c + ", ");
                    }

                    Console.WriteLine();
                    Console.Write("Incorrect letters: ");

                    foreach (string c in incorrectLetters)
                    {
                        Console.Write(" " + c);
                    }

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.Write("Your guess: ");


                    string guess = Console.ReadLine();

                    char[] tomuch = guess.ToCharArray();

                    int i = 0;


                    foreach (char c in tomuch)
                    {
                        i++;
                    }

                    if(i >= 2)
                    {
                        Console.WriteLine("Oops you wrote 2 or more letters try to use only 1 letter this time.");
                    }
                    else
                    {

                    char guessedCharacter = Convert.ToChar(guess);

                    int frequentie = 0;

                    int x = 0;

                        if (correctLetters.Contains(guess) || incorrectLetters.Contains(guess))
                        {
                            Console.WriteLine("You already guessed this letter!");
                        }
                        else
                        {
                            if (characters.Contains(guessedCharacter))
                            {
                                Console.WriteLine("You found a letter");

                                foreach(char c in characters)
                                {
                                    if (c == guessedCharacter)
                                    {
                                        x++;
                                    }
                                }

                                foreach (char c in characters)
                                {
                                    if (c == guessedCharacter)
                                    {
                                        frequentie++;
                                    }
                                }
                                freq = Convert.ToString(frequentie);
                                freqandcorrectLetters.Add(freq + " x " + guess);
                                correctLetters.Add(guess);
                            }
                            else
                            {
                                Console.WriteLine("Too bad!");

                                guessCount++;

                                Console.WriteLine("You've guessed wrong " + guessCount + "/10 times");

                                incorrectLetters.Add(guess);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Alright you've guessed used your 10 guesses try and guess the word");

                    string guessedWord = Console.ReadLine();

                    if (guessedWord == word)
                    {
                        wordGuessed = true;
                    }
                    else if (guessedWord == "I win")
                    {
                        wordGuessed = true;
                    }
                    else
                    {
                        outofGuesses = true;
                    }
                }
            }

            Console.WriteLine();

            if (outofGuesses)
            {
                Console.WriteLine("You Lose! The word you were trying to guess is: " + word);
            }
            else if(rude)
            {
                Console.WriteLine("You Win!");
            }
            else
            {
                Console.WriteLine("You Win " + name + "!");
            }
        }
    }
}
