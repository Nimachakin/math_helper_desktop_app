namespace Математический_помощник
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.calculator_btn = new System.Windows.Forms.Button();
            this.matrixes_btn = new System.Windows.Forms.Button();
            this.figures_btn = new System.Windows.Forms.Button();
            this.selector_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calculator_btn
            // 
            this.calculator_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculator_btn.Location = new System.Drawing.Point(12, 83);
            this.calculator_btn.Name = "calculator_btn";
            this.calculator_btn.Size = new System.Drawing.Size(140, 75);
            this.calculator_btn.TabIndex = 0;
            this.calculator_btn.Text = "Calculator";
            this.calculator_btn.UseVisualStyleBackColor = true;
            this.calculator_btn.Click += new System.EventHandler(this.calculator_btn_Click);
            // 
            // matrixes_btn
            // 
            this.matrixes_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matrixes_btn.Location = new System.Drawing.Point(158, 83);
            this.matrixes_btn.Name = "matrixes_btn";
            this.matrixes_btn.Size = new System.Drawing.Size(140, 75);
            this.matrixes_btn.TabIndex = 1;
            this.matrixes_btn.Text = "Operations with matrix";
            this.matrixes_btn.UseVisualStyleBackColor = true;
            this.matrixes_btn.Click += new System.EventHandler(this.matrix_btn_Click);
            // 
            // figures_btn
            // 
            this.figures_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.figures_btn.Location = new System.Drawing.Point(304, 83);
            this.figures_btn.Name = "figures_btn";
            this.figures_btn.Size = new System.Drawing.Size(140, 75);
            this.figures_btn.TabIndex = 2;
            this.figures_btn.Text = "Figure measurements";
            this.figures_btn.UseVisualStyleBackColor = true;
            this.figures_btn.Click += new System.EventHandler(this.figures_btn_Click);
            // 
            // selector_lbl
            // 
            this.selector_lbl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.selector_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selector_lbl.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selector_lbl.Location = new System.Drawing.Point(13, 13);
            this.selector_lbl.Name = "selector_lbl";
            this.selector_lbl.Size = new System.Drawing.Size(431, 67);
            this.selector_lbl.TabIndex = 3;
            this.selector_lbl.Text = "Click any button below";
            this.selector_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 162);
            this.Controls.Add(this.selector_lbl);
            this.Controls.Add(this.figures_btn);
            this.Controls.Add(this.matrixes_btn);
            this.Controls.Add(this.calculator_btn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 200);
            this.MinimumSize = new System.Drawing.Size(475, 200);
            this.Name = "MainForm";
            this.Text = "Math helper v0.89 :)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button calculator_btn;
        private System.Windows.Forms.Button matrixes_btn;
        private System.Windows.Forms.Button figures_btn;
        private System.Windows.Forms.Label selector_lbl;
    }
}

