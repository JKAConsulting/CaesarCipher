using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionCaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prg = new Program();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter message text: ");
            string message = Console.ReadLine();
            Console.WriteLine("Enter 1 for standard operation, or 2 for exhaustive decipher search: ");
            string opChoice = Console.ReadLine();

            Console.Clear();

            if (opChoice == "1")
            {                
                Console.WriteLine("Enter key: ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter e to encipher or d to decipher: ");
                string operation = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                //prg.CalcPower();

                string cipherText = prg.EncryptText(message, key, operation);
                Console.WriteLine("Result: " + cipherText);

            } else
            {
                if (opChoice == "2")
                {
                    //USE THIS FOR EXHAUSTIVE SEARCH. LOOPS THRU ALL POSSIBLE KEYS.  CHECK OUTPUT FOR LEGIT OUTPUT AND DERIVE KEY
                    for (int j = 0; j <= 26; j++)
                    {
                        string cipherText = "Key is: " + j.ToString() + " -->" + prg.EncryptText(message, j, "d");

                        Console.WriteLine(cipherText);
                    }
                }
            }
        }

        private void CalcPower()
        {
            double t1 = Math.Pow(7, 53);
            double t2 = t1 % 77;
            double t3 = Math.Pow(t2, 37);
            double t4 = t3 % 77;

        }

        private string EncryptText(string m, int k, string op)
        {
            string cipherTextResult = string.Empty;
            
            char[] b = m.ToCharArray();
            
            foreach (char x in b)
            {
                if (!x.Equals(' '))
                {
                    char cipherChar = GetCipherChar(x, k, op);
                    cipherTextResult = (cipherTextResult + cipherChar.ToString()).ToUpper();
                } else
                {
                    cipherTextResult = (cipherTextResult + ' ');
                }
            }

            return cipherTextResult;        
        }

        private char GetCipherChar(char c, int k, string op)
        {            
            char[] alphaArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();

            int currPos = Array.IndexOf(alphaArray, Char.ToLower(c));
            int newPos;
            if (op == "e")
            {
                newPos = currPos + k;

                if (newPos >= alphaArray.Length)
                {
                    newPos = newPos % 26;
                }

            } else
            {
                newPos = (26 + (currPos - k)) % 26;
            }
            
            return alphaArray[newPos];
            
        }
    }
}
