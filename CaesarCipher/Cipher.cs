using System;
using System.Text.RegularExpressions;

namespace CaesarCipher
{
    public class Cipher
    {
        // shift number
        private int n;

        /*
         * Caeser cipher constructor for shift by n
         */
        public Cipher(int n)
        {
            this.n = n;
        }

        /*
         * Method that encrypts plaintext using Caeser cipher (shift by n)
         * and returns ciphertext
         */
        public string Encrypt(string plaintext)
        {
            //Check if contains only latin letters
            if (!CheckIfContainsOnlyLetters(plaintext))
            {
                return null;
            }

            string ciphertext="";


            foreach (char letter in plaintext)
            {
                // ASCII number for 'a'
                int start = 97;
                if (Char.IsUpper(letter))
                {
                    // ASCII number for 'A'
                    start = 65;
                }
                
                // shift letter by n and recalculate new ASCII code
                ciphertext += (char)(mod((((int)letter - start) + n), 26) + start);
            }
            return ciphertext;
        }

        /*
         * Method that decrypts cyphertext using Caesar cipher (shift by n)
         * and returns plaintext
        */
        public string Decrypt(string ciphertext)
        {
            //Check if contains only latin letters
            if (!CheckIfContainsOnlyLetters(ciphertext))
            {
                return null;
            }


            string plaintext = "";


            foreach (char letter in ciphertext)
            {
                // ASCII number for 'a'
                int start = 97;
                if (Char.IsUpper(letter))
                {
                    // ASCII number for 'A'
                    start = 65;
                }

                // shift letter by n and recalculate new ASCII code
                plaintext += (char)(mod((((int)letter - start) - n), 26) + start);
            }
            return plaintext;

        }

        /*
         * Mehtod that checks if input contains non-latin letters
         */
        private bool CheckIfContainsOnlyLetters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]*$");
        }

        /*
         * Custom modulo operation because negative%m returns negative
         */
        private int mod(int a, int m)
        {
            int r = a % m;
            return r < 0 ? r + m : r;
        }
    }
}
