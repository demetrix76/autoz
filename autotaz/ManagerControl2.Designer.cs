namespace autotaz
{
    partial class ManagerControl2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            cbDepartments = new ComboBox();
            label2 = new Label();
            dtPeriod = new DateTimePicker();
            btSave = new Button();
            label3 = new Label();
            grid = new DataGridView();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(cbDepartments);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(dtPeriod);
            flowLayoutPanel1.Controls.Add(btSave);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 4, 0, 4);
            flowLayoutPanel1.Size = new Size(1048, 43);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Margin = new Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "Подразделение";
            // 
            // cbDepartments
            // 
            cbDepartments.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbDepartments.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbDepartments.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDepartments.FormattingEnabled = true;
            cbDepartments.Location = new Point(128, 7);
            cbDepartments.Name = "cbDepartments";
            cbDepartments.Size = new Size(441, 28);
            cbDepartments.TabIndex = 1;
            cbDepartments.SelectionChangeCommitted += cbDepartments_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(575, 10);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 0;
            label2.Text = "Период";
            // 
            // dtPeriod
            // 
            dtPeriod.CustomFormat = "MMMM yyyy";
            dtPeriod.Format = DateTimePickerFormat.Custom;
            dtPeriod.Location = new Point(644, 7);
            dtPeriod.Name = "dtPeriod";
            dtPeriod.ShowUpDown = true;
            dtPeriod.Size = new Size(214, 27);
            dtPeriod.TabIndex = 2;
            dtPeriod.ValueChanged += dtPeriod_ValueChanged;
            // 
            // btSave
            // 
            btSave.Location = new Point(864, 7);
            btSave.Name = "btSave";
            btSave.Size = new Size(94, 29);
            btSave.TabIndex = 3;
            btSave.Text = "Сохранить";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.GradientInactiveCaption;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 43);
            label3.Name = "label3";
            label3.Size = new Size(1048, 20);
            label3.TabIndex = 1;
            label3.Text = "Журнал учёта отработанного времени";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grid
            // 
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 63);
            grid.Name = "grid";
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(1048, 644);
            grid.TabIndex = 2;
            grid.CellBeginEdit += grid_CellBeginEdit;
            grid.CellFormatting += grid_CellFormatting;
            grid.CellValueNeeded += grid_CellValueNeeded;
            grid.CellValuePushed += grid_CellValuePushed;
            grid.KeyDown += grid_KeyDown;
            // 
            // ManagerControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grid);
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel1);
            Name = "ManagerControl2";
            Size = new Size(1048, 707);
            Load += ManagerControl2_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ComboBox cbDepartments;
        private Label label2;
        private DateTimePicker dtPeriod;
        private Label label3;
        private DataGridView grid;
        private Button btSave;
    }
}
