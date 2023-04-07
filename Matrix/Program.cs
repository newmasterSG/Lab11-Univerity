namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] matrixA = { { 1, 2 }, { 3, 4 } };
            int[,] matrixB = { { 5, 6 }, { 7, 8 } };
            int[,] resultMatrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

            Thread t1 = new Thread(() => MatrixA.MultiplyMatrices(matrixA, matrixB, resultMatrix, 0, matrixA.GetLength(0) / 2));
            Thread t2 = new Thread(() => MatrixA.MultiplyMatrices(matrixA, matrixB, resultMatrix, matrixA.GetLength(0) / 2, matrixA.GetLength(0)));

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine("Result matrix:");
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}