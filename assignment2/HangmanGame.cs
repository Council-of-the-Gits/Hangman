using System;
using System.IO;
using System.Collections.Generic;

namespace assignment2
{
    public class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string secretWord)
        {
            // Creating the guessed word
            foreach (char c in secretWord)
            {
                guessedWord = string.Concat(guessedWord, ".");
            }

            // Saving the secret word to the class
            this.secretWord = secretWord;
            Console.WriteLine();
        }

        public bool ContainsLetter(char letter)
        {
            // Checking if the guessed letter is in the secret word
            if (secretWord.Contains($"{letter}"))
            {
                return true;
            }
            return false;
        }

        public void ProcessLetter(char letter)
        {
            for (int i = 0; i < secretWord.Length; i++)
            {
                // Replacing the . for the letter
                if (secretWord[i] == letter)
                {
                    guessedWord = guessedWord.Remove(i, 1);
                    guessedWord = guessedWord.Insert(i, $"{letter}");
                }
            }
        }

        public bool IsGuessed()
        {
            // Checks if the secret word is the guessed word
            if (secretWord == guessedWord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}