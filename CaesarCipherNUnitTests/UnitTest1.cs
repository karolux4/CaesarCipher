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
            Assert.AreEqual("DEF", c.Encrypt("ABC"));
            Assert.AreEqual("XXX", c.Encrypt("UUU"));
            Assert.AreEqual("DCB", c.Encrypt("AZY"));


        }

        [Test]
        public void DecryptTest()
        {
            // Classic Caesar Cipher
            Cipher c = new Cipher(3);
            Assert.AreEqual("ABC", c.Decrypt("DEF"));
            Assert.AreEqual("UUU", c.Decrypt("XXX"));
            Assert.AreEqual("AZY", c.Decrypt("DCB"));
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
                Assert.AreEqual(text, c.Decrypt(c.Encrypt(text)));
                
            }
        }

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