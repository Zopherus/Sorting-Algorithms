using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Bubblesort
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            StreamReader streamReader = new StreamReader("C:/Users/Eric/Desktop/data.txt");
            string line = "";
            while (true)
            {
                line = streamReader.ReadLine();
                if (line == null)
                    break;
                int[] numbers = StringToArray(line);
                Bubblesort(numbers);
                Console.WriteLine(ArrayToString(numbers));
            }
            Console.WriteLine(DateTime.Now.Subtract(time).Seconds.ToString() + " " + DateTime.Now.Subtract(time).Milliseconds.ToString());
            Console.ReadLine();
        }

        // Sorts an array of numbers
        static void Bubblesort(int[] array)
        {
            while (!IsSorted(array))
            {
                for (int counter = 0; counter < array.Length - 1; counter++)
                {
                    if (array[counter] > array[counter + 1])
                        Swap(array, counter, counter + 1);
                }
            }
        }


        // swaps values of two positions in the array
        static void Swap(int[] array, int firstPosition, int secondPosition)
        {
            int holder = array[firstPosition];
            array[firstPosition] = array[secondPosition];
            array[secondPosition] = holder;
        }


        // check if an array is sorted
        // All methods that return boolean should start with is/are
        static bool IsSorted(int[] array)
        {
            bool result = true;
            for (int counter = 0; counter < array.Length - 1; counter++)
            {
                if (array[counter] > array[counter + 1])
                    result = false;
            }
            return result;
        }


        static int[] StringToArray(string line)
        {
            string[] stringNumbers = line.Split(',');
            List<int> numbers = new List<int>();
            foreach (string number in stringNumbers)
            {
                numbers.Add(int.Parse(number.Trim()));
            }
            return numbers.ToArray();
        }

        static string ArrayToString(int[] array)
        {
            string result = "";
            for (int counter = 0; counter < array.Length - 1; counter++)
            {
                result += array[counter].ToString() + ", "; 
            }
            result += array[array.Length - 1];
            return result;
        }


    }
}
