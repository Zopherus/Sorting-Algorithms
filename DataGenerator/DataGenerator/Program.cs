using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter("C:/Users/Eric/Desktop/data.txt");
            for (int range = 5; range < 10000; range++)
            {
                streamWriter.WriteLine(ArrayToString(GenerateData(range)));
            }
            streamWriter.Close();
        }



        static int[] GenerateData(int range)
        {
            Random random = new Random();
            Enumerable.Repeat(1, 1);
            int[] numbers = Enumerable.Range(0, range).ToArray<int>();

            // Randomize the array

            // Start at the end of the array
            int position = numbers.Length;
            while (position > 1)
            {
                // Creates a random int from 0 to position, not including position to swap to
                // Decreases position by 1
                int swapPosition = random.Next(position--);

                // Swap the current position with another random position
                int temp = numbers[position];
                numbers[position] = numbers[swapPosition];
                numbers[swapPosition] = temp;
            }
            return numbers;
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
