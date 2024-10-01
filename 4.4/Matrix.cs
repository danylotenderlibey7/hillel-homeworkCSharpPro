using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._4
{
    public class Matrix
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private double[,] elements;

        public Matrix(int rows, int columns)
        {
            Rows = rows;   
            Columns = columns;
            elements = new double[rows, columns];
        }
        public double this[int row, int col]
        {
            get => elements[row, col];
            set => elements[row, col] = value;
        }
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            int maxRows = Math.Max(matrix1.Rows, matrix2.Rows);
            int maxCols = Math.Max(matrix1.Columns, matrix2.Columns);
            Matrix result = new Matrix(maxRows, maxCols);

            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxCols; j++)
                {
                    double value1 = (i < matrix1.Rows && j < matrix1.Columns) ? matrix1[i, j] : 0;
                    double value2 = (i < matrix2.Rows && j < matrix2.Columns) ? matrix2[i, j] : 0;
                    result[i, j] = value1 + value2;
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            int maxRows = Math.Max(matrix1.Rows, matrix2.Rows);
            int maxCols = Math.Max(matrix1.Columns, matrix2.Columns);
            Matrix result = new Matrix(maxRows, maxCols);

            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxCols; j++)
                {
                    double value1 = (i < matrix1.Rows && j < matrix1.Columns) ? matrix1[i, j] : 0;
                    double value2 = (i < matrix2.Rows && j < matrix2.Columns) ? matrix2[i, j] : 0;
                    result[i, j] = value1 - value2;
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            //if (matrix1.Columns != matrix2.Rows)
            //   throw new ArgumentException("Number of columns in the first matrix must match the number of rows in the second matrix.");
            
            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        if (k < matrix1.Columns && k < matrix2.Rows)
                        {
                            result[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }
            return result;
        }
        public static bool operator ==(Matrix m1, Matrix m2) => m1.Equals(m2);
        public static bool operator !=(Matrix m1, Matrix m2) => !m1.Equals(m2);

        public override int GetHashCode()
        {
            return elements.GetHashCode();
        }
        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{elements[i, j],8}");
                }
                Console.WriteLine();
            }
        }
    }
}
