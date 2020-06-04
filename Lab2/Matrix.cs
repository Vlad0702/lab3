using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Matrix
    {

        public int Rows;
        public int Columns;

        public Matrix(int[] size, int[,] members)
        {
            Size = size;
            Members = members;
            Rows = Members.GetUpperBound(0) + 1;
            Columns = Members.Length / Rows;
            if (Columns != size[1] || Rows != size[0])
                throw new Exception("Размерность матрицы не соответствует заданному");
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{Members[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine(); Console.WriteLine();
        }

        public bool IsUnit()
        {
            if (Rows != Columns)
            {
                return false;
            }

            for (int i = 0; i < Rows; i++)
            {
                if (Members[i, i] != 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.Size[0] != B.Size[0] || A.Size[1] != B.Size[1])
            {
                throw new Exception("Размерности матриц не совпадают");
            }

            int[,] newMatrix = new int[A.Columns, A.Rows];

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    newMatrix[i, j] = A.Members[i, j] + B.Members[i, j];
                }
            }

            return new Matrix(A.Size, newMatrix);
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.Columns != B.Columns || A.Rows != B.Rows)
            {
                throw new Exception("Размерности матриц не совпадают");
            }

            int[,] newMatrix = new int[A.Columns, A.Rows];

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    newMatrix[i, j] = A.Members[i, j] - B.Members[i, j];
                }
            }

            return new Matrix(A.Size, newMatrix);
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Columns != B.Rows)
            {
                throw new Exception("Размерности матриц не совпадают");
            }

            int[,] newMatrix = new int[A.Rows, B.Columns];

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Columns; j++)
                {
                    for (int k = 0; k < A.Columns; k++)
                    {
                        newMatrix[i, j] += A.Members[i, k] * B.Members[k, j];
                    }
                }
            }

            return new Matrix(new int[] { A.Rows, B.Columns }, newMatrix);
        }

        public static Matrix operator *(Matrix A, int b)
        {
            return MultyByNum(A, b);
        }

        static Matrix MultyByNum(Matrix A, int b)
        {
            int[,] newMatrix = new int[A.Columns, A.Rows];

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    newMatrix[i, j] = A.Members[i, j] * b;
                }
            }

            return new Matrix(A.Size, newMatrix);
        }

        public static Matrix operator *(int a, Matrix B)
        {
            return MultyByNum(B, a);

        }


        public int[] Size { get; }
        public int[,] Members { get; set; }
    }
}
