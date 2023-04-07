using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySome
{
    public class Doing
    {
        private static readonly object lockObject = new object();

        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                Thread leftThread = new Thread(() => QuickSort(array, left, pivot - 1));
                Thread rightThread = new Thread(() => QuickSort(array, pivot + 1, right));
                leftThread.Start();
                rightThread.Start();
                leftThread.Join();
                rightThread.Join();
            }
        }

        public static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        public static void Swap(int[] array, int i, int j)
        {
            lock (lockObject)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(1, 101);
            }
            return arr;
        }

    }
}
