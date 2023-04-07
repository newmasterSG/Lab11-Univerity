using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixA
    {
        static Semaphore semaphore = new Semaphore(1, 1);
        static object lockObject = new object();

        public static void MultiplyMatrices(int[,] matrixA, int[,] matrixB, int[,] resultMatrix, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }

                    lock (lockObject)
                    {
                        semaphore.WaitOne();
                        resultMatrix[i, j] = sum;
                        semaphore.Release();
                    }
                }
            }
        }
    }
}
