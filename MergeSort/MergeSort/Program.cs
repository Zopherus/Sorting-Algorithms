using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MergeSort
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
				MergeSort(numbers, 0 , numbers.Length);
				Console.WriteLine(ArrayToString(numbers));
			}
			Console.WriteLine(DateTime.Now.Subtract(time).Seconds.ToString() + " " + DateTime.Now.Subtract(time).Milliseconds.ToString());
			Console.ReadLine();
		}

		static void MergeSort(int[] numbers, int start, int end)
		{
			if (end - start <= 1)
				return;
			MergeSort(numbers, start, (start + end) / 2);
			MergeSort(numbers, (start + end) / 2, end);
			Merge(numbers, start, end);
		}

		static void Merge(int[] numbers, int start, int end)
		{
			int middle = (start + end) / 2;
			int leftHalf = start;
			int rightHalf = middle;
			int[] resultArray = new int[end - start];
			for (int counter = 0; counter < end - start; counter++)
			{
				if (leftHalf < middle && (rightHalf >= end ||numbers[leftHalf] < numbers[rightHalf]))
				{
					resultArray[counter] = numbers[leftHalf];
					leftHalf++;
				}
				else
				{
					resultArray[counter] = numbers[rightHalf];
					rightHalf++;
				}
			}
			Array.Copy(resultArray, 0, numbers, start, end - start);
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
