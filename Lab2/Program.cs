using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix A = new Matrix(new int[] { 3, 3 }, new int[,] { { 1, 2, 2 }, { 0, 3, 1 }, { 1, 0, 0 } });
            Matrix B = new Matrix(new int[] { 3, 3 }, new int[,] { { 0, 0, 1 }, { -1/4, -1/2, 1/4 }, { 3/4, -1/2, -7/10 } });

            Console.WriteLine("Матрица А:");
            A.Print();
            Console.WriteLine("Матрица B:");
            B.Print();
            Console.WriteLine($"Мацтрица А еденичная: {A.IsUnit().ToString()}");
            Console.WriteLine($"Мацтрица B еденичная: {B.IsUnit().ToString()}");

            Matrix D = 3 * A * B + (A - B) * A;

            Console.WriteLine("\nМатрица D (3 * A * B + (A - B) * A):");
            D.Print();
            Console.WriteLine($"Мацтрица D еденичная: {D.IsUnit().ToString()}");

            Console.ReadKey();
        }
    }
}
