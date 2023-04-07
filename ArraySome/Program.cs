namespace ArraySome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Doing.GenerateRandomArray(10);
            Console.WriteLine("Unsorted array: " + string.Join(", ", array));
            Console.WriteLine();

            Doing.QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("Sorted array: " + string.Join(", ", array));

            Console.ReadLine();
        }
    }
}