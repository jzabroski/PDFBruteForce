using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;

namespace PDF_Brute_Force
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string inputFile = Path.Combine(workingFolder, "test.pdf");
            string outputFile = Path.Combine(workingFolder, "test_dec.pdf");

            string seed = "Example";
            List<string> passwords = GeneratePasswords(seed);
            foreach(string password in passwords)    
            {
                try
                {
                    PdfReader reader = new PdfReader(inputFile, new System.Text.ASCIIEncoding().GetBytes(password));
                    Console.WriteLine(password);
                    break;
                }
                catch
                {
                    // Console.WriteLine(err.Message);
                }
            }
            Console.ReadLine();
        }

        public static List<string> GeneratePasswords(string seed)
        {
            List<char> characters = Enumerable.Range('0', 'z' - 'A' + 1).Select(c => (char)c).ToList();

            List<string> passwords = new List<string>();
            passwords.Add(seed);
            for(int i = 0; i < seed.Length; i++)
            {
                foreach(char character in characters)
                {
                    char[] newPasswordChars = seed.ToCharArray();
                    newPasswordChars[i] = character;
                    string newPassword = new String(newPasswordChars);
                    passwords.Add(newPassword);
                }
            }

            return passwords;
        }
    }
}
