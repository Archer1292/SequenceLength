using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace SequenceLength
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Calculation of the maximum length of the sequence 1.");

                StreamReader sr = new StreamReader("input.txt");
                string s = sr.ReadLine();
                sr.Close();
                byte[] arr = new byte[s.Length];
                for (int i = 0; i < s.Length; i++) arr[i] = (byte)Char.GetNumericValue(s[i]);

                int lenght = ContLength(arr);

                StreamWriter sw = new StreamWriter("output.txt", false);
                sw.Write(lenght);
                sw.Close();
                Console.WriteLine("The calculation is over.");
                Console.ReadKey();
            }            
            catch  (Exception e) { Console.WriteLine(e.Message);Console.ReadKey(); }
        }

        private static int ContLength(byte[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("В метод ContLength() не передан масив.");
                return 0;
            }
            if (arr.Length == 0) return 0;
            int max = 0, tempLenght = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1) { tempLenght++; }
                else
                {
                    max = Math.Max(max, tempLenght);
                    tempLenght = 0;
                }
            }
            if (arr[arr.Length - 1] == 1) max = Math.Max(max, tempLenght);
            return max;
        }
    }
}
