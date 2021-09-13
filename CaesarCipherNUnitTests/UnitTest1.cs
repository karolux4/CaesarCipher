using CaesarCipher;
using NUnit.Framework;

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
            Assert.Pass();
        }
    }
}