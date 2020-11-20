using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Математический_помощник
{
    class MatrixView
    {
        TextBox[,] mtrxTB;
        public TextBox this[int i, int j]
        {
            get { return mtrxTB[i, j]; }
            set { mtrxTB[i, j] = value; }
        }
        // Конструктор создает многомерный массив объектов класса TextBox,
        // еквивалентный массиву объекта класса matrix
        public MatrixView(Matrix matrix)
        {
            mtrxTB = new TextBox[matrix.Rows, matrix.Columns];
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                {
                    mtrxTB[i, j] = new TextBox();
                    mtrxTB[i, j].Size = new System.Drawing.Size(50, 25);
                    mtrxTB[i, j].MaxLength = 7;
                }
        }
    }
}
