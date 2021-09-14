using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main()
        {
            int n, mode;
            string output = null;

            Console.WriteLine("Welcome, please enter shift number (classic Caeser uses 3): ");
            while (!Int32.TryParse(Console.ReadLine(), out n ))
            {
                Console.WriteLine("Enter valid number");
            }

            Console.WriteLine("Enter mode number: [1] Encrypt, [2] Decrypt");
            while (!Int32.TryParse(Console.ReadLine(), out mode)||(mode!=1&&mode!=2))
            {
                Console.WriteLine("Enter valid number");
            }

            Console.WriteLine("Enter text: ");
            string input = Console.ReadLine();
            Cipher c = new Cipher(n);
            switch (mode)
            {
                case 1:
                   output = c.Encrypt(input);
                   break;
                case 2:
                   output = c.Decrypt(input);
                   break;
            }
            Console.WriteLine("Result: " + output);

        }
    }
}
