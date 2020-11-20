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
    public partial class MainForm : Form
    {
        #region Закрытые поля класса MainForm
        public static Estimator estimator;
        public static ActForMatrix actForMatrix;
        public static FigureGeometry figureGeometry;
        #endregion
        #region Конструктор класса MainForm
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion
        #region Создание формы калькулятора
        // В один момент времени может существовать только
        // один экземпляр класса Estimator (калькулятор)
        void calculator_btn_Click(object sender, EventArgs e)
        {
            if (estimator != null)
                MessageBox.Show("Калькулятор уже запущен!");
            else
            {
                estimator = new Estimator();
                estimator.DefaultSettings();
                estimator.Show();
            }
        }
        #endregion
        #region Создание формы для работы с матрицами
        // Единовременно можно запустить только одно
        // окно для работы с матрицами
        void matrix_btn_Click(object sender, EventArgs e)
        {
            if (actForMatrix != null)
                MessageBox.Show("Окно с действиями над матрицами уже открыто!");
            else
            {
                actForMatrix = new ActForMatrix();
                actForMatrix.Show();
            }
        }
        #endregion
        #region Создание формы для работы с геометрическими фигурами
        void figures_btn_Click(object sender, EventArgs e)
        {
            if (figureGeometry != null)
                MessageBox.Show("Геометрия уже открыта");
            else
            {
                figureGeometry = new FigureGeometry();
                figureGeometry.Show();
            }
        }
        #endregion
    }
}
