namespace Математический_помощник
{
    partial class ActForMatrix
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.operation_lbl = new System.Windows.Forms.Label();
            this.operation_comBox = new System.Windows.Forms.ComboBox();
            this.mat_one_row_lbl = new System.Windows.Forms.Label();
            this.mat_one_col_lbl = new System.Windows.Forms.Label();
            this.mat_one_rows = new System.Windows.Forms.NumericUpDown();
            this.mat_one_cols = new System.Windows.Forms.NumericUpDown();
            this.mat_two_cols = new System.Windows.Forms.NumericUpDown();
            this.mat_two_rows = new System.Windows.Forms.NumericUpDown();
            this.mat_two_col_lbl = new System.Windows.Forms.Label();
            this.mat_two_row_lbl = new System.Windows.Forms.Label();
            this.create_btn = new System.Windows.Forms.Button();
            this.solve_btn = new System.Windows.Forms.Button();
            this.matOneView_lbl = new System.Windows.Forms.Label();
            this.matTwoView_lbl = new System.Windows.Forms.Label();
            this.matResultView_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mat_one_rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_one_cols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_two_cols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_two_rows)).BeginInit();
            this.SuspendLayout();
            // 
            // operation_lbl
            // 
            this.operation_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operation_lbl.Location = new System.Drawing.Point(12, 13);
            this.operation_lbl.Name = "operation_lbl";
            this.operation_lbl.Size = new System.Drawing.Size(241, 23);
            this.operation_lbl.TabIndex = 10;
            this.operation_lbl.Text = "Choose an action to perform";
            this.operation_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // operation_comBox
            // 
            this.operation_comBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operation_comBox.FormattingEnabled = true;
            this.operation_comBox.Items.AddRange(new object[] {
            "Summation",
            "Difference",
            "Factum",
            "MultiMatrix",
            "Conjugation"});
            this.operation_comBox.Location = new System.Drawing.Point(12, 39);
            this.operation_comBox.Name = "operation_comBox";
            this.operation_comBox.Size = new System.Drawing.Size(177, 21);
            this.operation_comBox.TabIndex = 12;
            this.operation_comBox.SelectedIndexChanged += new System.EventHandler(this.matrixOp_box_SelectedIndexChanged);
            // 
            // mat_one_row_lbl
            // 
            this.mat_one_row_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mat_one_row_lbl.Location = new System.Drawing.Point(13, 81);
            this.mat_one_row_lbl.Name = "mat_one_row_lbl";
            this.mat_one_row_lbl.Size = new System.Drawing.Size(145, 20);
            this.mat_one_row_lbl.TabIndex = 13;
            this.mat_one_row_lbl.Text = "Rows of 1st matrix";
            this.mat_one_row_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mat_one_col_lbl
            // 
            this.mat_one_col_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mat_one_col_lbl.Location = new System.Drawing.Point(13, 114);
            this.mat_one_col_lbl.Name = "mat_one_col_lbl";
            this.mat_one_col_lbl.Size = new System.Drawing.Size(145, 20);
            this.mat_one_col_lbl.TabIndex = 14;
            this.mat_one_col_lbl.Text = "Columns of 1st matrix";
            this.mat_one_col_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mat_one_rows
            // 
            this.mat_one_rows.Enabled = false;
            this.mat_one_rows.Location = new System.Drawing.Point(173, 83);
            this.mat_one_rows.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.mat_one_rows.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mat_one_rows.Name = "mat_one_rows";
            this.mat_one_rows.Size = new System.Drawing.Size(40, 20);
            this.mat_one_rows.TabIndex = 15;
            this.mat_one_rows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // mat_one_cols
            // 
            this.mat_one_cols.Enabled = false;
            this.mat_one_cols.Location = new System.Drawing.Point(173, 116);
            this.mat_one_cols.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.mat_one_cols.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mat_one_cols.Name = "mat_one_cols";
            this.mat_one_cols.Size = new System.Drawing.Size(40, 20);
            this.mat_one_cols.TabIndex = 16;
            this.mat_one_cols.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // mat_two_cols
            // 
            this.mat_two_cols.Enabled = false;
            this.mat_two_cols.Location = new System.Drawing.Point(520, 116);
            this.mat_two_cols.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.mat_two_cols.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mat_two_cols.Name = "mat_two_cols";
            this.mat_two_cols.Size = new System.Drawing.Size(40, 20);
            this.mat_two_cols.TabIndex = 20;
            this.mat_two_cols.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // mat_two_rows
            // 
            this.mat_two_rows.Enabled = false;
            this.mat_two_rows.Location = new System.Drawing.Point(520, 83);
            this.mat_two_rows.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.mat_two_rows.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mat_two_rows.Name = "mat_two_rows";
            this.mat_two_rows.Size = new System.Drawing.Size(40, 20);
            this.mat_two_rows.TabIndex = 19;
            this.mat_two_rows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // mat_two_col_lbl
            // 
            this.mat_two_col_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mat_two_col_lbl.Location = new System.Drawing.Point(360, 114);
            this.mat_two_col_lbl.Name = "mat_two_col_lbl";
            this.mat_two_col_lbl.Size = new System.Drawing.Size(154, 20);
            this.mat_two_col_lbl.TabIndex = 18;
            this.mat_two_col_lbl.Text = "Columns of 2nd matrix";
            this.mat_two_col_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mat_two_row_lbl
            // 
            this.mat_two_row_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mat_two_row_lbl.Location = new System.Drawing.Point(360, 81);
            this.mat_two_row_lbl.Name = "mat_two_row_lbl";
            this.mat_two_row_lbl.Size = new System.Drawing.Size(145, 20);
            this.mat_two_row_lbl.TabIndex = 17;
            this.mat_two_row_lbl.Text = "Rows of 2nd matrix";
            this.mat_two_row_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // create_btn
            // 
            this.create_btn.Enabled = false;
            this.create_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.create_btn.Location = new System.Drawing.Point(363, 20);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(120, 40);
            this.create_btn.TabIndex = 21;
            this.create_btn.Text = "CREATE";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // solve_btn
            // 
            this.solve_btn.Enabled = false;
            this.solve_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solve_btn.Location = new System.Drawing.Point(489, 20);
            this.solve_btn.Name = "solve_btn";
            this.solve_btn.Size = new System.Drawing.Size(120, 40);
            this.solve_btn.TabIndex = 22;
            this.solve_btn.Text = "SOLVE";
            this.solve_btn.UseVisualStyleBackColor = true;
            this.solve_btn.Click += new System.EventHandler(this.solution_btn_Click);
            // 
            // matOneView_lbl
            // 
            this.matOneView_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matOneView_lbl.Location = new System.Drawing.Point(13, 161);
            this.matOneView_lbl.Name = "matOneView_lbl";
            this.matOneView_lbl.Size = new System.Drawing.Size(207, 20);
            this.matOneView_lbl.TabIndex = 23;
            this.matOneView_lbl.Text = "First matrix";
            this.matOneView_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // matTwoView_lbl
            // 
            this.matTwoView_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matTwoView_lbl.Location = new System.Drawing.Point(360, 161);
            this.matTwoView_lbl.Name = "matTwoView_lbl";
            this.matTwoView_lbl.Size = new System.Drawing.Size(207, 20);
            this.matTwoView_lbl.TabIndex = 24;
            this.matTwoView_lbl.Text = "Second matrix";
            this.matTwoView_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // matResultView_lbl
            // 
            this.matResultView_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matResultView_lbl.Location = new System.Drawing.Point(242, 328);
            this.matResultView_lbl.Name = "matResultView_lbl";
            this.matResultView_lbl.Size = new System.Drawing.Size(105, 20);
            this.matResultView_lbl.TabIndex = 25;
            this.matResultView_lbl.Text = "Result matrix";
            this.matResultView_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActForMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 482);
            this.Controls.Add(this.matResultView_lbl);
            this.Controls.Add(this.matTwoView_lbl);
            this.Controls.Add(this.matOneView_lbl);
            this.Controls.Add(this.solve_btn);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.mat_two_cols);
            this.Controls.Add(this.mat_two_rows);
            this.Controls.Add(this.mat_two_col_lbl);
            this.Controls.Add(this.mat_two_row_lbl);
            this.Controls.Add(this.mat_one_cols);
            this.Controls.Add(this.mat_one_rows);
            this.Controls.Add(this.mat_one_col_lbl);
            this.Controls.Add(this.mat_one_row_lbl);
            this.Controls.Add(this.operation_comBox);
            this.Controls.Add(this.operation_lbl);
            this.MaximumSize = new System.Drawing.Size(690, 520);
            this.MinimumSize = new System.Drawing.Size(690, 520);
            this.Name = "ActForMatrix";
            this.Text = "Matrixes v0.89 :)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ActForMatrix_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mat_one_rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_one_cols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_two_cols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mat_two_rows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label operation_lbl;
        private System.Windows.Forms.ComboBox operation_comBox;
        private System.Windows.Forms.Label mat_one_row_lbl;
        private System.Windows.Forms.Label mat_one_col_lbl;
        private System.Windows.Forms.NumericUpDown mat_one_rows;
        private System.Windows.Forms.NumericUpDown mat_one_cols;
        private System.Windows.Forms.NumericUpDown mat_two_cols;
        private System.Windows.Forms.NumericUpDown mat_two_rows;
        private System.Windows.Forms.Label mat_two_col_lbl;
        private System.Windows.Forms.Label mat_two_row_lbl;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Button solve_btn;
        private System.Windows.Forms.Label matOneView_lbl;
        private System.Windows.Forms.Label matTwoView_lbl;
        private System.Windows.Forms.Label matResultView_lbl;
    }
}