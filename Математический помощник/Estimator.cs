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
    public partial class Estimator : Form
    {
        #region Закрытые поля класса Estimator
        double x, y, z;
        string actionChar;
        const string ZERO = "0";
        const string doubleFix = "#.####";
        const string sinX = "sin({0}) = ";
        const string cosX = "cos({0}) = ";
        const string tanX = "tan({0}) = ";
        const string lnX = "ln({0}) = ";
        const string logX = "log({0}) = ";
        const string percentage = "{0}% of {1} = ";
        #endregion
        #region Свойства полей класса Estimator
        public double X
        {
            get { return x; }
            private set { x = value; }
        }
        public double Y
        {
            get { return y; }
            private set { y = value; }
        }
        public double Z
        {
            get { return z; }
            private set { z = value; }
        }
        public string ActionChar
        {
            get { return actionChar; }
            private set { actionChar = value; }
        }
        #endregion
        #region Конструктор класса Estimator
        public Estimator()
        {
            InitializeComponent();
        }
        #endregion
        #region Метод сброса данных
        // Cбрасывает все текущие данные на калькуляторе
        public void DefaultSettings()
        {
            ActionChar =
            input_textBox.Text =
            equation_label.Text = string.Empty;
            X = Y = Z = 0;
        }
        // Вызывает метод DefaultSettings
        // при нажатии кнопки reset_btn
        void reset_btn_Click(object sender, EventArgs e)
        {
            DefaultSettings();
        }
        #endregion
        #region Методы для ввода данных в калькулятор
        // Проверяет, не заполнено ли поле input_textBox
        // на максимально возможную величину
        bool inputIsNotFilled()
        {
            if (input_textBox.TextLength < input_textBox.MaxLength)
                return true;
            return false;
        }
        // Вводит данные в поле input_textBox,
        // согласно тексту кнопки. Эти данные замещают значение
        // 0 (ZERO), если оно является единственным значением поля
        void valueInput(Button button)
        {
            if (input_textBox.Text == ZERO)
                input_textBox.Text = button.Text;
            else
                if (inputIsNotFilled())
                    input_textBox.Text += button.Text;
        }
        // Заданные условия гарантируют ввод
        // только одной плавающей точки
        void floatPoint_btn_Click(object sender, EventArgs e)
        {
            if (!input_textBox.Text.Contains(',') &&
                input_textBox.Text != string.Empty &&
                inputIsNotFilled())
                input_textBox.Text += floatPoint_btn.Text;
        }
        // Заданные условия гарантируют
        // невозможность ввода лишних нулей
        void zero_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != ZERO ||
                input_textBox.Text == string.Empty ||
                input_textBox.Text.Contains(','))
                input_textBox.Text += ZERO;
        }
        // Кнопки от '1' до '9' вызывают метод valueInput
        void one_btn_Click(object sender, EventArgs e)
        {
            valueInput(one_btn);
        }
        void two_btn_Click(object sender, EventArgs e)
        {
            valueInput(two_btn);
        }
        void three_btn_Click(object sender, EventArgs e)
        {
            valueInput(three_btn);
        }
        void four_btn_Click(object sender, EventArgs e)
        {
            valueInput(four_btn);
        }
        void five_btn_Click(object sender, EventArgs e)
        {
            valueInput(five_btn);
        }
        void six_btn_Click(object sender, EventArgs e)
        {
            valueInput(six_btn);
        }
        void seven_btn_Click(object sender, EventArgs e)
        {
            valueInput(seven_btn);
        }
        void eight_btn_Click(object sender, EventArgs e)
        {
            valueInput(eight_btn);
        }
        void nine_btn_Click(object sender, EventArgs e)
        {
            valueInput(nine_btn);
        }
        // Значения кнопок 'π' и 'e' заносятся в поле если
        // оно пустое или содержит значение '0' (ZERO)
        void pi_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text == string.Empty || input_textBox.Text == ZERO)
                input_textBox.Text = (Math.PI).ToString(doubleFix);
        }
        void e_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text == string.Empty || input_textBox.Text == ZERO)
                input_textBox.Text = (Math.E).ToString(doubleFix);
        }
        #endregion
        #region Методы, проводящие двухсторонние вычисления
        /* Конструкция switch-case вызывает метод,
         * соответствующий определению поля ActionChar.
         * Вызываемый метод
         * этого поля будет вызван метод для соответствующего
         *  вычисления. */
        void equals_btn_Click(object sender, EventArgs e)
        {
            switch (ActionChar)
            {
                case "+": sumXY(); break;
                case "-": diffXY(); break;
                case "*": multiXY(); break;
                case "/": ratioXY(); break;
                case "^": raisingXY(); break;
                case "%": percentXofY(); break;
            }
        }
        // Структурирует выражение в поле equation_label.
        // Выводит результат вычисления в поле input_textBox.
        // Удаляет определение поля ActionChar.
        void showResult(Button button)
        {
            equation_label.Text = (X.ToString() + " " +
                                 button.Text + " " +
                                 input_textBox.Text + " " +
                                 equals_btn.Text);
            input_textBox.Text = Z.ToString(doubleFix);
            ActionChar = string.Empty;
        }
        // Метод для вычисления суммы значений X и Y
        void sumXY()
        {
            if (input_textBox.Text != string.Empty)
            {
                Y = double.Parse(input_textBox.Text);
                Z = X + Y;
                showResult(sum_btn);
            }
        }
        // Метод для вычисления разницы между X и Y (X - Y)
        void diffXY()
        {
            if (input_textBox.Text != string.Empty)
            {
                Y = double.Parse(input_textBox.Text);
                Z = X - Y;
                showResult(diff_btn);
            }
        }
        // Метод для вычисления произведения значений X и Y
        void multiXY()
        {
            if (input_textBox.Text != string.Empty)
            {
                Y = double.Parse(input_textBox.Text);
                Z = X * Y;
                showResult(multi_btn);
            }
        }
        // Метод для вычисления деления X на Y
        void ratioXY()
        {
            if (input_textBox.Text != string.Empty)
            {
                Y = double.Parse(input_textBox.Text);
                Z = X / Y;
                showResult(ratio_btn);
            }
        }
        // Метод для вычисления значения X, возведенного в степень Y
        void raisingXY()
        {
            if (input_textBox.Text != string.Empty)
            {
                Y = double.Parse(input_textBox.Text);
                Z = Math.Pow(X, Y);
                showResult(raising_btn);
            }
        }
        // Метод для вычисления X в процентном отношении Y
        void percentXofY()
        {
            if (input_textBox.Text != string.Empty)
            {
                Y = double.Parse(input_textBox.Text);
                Z = Math.Abs((Y * X) / 100);
                equation_label.Text = string.Format(percentage, Math.Abs(X), Y);
                input_textBox.Text = Z.ToString(doubleFix);
                ActionChar = string.Empty;
            }
        }
        #endregion
        #region Методы обработки алгебраических двухсторонних вычислений
        /* Преобразует непустое значение поля input_textBox в тип double
         * и присваивает его полю Estimator.X. Отражает в поле result_label
         * промежуточный результат вычисления и очищает поле input_textBox.
         * Задаёт определение алгебраической операции для поля ActionChar */
        void inputParsing(Button button)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = input_textBox.Text + " " + button.Text;
                input_textBox.Text = string.Empty;
                ActionChar = button.Text;
            }
        }
        void sum_btn_Click(object sender, EventArgs e)
        {
            inputParsing(sum_btn);
        }
        void diff_btn_Click(object sender, EventArgs e)
        {
            inputParsing(diff_btn);
        }
        void multi_btn_Click(object sender, EventArgs e)
        {
            inputParsing(multi_btn);
        }
        void ratio_btn_Click(object sender, EventArgs e)
        {
            inputParsing(ratio_btn);
        }
        void raising_btn_Click(object sender, EventArgs e)
        {
            inputParsing(raising_btn);
        }
        // Алгоритм немного отличается от метода inputParsing,
        // но его принцип тот же
        void percent_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = Math.Abs(float.Parse(input_textBox.Text));
                equation_label.Text = string.Format(percentage, X, string.Empty);
                input_textBox.Text = string.Empty;
                ActionChar = percent_btn.Text;
            }
        }
        #endregion
        #region Методы обработки алгебраических односторонних вычислений
        /* Следующие методы преобразуют непустое значение поля input_textBox
         * в тип double и присваивают его полю Estimator.X. Далее происходит
         * автоматическое вычисление согласно определению кнопки операции. */

        // Вычисление квадратного корня
        void squareRoot_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = (squareRoot_btn.Text +
                                       input_textBox.Text + equals_btn.Text);
                input_textBox.Text = Math.Sqrt(X).ToString(doubleFix);
            }
        }
        // Вычисление факториала
        void factorial_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = (input_textBox.Text + "!" + equals_btn.Text);
                input_textBox.Text = factorial(X);
            }
        }
        // Вычисление синуса
        void sin_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = string.Format(sinX, input_textBox.Text);
                input_textBox.Text = Math.Sin(X).ToString(doubleFix);
            }
        }
        // Вычисление косинуса
        void cos_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = string.Format(cosX, input_textBox.Text);
                input_textBox.Text = Math.Cos(X).ToString(doubleFix);
            }
        }
        // Вычисление тангенса
        void tan_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = string.Format(tanX, input_textBox.Text);
                input_textBox.Text = Math.Tan(X).ToString(doubleFix);
            }
        }
        // Вычисление натурального логарифма
        void ln_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = string.Format(lnX, input_textBox.Text);
                input_textBox.Text = Math.Log(X, Math.E).ToString(doubleFix);
            }
        }
        // Вычисление десятичного логарифма
        void log_btn_Click(object sender, EventArgs e)
        {
            if (input_textBox.Text != string.Empty)
            {
                X = double.Parse(input_textBox.Text);
                equation_label.Text = string.Format(logX, input_textBox.Text);
                input_textBox.Text = Math.Log10(X).ToString(doubleFix);
            }
        }
        // Рекурсивный метод для вычисления факториала значения x
        string factorial(double x)
        {
            string tempS;
            Y = x;
            while (x > 1)
                Y *= --x;
            tempS = Y.ToString(doubleFix);
            return tempS;
        }
        #endregion
        #region Метод для удаления экземпляра класса Estimator при закрытии формы
        void Estimator_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.estimator = null;
        }
        #endregion
    }
}
