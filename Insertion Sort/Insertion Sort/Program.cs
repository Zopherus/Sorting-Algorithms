using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Insertion_Sort
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
                InsertionSort(numbers);
                Console.WriteLine(ArrayToString(numbers));
            }
            Console.WriteLine(DateTime.Now.Subtract(time).Seconds.ToString() + " " + DateTime.Now.Subtract(time).Milliseconds.ToString());
            Console.ReadLine();
        }

        static void InsertionSort(int[] array)
        {
            // Loop through the array starting from the second value
            for (int counter = 1; counter < array.Length; counter++)
            {
                for (int loop = 0; loop < counter; loop++)
                {
                    if (array[loop] > array[counter])
                        Insert(array, counter, loop);
                }
            }
        }

        static void Insert(int[] array, int position, int positionToMove)
        {
            int number = array[position];
            for (int counter = position - 1; counter >= positionToMove; counter--)
            {
                array[counter + 1] = array[counter]; 
            }
            array[positionToMove] = number;
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
