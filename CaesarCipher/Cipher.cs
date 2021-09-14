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

            string ciphertext="";

            foreach (char letter in plaintext)
            {
                // check if letter is from alphabet
                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
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
                else
                {
                    // special characters are not shifted
                    ciphertext += letter;
                }
            }
            return ciphertext;
        }

        /*
         * Method that decrypts cyphertext using Caesar cipher (shift by n)
         * and returns plaintext
        */
        public string Decrypt(string ciphertext)
        {

            string plaintext = "";

            foreach (char letter in ciphertext)
            {
                // check if letter is from alphabet
                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
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
                else
                {
                    // special characters are not shifted
                    plaintext += letter;
                }
            }
            return plaintext;

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
