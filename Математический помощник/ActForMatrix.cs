using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Математический_помощник
{
    public partial class ActForMatrix : Form
    {
        #region Закрытые поля класса ActForMatrix
        Matrix matrix1, matrix2, matrix3;
        MatrixView firstMatrix, secondMatrix, resultMatrix;        
        string[] labelTexts;
        string operation;
        int pointX, pointY;
        bool inputChecker;
        const string create = "CREATE";
        const string reset = "RESET";
        const string auto = "Auto";
        const string needless = "Needless";
        const string chooseN = "Choose an 'n'";
        const string chooseAction = "Choose an action to perform";
        const string comBoxActivate = "Click 'RESET' to activate";
        const string checkTheData = "Check the input data";
        const string matOneLabel = "First matrix";
        const string matTwoLabel = "Second matrix";
        const string matResultLabel = "Result matrix";
        #endregion
        #region Конструктор класса ActForMatrix
        // Конструктор класса ActForMatrix
        public ActForMatrix()
        {
            InitializeComponent();
            inputChecker = false;            
            labelTexts = new string[] {
                mat_one_row_lbl.Text,
                mat_one_col_lbl.Text,
                mat_two_row_lbl.Text,
                mat_two_col_lbl.Text };
            resetMatrixViewLabels();
        }
        #endregion
        #region Методы для конфигурации формы ActForMatrix
        void setConfiguration()
        {
            operation_comBox.Enabled = false;
            operation_lbl.Text = comBoxActivate;
            // Активирует кнопку "SOLVE" и меняет 
            // название кнопки create_btn на "RESET"
            solve_btn.Enabled = true;
            create_btn.Text = reset;
            switch (operation)
            {
                case "Summation":
                case "Difference":
                    mat_two_rows.Value = mat_one_rows.Value;
                    mat_two_cols.Value = mat_one_cols.Value;
                    displayFirstMatrix();
                    displaySecondMatrix(); break;
                case "Factum":
                    mat_two_rows.Value = mat_one_cols.Value;
                    displayFirstMatrix();
                    displaySecondMatrix(); break;
                case "MultiMatrix":
                case "Conjugation":
                    displayFirstMatrix(); break;
            }
        }
        /* Удаляет представления матриц matrixView и  
         * объекты класса Matrix из памяти. Возвращает состояния 
         * элементов формы ActForMatrix к исходным. */
        void resetConfiguration()
        {
            resetMatrixViewLabels();
            matrixDeletion(matrix1, firstMatrix);
            matrixDeletion(matrix2, secondMatrix);
            if (resultMatrix != null)
                matrixDeletion(matrix3, resultMatrix);
            resultMatrix = null;
            // Дезактивирует кнопку "SOLVE" и меняет
            // название кнопки create_btn на "CREATE"
            solve_btn.Enabled = false;
            create_btn.Text = create;
            operation_comBox.Enabled = true;
            operation_lbl.Text = chooseAction;
        }
        // Устанавливает свойства элементов 
        // NumericUpDown в исходное состояние
        void resetNumericUpDown()
        {
            mat_one_rows.Enabled =
            mat_one_cols.Enabled =
            mat_two_rows.Enabled =
            mat_two_cols.Enabled = false;
            mat_two_rows.Value =
            mat_two_rows.Minimum = 2;
            mat_two_rows.Maximum = 6;            
        }
        // Устанавливает исходный текст меток
        // для элементов NumericUpDown
        void resetRowsColsLabels()
        {
            mat_one_row_lbl.Text = labelTexts[0];
            mat_one_col_lbl.Text = labelTexts[1];
            mat_two_row_lbl.Text = labelTexts[2];
            mat_two_col_lbl.Text = labelTexts[3];
        }
        // Удаляет текстовые значения пометок label
        // для представлений матриц
        void resetMatrixViewLabels()
        {
            matOneView_lbl.Text =
            matTwoView_lbl.Text =
            matResultView_lbl.Text = string.Empty;
        }
        // Подготавливает форму для выбранного
        // действия над матрицами
        void formPreparations(string operation)
        {
            create_btn.Enabled =
            mat_one_rows.Enabled =
            mat_one_cols.Enabled = true;
            switch (operation)
            {
                case "Summation":
                case "Difference":
                    mat_two_row_lbl.Text = 
                    mat_two_col_lbl.Text = auto; break;
                case "Factum":
                    mat_two_cols.Enabled = true;
                    mat_two_row_lbl.Text = auto; break;
                case "MultiMatrix":
                    mat_two_rows.Enabled = true;
                    mat_two_row_lbl.Text = chooseN;
                    mat_two_col_lbl.Text = needless;
                    mat_two_rows.Minimum = 1;
                    mat_two_rows.Maximum = 100; break;
                case "Conjugation":
                    mat_two_row_lbl.Text =
                    mat_two_col_lbl.Text = needless; break;
            }
        }
        #endregion
        #region Методы для обаботки событий
        /* Вызывает методы resetLableText(), resetNumericUpDown().
         * Присваивает полю operation значение выбранного действия
         * над матрицами и передаёт его методу formPreparations(). */
        void matrixOp_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetRowsColsLabels();
            resetNumericUpDown();
            operation = operation_comBox.Text;
            formPreparations(operation);
        }
        /* Если текст кнопки create_btn равен "CREATE", то 
         * вызывает метод setConfiguration().
         * Если текст кнопки create_btn равен "RESET", то 
         * вызывает метод resetConfiguration(). */
        void create_btn_Click(object sender, EventArgs e)
        {
            if (create_btn.Text == create)
                setConfiguration();
            else
                resetConfiguration();
        }
        /* Устанавливает указанные значения в ячейки матриц для
         * последующей операции. При неправильных значениях меняет
         * цвет фона ячейки созданной матрицы и завершает метод. */
        void solution_btn_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "Summation": matrixSummation(); break;
                case "Difference": matrixDifference(); break;
                case "Factum": matrixFactum(); break;
                case "MultiMatrix": matrixMultiple(); break;
                case "Conjugation": matrixConjugation(); break;
            }
        }
        /* Задаёт конфигурацию, меняя состояние некоторых элементов
         * формы ActForMatrix для корректного выполнения
         * выбранного действия над матрицами. */
        // Устанавливает значение null для статического
        // поля MainForm.actForMatrix
        void ActForMatrix_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.actForMatrix = null;
        }
        #endregion
        #region Методы для визуального представления матриц и их значений
        // Выводит на форму первую матрицу, состоящую из объектов TextBox.
        void displayFirstMatrix()
        {
            // Координаты, задающие начальное положение ячеек
            // первой матрицы при её создании
            pointX = matOneView_lbl.Location.X;
            pointY = matOneView_lbl.Location.Y + 30;
            // Количество рядов и столбцов матрицы 
            // устанавливается из значений полей NumericUpDown
            matrix1 = new Matrix((int)mat_one_rows.Value, (int)mat_one_cols.Value);
            firstMatrix = new MatrixView(matrix1);
            // Добавляет на форму элемент textBox объекта firstMatrix
            // для всех рядов и столбцов матрицы matrix1
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {                    
                    firstMatrix[i, j].Location = new Point(pointX, pointY);
                    Controls.Add(firstMatrix[i, j]);
                    pointX += 50;
                }
                pointX = matOneView_lbl.Location.X;
                pointY += 20;
            }
            matOneView_lbl.Text = matOneLabel;
        }
        // Выводит на форму вторую матрицу, состоящую из объектов TextBox.
        void displaySecondMatrix()
        {
            // Координаты, задающие начальное положение ячеек
            // второй матрицы при её создании
            pointX = matTwoView_lbl.Location.X;
            pointY = matTwoView_lbl.Location.Y + 30;
            // Количество рядов и столбцов матрицы 
            // устанавливается из значений полей NumericUpDown
            matrix2 = new Matrix((int)mat_two_rows.Value, (int)mat_two_cols.Value);
            secondMatrix = new MatrixView(matrix2);
            // Добавляет на форму элемент textBox объекта secondMatrix
            // для всех рядов и столбцов матрицы matrix2
            for (int i = 0; i < matrix2.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {                    
                    secondMatrix[i, j].Location = new Point(pointX, pointY);
                    Controls.Add(secondMatrix[i, j]);
                    pointX += 50;
                }
                pointX = matTwoView_lbl.Location.X;
                pointY += 20;
            }
            matTwoView_lbl.Text = matTwoLabel;
        }
        // Выводит на форму матрицу-результат, состоящую из объектов TextBox.
        void displayResultMatrix()
        {
            if (resultMatrix == null)
            {
                // Координаты, задающие начальное положение ячеек
                // результирующей матрицы при её создании
                pointX = mat_two_col_lbl.Location.X;
                pointY = mat_two_col_lbl.Location.Y + 215;
                resultMatrix = new MatrixView(matrix3);
                // Добавляет на форму элемент textBox объекта resultMatrix
                // для всех рядов и столбцов матрицы matrix3
                for (int i = 0; i < matrix3.Rows; i++)
                {
                    for (int j = 0; j < matrix3.Columns; j++)
                    {                        
                        resultMatrix[i, j].Text = matrix3[i, j].ToString();
                        resultMatrix[i, j].Location = new Point(pointX, pointY);
                        Controls.Add(resultMatrix[i, j]);
                        pointX += 50;
                    }
                    pointX = mat_two_col_lbl.Location.X;
                    pointY += 20;
                }
            }
            else
            {
                for (int i = 0; i < matrix3.Rows; i++)
                    for (int j = 0; j < matrix3.Columns; j++)                       
                        resultMatrix[i, j].Text = matrix3[i, j].ToString();
            }
            matResultView_lbl.Text = matResultLabel;
        }
        /* Определяет значения для указанной матрицы mat
         * из значений TextBox указанной визуальной матрицы matView.
         * Прерывает выполнение метода при некорретном значении
         * поля matLabel, меняя фоновый цвет этого поля. */
        void matrixParsing(Matrix mat, MatrixView matView,
                           Label matLabel, string initialLabel)
        {
            for (int i = 0; i < mat.Rows; i++)
                for (int j = 0; j < mat.Columns; j++)
                {
                    // Если значение ячейки представления матрицы пустое,
                    // то этой ячейке присваевается значение 0 (нуль)
                    if (matView[i, j].Text == string.Empty)
                    {
                        mat[i, j] = 0;
                        matView[i, j].Text = "0";
                    }
                    else
                    {
                        try
                        {
                            mat[i, j] = Int32.Parse(matView[i, j].Text);
                            matView[i, j].BackColor = Color.White;
                        }
                        // Вызывает исключение FormatException при попытке 
                        // извлечь некорректное числовое значение
                        catch (FormatException)
                        {
                            matView[i, j].BackColor = Color.Yellow;
                            inputChecker = false;
                            matLabel.Text = checkTheData;
                            return;
                        }
                    }
                }
            matLabel.Text = initialLabel;
            inputChecker = true;
        }
        // Удаляет представление матриц из формы ActForMatrix.
        // Удаляет объекты класса Matrix из памяти.
        void matrixDeletion(Matrix mat, MatrixView matView)
        {
            if (mat != null)
            {
                for (int i = 0; i < mat.Rows; i++)
                    for (int j = 0; j < mat.Columns; j++)
                    {
                        Controls.Remove(matView[i, j]);
                        matView[i, j].Dispose();
                    }
                mat = null;
            }
        }
        #endregion
        #region Методы для определения результата действий над матрицами
        // Выполняет сложение матриц matrix1 и matrix2
        void matrixSummation()
        {
            matrixParsing(matrix1, firstMatrix,
                          matOneView_lbl, matOneLabel);
            matrixParsing(matrix2, secondMatrix, 
                          matTwoView_lbl, matTwoLabel);
            if (inputChecker == true)
            {
                matrix3 = matrix1 + matrix2;
                displayResultMatrix();
            }
        }
        // Выполняет вычитание матриц matrix1 и matrix2
        void matrixDifference()
        {
            matrixParsing(matrix1, firstMatrix,
                          matOneView_lbl, matOneLabel);
            matrixParsing(matrix2, secondMatrix,
                          matTwoView_lbl, matTwoLabel);
            if (inputChecker == true)
            {
                matrix3 = matrix1 - matrix2;
                displayResultMatrix();
            }
        }
        // Выполняет произведение матриц matrix1 и matrix2
        void matrixFactum()
        {
            matrixParsing(matrix1, firstMatrix,
                          matOneView_lbl, matOneLabel);
            matrixParsing(matrix2, secondMatrix,
                          matTwoView_lbl, matTwoLabel);
            if (inputChecker == true)
            {
                matrix3 = matrix1 * matrix2;
                displayResultMatrix();
            }
        }
        // Выполняет умножение матрицы matrix1 на число 'n'
        void matrixMultiple()
        {
            matrixParsing(matrix1, firstMatrix,
                          matOneView_lbl, matOneLabel);
            if (inputChecker == true)
            {
                matrix3 = matrix1;
                matrix3.multiTheMatrix((int)mat_two_rows.Value);
                displayResultMatrix();
            }
        }
        // Выполняет транспонирование матрицы matrix1
        void matrixConjugation()
        {
            matrixParsing(matrix1, firstMatrix,
                          matOneView_lbl, matOneLabel);
            if (inputChecker == true)
            {
                matrix3 = Matrix.flipTheMatrix(matrix1);
                displayResultMatrix();
            }
        }
        #endregion
    }
}
