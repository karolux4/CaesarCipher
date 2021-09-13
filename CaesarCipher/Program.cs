using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main()
        {
            Cipher c = new Cipher(3);
            
            Console.WriteLine(c.Encrypt("ABc"));
            Console.WriteLine(c.Decrypt("DeF"));
        }
    }
}
