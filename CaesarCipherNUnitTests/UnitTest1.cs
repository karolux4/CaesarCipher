using CaesarCipher;
using NUnit.Framework;
using System;

namespace CaesarCipherNUnitTests
{
    public class Tests
    {

        [Test]
        public void EncryptTest()
        {
            // Classic Caesar Cipher
            Cipher c = new Cipher(3);
            Assert.AreEqual("DEf", c.Encrypt("ABc"));
            Assert.AreEqual("XXX", c.Encrypt("UUU"));
            Assert.AreEqual("DcB", c.Encrypt("AzY"));

            // Caeser Cipher with shift of 5
            c = new Cipher(5);
            Assert.AreEqual("HFJXFW HNUMJW!", c.Encrypt("CAESAR CIPHER!"));
            Assert.AreEqual("ABCDE", c.Encrypt("VWXYZ"));

            // Caeser Cipher with shift of 0 remains the same
            c = new Cipher(0);
            Assert.AreEqual("JhuY", c.Encrypt("JhuY"));

            // Caeser Cipher with shift of 1 is equal to shift of 27
            c = new Cipher(1);
            Cipher c1 = new Cipher(27);
            Assert.AreEqual(c1.Encrypt("Rome, Italy"), c.Encrypt("Rome, Italy"));

        }

        [Test]
        public void DecryptTest()
        {
            // Classic Caesar Cipher
            Cipher c = new Cipher(3);
            Assert.AreEqual("ABC", c.Decrypt("DEF"));
            Assert.AreEqual("OOPP", c.Decrypt("RRSS"));
            Assert.AreEqual("Rome", c.Decrypt("Urph"));

            // Caeser Cipher with shift of 7
            c = new Cipher(7);
            Assert.AreEqual("Rome empire", c.Decrypt("Yvtl ltwpyl"));
            Assert.AreEqual("Julius", c.Decrypt("Qbspbz"));

            // Caeser Cipher with shift of 0 remains the same
            c = new Cipher(0);
            Assert.AreEqual("JhuY", c.Decrypt("JhuY"));

            // Caeser Cipher with shift of 1 is equal to shift of 27
            c = new Cipher(1);
            Cipher c1 = new Cipher(27);
            Assert.AreEqual(c1.Decrypt("Cryptography"), c.Decrypt("Cryptography"));
        }

        [Test]
        public void CipherTest()
        {
            for(int i = 0; i < 1000; i++)
            {
                int n = new Random().Next(1000);
                int length = new Random().Next(1, 100);
                Cipher c = new Cipher(n);
                string text = RandomString(length);
                // Check that encrypted and then decrypted text remains the same
                Assert.AreEqual(text, c.Decrypt(c.Encrypt(text)));
                
            }
        }

        /*
         * Helper method to generate random latin character strings to perform testing
         */
        public string RandomString(int length)
        {
            string text = "";
            Random r = new Random();
            for(int i = 0; i<length; i++)
            {
                char letter = (char)((65 + r.Next(0, 26)) + 32 * (new Random().Next(0, 2)));
                text += letter;

            }
            return text;
        }
    }
}