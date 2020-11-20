using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Matrix
    {
        int rows, columns;
        int[,] mass;

        public int Rows
        {
            get { return rows; }
            private set
            {
                if (value > 0)
                    rows = value;
            }
        }
        public int Columns
        {
            get { return columns; }
            private set
            {
                if (value > 0)
                    columns = value;
            }
        }
        // Индексатор для объектов класса Matrix
        public int this[int i, int j]
        {
            get { return mass[i, j]; }
            set { mass[i, j] = value; }
        }
        // Конструктор класса Matrix
        public Matrix(int numberOfRows, int numberOfColumns)
        {
            Rows = numberOfRows;
            Columns = numberOfColumns;
            mass = new int[Rows, Columns];
        }
        // Перегрузка оператора '+' для возможности операции сложения матриц
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix resultMatrix = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                {
                    resultMatrix[i, j] = m1[i, j] + m2[i, j];
                    if (resultMatrix[i, j] > Int32.MaxValue)
                        resultMatrix[i, j] = Int32.MaxValue;
                }
            return resultMatrix;
        }
        // Перегрузка оператора '-' для возможности операции вычитания матриц
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix resultMatrix = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                {
                    resultMatrix[i, j] = m1[i, j] - m2[i, j];
                    if (resultMatrix[i, j] < Int32.MinValue)
                        resultMatrix[i, j] = Int32.MinValue;
                }
            return resultMatrix;
        }
        // Перегрузка оператора '*' для возможности операции произведения матриц
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix resultMatrix = new Matrix(m1.Rows, m2.Columns);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m2.Columns; j++)
                    for (int k = 0; k < m1.Columns; k++)
                    {
                        resultMatrix[i, j] += m1[i, k] * m2[k, j];
                        if (resultMatrix[i, j] > Int32.MaxValue)
                            resultMatrix[i, j] = Int32.MaxValue;
                    }

            return resultMatrix;
        }
        // Возвращает матрицу, в которой значения рядов объекта m
        // заменяются значениями его столбцов и наоборот
        public static Matrix flipTheMatrix(Matrix m)
        {
            Matrix result = new Matrix(m.Columns, m.Rows);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = m[j, i];
            return result;
        }
        // Возвращает матрицу, каждое значение которой умножено
        // на значение параметра x.
        public void multiTheMatrix(int multiplier)
        {            
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                {
                    mass[i, j] *= multiplier;
                    if (mass[i, j] > Int32.MaxValue)
                        mass[i, j] = Int32.MaxValue;
                }
        }
    }
}
