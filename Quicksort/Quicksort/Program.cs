using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Quicksort
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
                Quicksort(numbers, 0, numbers.Length);
                Console.WriteLine(ArrayToString(numbers));
            }
            Console.WriteLine(DateTime.Now.Subtract(time).Seconds.ToString() + " " + DateTime.Now.Subtract(time).Milliseconds.ToString());
            Console.ReadLine();
        }

        // Includes start, doesn't include end
        static void Quicksort(int[] array, int start, int end)
        {
            // If the length of the array is 0 or 1, the array is sorted so stop recursion
            if (end - start == 1 || end - start == 0)
                return;

            int pivotPosition = Partition(array, start, end);
            Quicksort(array, start, pivotPosition);
            Quicksort(array, pivotPosition + 1, end);
        }



        // Splits the array into two parts
        // First part less than pivot and second part greater than
        // Includes start, doesn't include end
        static int Partition(int[] array, int start, int end)
        {
            // Set the pivot value as the last element of array
            // All other values will be 'pivoted' around this value
            int pivot = array[end - 1];

            // The next position for each half to fill
            int lesserHalf = start, greaterHalf = start;
            

            // Loop through all of the array except the last pivot value
            for (int counter = start; counter < end - 1; counter++)
            {
                if (array[counter] <= pivot)
                {
                    Swap(array, counter, lesserHalf);
                    lesserHalf++;
                    greaterHalf++;
                }
                else
                {
                    Swap(array, counter, greaterHalf);
                    greaterHalf++;
                }
            }
            Swap(array, end - 1, lesserHalf);
            return lesserHalf;
        }


        // Swaps two values in an array
        static void Swap(int[] array, int firstPosition, int secondPosition)
        {
            //
            int holder = array[firstPosition];
            array[firstPosition] = array[secondPosition];
            array[secondPosition] = holder;
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
