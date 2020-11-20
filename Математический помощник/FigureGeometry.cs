using System;
using System.Collections;
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
    public partial class FigureGeometry : Form
    {
        #region Закрытые поля класса FigureGeometry
        const string create = "CREATE";
        const string redefine = "REDEFINE";
        const string figureSuccess = "The {0} has been created.";
        const string inputWarning = "Check the input data!";
        const string targetWarning = "Choose the target value you need!";
        const string retryOffer = "\nYou can set new parameters for " +
                                  "\n{0} or start with new figure.";
        const string perimeter = "\nPerimeter of {0} is {1:f2}";
        const string area = "\nArea of {0} is {1:f2}";
        const string cubage = "\nCubage of {0} is {1:f2}";
        string targetFigure;
        int varAmount;
        float result;        
        bool isSuitableData,
             perimFound,
             areaFound,
             cubageFound;
        float[] varsPile;
        TextBox[] dataFields;
        Figure[] figurePile;
        Circle circle;
        Rectangle rectangle;
        Triangle triangle;
        Cone cone;
        Cylinder cylinder;
        Parallelepiped parallelepiped;
        Sphere sphere;
        #endregion
        #region Конструктор класса FigureGeometry
        public FigureGeometry()
        {
            InitializeComponent(); 
            dataFields = new TextBox[] {
                value1_textBox,
                value2_textBox,
                value3_textBox,
                value4_textBox };
            figurePile = new Figure[] {
                circle, rectangle, 
                triangle, cone, 
                cylinder, parallelepiped, 
                sphere };
            resetToDefault();
        }
        #endregion
        #region Методы для обработки событий
        /* Активирует элементы CheckBox (кроме Cubage).
         * Активирует кнопки RESET и SOLVE.
         * Отображает поля для ввода для соответствующей фигуры.
         * Деактивирует элементы ComboBox. */
        void figure2D_comBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (figure2D_comBox.SelectedItem != null)
            {
                cubage_checkBox.Enabled = false;
                targetFigure = figure2D_comBox.Text;                
                inputPreparations();
                choosenFigureSetup();
            }
        }
        // Метод аналогичен figure2D_comBox_SelectedIndexChanged,
        // но вместо элемента CheckBox "Cubage" деактивирует "Perimeter"
        void figure3D_comBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (figure3D_comBox.SelectedItem != null)
            {
                perimeter_checkBox.Enabled = false;
                targetFigure = figure3D_comBox.Text;
                inputPreparations();
                choosenFigureSetup();
            }
        }
        /* Вызывает метод createTheFigure() с параметром varsPile 
         * и метод targetPreparations(), если в видимых полях
         * textBox указаны корректные данные. */
        void create_btn_Click(object sender, EventArgs e)
        {
            inputDataParse();
            if (isSuitableData == true)
            {
                createTheFigure(varsPile);
                targetPreparations();
            }
        }
        // Вызывает метод resetToDefault
        void reset_btn_Click(object sender, EventArgs e)
        {
            resetToDefault();
        }
        /* Запускает методы, проверяющие корретность входных данных,
         * использования этих данных при создании объекта
         * заданной фигуры, вывода результата(ов) вычисления на
         * элемент Label "result_lbl" или сообщений, указывающих
         * на ошибки пользователя при вводе данных. */
        void solve_btn_Click(object sender, EventArgs e)
        {
            targetValues_panel.BackColor = Color.LightBlue;
            if (perimeter_checkBox.Checked == true)
                findPerimeter();
            if (area_checkBox.Checked == true)
                findArea();
            if (cubage_checkBox.Checked == true)
                findCubage();
            if(perimeter_checkBox.Checked == false &&
               area_checkBox.Checked == false &&
               cubage_checkBox.Checked == false)
            {
                targetValues_panel.BackColor = Color.LightYellow;
                result_lbl.Text = targetWarning;
            }
            retryPreparations();
        }
        // Удаляет экземпляр класса figureGeometry из MainForm
        void FigureGeometry_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.figureGeometry = null;
        }
        #endregion
        #region Методы для конфигурации формы FigureGeometry
        /* Возвращает значения и состояния элементов
         * TextBox, CheckBox, Label, Button и Panel
         * к исходным (как при их инициализации). */
        void resetToDefault()
        {
            disableElements();
            clearTheFields();
            deleteAllFigures();
            cubage_checkBox.Enabled = 
            perimeter_checkBox.Enabled =
            figure2D_comBox.Enabled =
            figure3D_comBox.Enabled = true;
            hideInputBoxes();
        }
        /* Меняет фоновый цвет элемента Panel и
         * активирует его вместе с кнопками 
         * RESET и SOLVE. */
        void inputPreparations()
        {
            figure2D_comBox.Enabled =
            figure3D_comBox.Enabled = false;
            create_btn.Enabled = 
            reset_btn.Enabled = 
            params_lbl.Visible = true;
        }
        // Определяет, что искомые величины не считаются найденными.
        // Активирует панель targetValues_panel и кнопку solve_btn.
        void targetPreparations()
        {            
            perimFound = 
            areaFound = 
            cubageFound = false;
            targetValues_panel.BackColor = Color.LightBlue;
            targetValues_panel.Enabled =
            solve_btn.Enabled = true;
        }
        // Деактивирует панель targetValues_panel и кнопку solve_btn.
        // Выводит сообщение с предложение переопределить параметры фигуры.
        void retryPreparations()
        {
            solve_btn.Enabled =
            targetValues_panel.Enabled = false;
            result_lbl.Text += string.Format(retryOffer, targetFigure);
        }
        /* Меняет фоновый цвет элемента Panel и
         * деактивирует его вместе с кнопками 
         * RESET и SOLVE. */
        void disableElements()
        {
            targetValues_panel.BackColor = Color.LightGray;
            targetValues_panel.Enabled =
            create_btn.Enabled = 
            reset_btn.Enabled = 
            solve_btn.Enabled = false;
        }
        /* Очищает значения элементов TextBox и
         * СomboBox. Cнимает галочки (true) с элементов CheckBox.
         * Активирует элемент CheckBox "Cubage". */
        void clearTheFields()
        {
            value1_lbl.Text =
            value2_lbl.Text =
            value3_lbl.Text =
            value4_lbl.Text =
            value1_textBox.Text =
            value2_textBox.Text =
            value3_textBox.Text =
            value4_textBox.Text =
            result_lbl.Text = string.Empty;
            perimeter_checkBox.Checked =
            area_checkBox.Checked =
            cubage_checkBox.Checked = false;
            figure2D_comBox.Text =
            figure3D_comBox.Text = null;
            create_btn.Text = create;
            varsPile = null;
        }
        // Редактирует внешний вид формы для
        // выбранной фигуры.
        void choosenFigureSetup()
        {
            switch (targetFigure)
            {
                case "Circle":
                case "Sphere": varAmount = Circle.parameters;
                    circleDataSettings();
                    break;
                case "Rectangle": varAmount = Rectangle.parameters;
                    rectangleDataSettings();
                    break;
                case "Triangle": varAmount = Triangle.parameters;
                    triangleDataSettings();
                    break;
                case "Cone":
                case "Cylinder": varAmount = Cone.parameters;
                    coneDataSettings();
                    break;
                case "Parallelepiped": varAmount = Parallelepiped.parameters;
                    parallelepipedDataSettings();
                    break;
            }
            varsPile = new float[varAmount];
        }
        // Проверяет корректность входных данных
        // от пользователя.
        void inputDataParse()
        {
            for (int i = 0; i < varAmount; i++)
            {
                try
                {
                    varsPile[i] = float.Parse(dataFields[i].Text);
                    if (varsPile[i] < 0 || varsPile[i] == 0)
                        throw new FormatException();
                    dataFields[i].BackColor = Color.White;
                }
                catch(FormatException)
                {
                    dataFields[i].BackColor = Color.Yellow;
                    result_lbl.Text = inputWarning;
                    isSuitableData =
                    solve_btn.Enabled = false;
                    return;
                }
            }
            result_lbl.Text = string.Format(figureSuccess, targetFigure);
            isSuitableData = true;
        }
        // Задает значения и состояния полей
        // для работы с окружностью (Circle)
        // и сферой (Sphere)
        void circleDataSettings()
        {
            value1_lbl.Text = "Radius";
            displayInputBoxes();
        }
        // Задает значения и состояния полей
        // для работы с треугольником (Triangle)
        void triangleDataSettings()
        {
            value1_lbl.Text = "Line A";
            value2_lbl.Text = "Line B";
            value3_lbl.Text = "Line C";
            displayInputBoxes();
        }
        // Задает значения и состояния полей
        // для работы с четырёхугольником (Rectangle)
        void rectangleDataSettings()
        {
            value1_lbl.Text = "Length";
            value2_lbl.Text = "Width";
            displayInputBoxes();
        }
        // Задает значения и состояния полей
        // для работы с параллелепипедом (Parallelepiped)
        void parallelepipedDataSettings()
        {
            value1_lbl.Text = "Length";
            value2_lbl.Text = "Width";
            value3_lbl.Text = "Height";
            displayInputBoxes();
        }
        // Задает значения и состояния полей
        // для работы с конусом (Cone)
        // и цилиндром (Cylinder)
        void coneDataSettings()
        {
            value1_lbl.Text = "Radius";
            value2_lbl.Text = "Height";
            displayInputBoxes();
        }
        // Активирует и отображает количество элементов
        // TextBox для работы с заданной фигурой
        void displayInputBoxes()
        {
            for (int i = 0; i < varAmount; i++)
                dataFields[i].Enabled =
                dataFields[i].Visible = true;
        }
        // Деактивирует и скрывает элементы TextBox
        // массива dataFields
        void hideInputBoxes()
        {
            if(dataFields != null)
                for (int i = 0; i < dataFields.Length; i++)
                    dataFields[i].Enabled = 
                    dataFields[i].Visible = false;
            params_lbl.Visible = false;
        }
        #endregion
        #region Методы для построения, расчетов величин и удаления фигур
        // Создаёт заданную геометрическую фигуру с параметрами, 
        // расположенными в массиве varsPile
        void createTheFigure(float[] varsPile)
        {
            switch (targetFigure)
            {
                case "Circle":
                    circle = new Circle(varsPile); break;
                case "Rectangle":
                    rectangle = new Rectangle(varsPile); break;
                case "Triangle":
                    triangle = new Triangle(varsPile); break;
                case "Cone":
                    cone = new Cone(varsPile); break;
                case "Cylinder":
                    cylinder = new Cylinder(varsPile); break;
                case "Parallelepiped":
                    parallelepiped = new Parallelepiped(varsPile); break;
                case "Sphere":
                    sphere = new Sphere(varsPile); break;
            }
        }
        // Удаляет ссылку на объект для каждой переменной типа Figure.
        // Устанавливает значение figureExist в false.
        void deleteAllFigures()
        {
            for (int i = 0; i < figurePile.Length; i++)
                if (figurePile[i] != null)
                    figurePile[i] = null;
            isSuitableData = false;
        }
        // Вычисляет периметр выбранной фигуры и выводит результат 
        // в поле result_lbl формы FigureGeometry
        void findPerimeter()
        {
            switch (targetFigure)
            {
                case "Circle":
                    result = circle.Perimeter(); break;
                case "Rectangle":
                    result = rectangle.Perimeter(); break;
                case "Triangle":
                    result = triangle.Perimeter(); break;
            }
            if (perimFound == false)
                result_lbl.Text += string.Format(perimeter, targetFigure, result);
            perimFound = true;
        }
        // Вычисляет площадь выбранной фигуры и выводит результат 
        // в поле result_lbl формы FigureGeometry
        void findArea()
        {
            switch (targetFigure)
            {
                case "Circle":
                    result = circle.Area(); break;
                case "Rectangle":
                    result = rectangle.Area(); break;
                case "Triangle":
                    result = triangle.Area(); break;
                case "Cone":
                    result = cone.Area(); break;
                case "Cylinder":
                    result = cylinder.Area(); break;
                case "Parallelepiped":
                    result = parallelepiped.Area(); break;
                case "Sphere":
                    result = sphere.Area(); break;
            }
            if(areaFound == false)
                result_lbl.Text += string.Format(area, targetFigure, result);
            areaFound = true;
        }
        // Вычисляет объем выбранной фигуры и выводит результат 
        // в поле result_lbl формы FigureGeometry
        void findCubage()
        {
            switch (targetFigure)
            {                
                case "Cone":
                    result = cone.Cubage(); break;
                case "Cylinder":
                    result = cylinder.Cubage(); break;
                case "Parallelepiped":
                    result = parallelepiped.Cubage(); break;
                case "Sphere":
                    result = sphere.Cubage(); break;
            }
            if(cubageFound == false)
                result_lbl.Text += string.Format(cubage, targetFigure, result);
            cubageFound = true;
        }
        #endregion
    }
}
