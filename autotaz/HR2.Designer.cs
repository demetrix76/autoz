namespace autotaz
{
    partial class HR2
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
            topBar = new FlowLayoutPanel();
            btNewEmployee = new Button();
            btEditEmployee = new Button();
            btAssignEmployee = new Button();
            btSave = new Button();
            grid = new DataGridView();
            topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // topBar
            // 
            topBar.AutoSize = true;
            topBar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            topBar.BackColor = SystemColors.ActiveCaption;
            topBar.Controls.Add(btNewEmployee);
            topBar.Controls.Add(btEditEmployee);
            topBar.Controls.Add(btAssignEmployee);
            topBar.Controls.Add(btSave);
            topBar.Dock = DockStyle.Top;
            topBar.Location = new Point(0, 0);
            topBar.Name = "topBar";
            topBar.Padding = new Padding(4);
            topBar.Size = new Size(1081, 44);
            topBar.TabIndex = 0;
            // 
            // btNewEmployee
            // 
            btNewEmployee.AutoSize = true;
            btNewEmployee.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btNewEmployee.Location = new Point(7, 7);
            btNewEmployee.Name = "btNewEmployee";
            btNewEmployee.Size = new Size(142, 30);
            btNewEmployee.TabIndex = 0;
            btNewEmployee.Text = "Новый сотрудник";
            btNewEmployee.UseVisualStyleBackColor = true;
            btNewEmployee.Click += onNewEmployee;
            // 
            // btEditEmployee
            // 
            btEditEmployee.AutoSize = true;
            btEditEmployee.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btEditEmployee.Location = new Point(155, 7);
            btEditEmployee.Name = "btEditEmployee";
            btEditEmployee.Size = new Size(121, 30);
            btEditEmployee.TabIndex = 0;
            btEditEmployee.Text = "Редактировать";
            btEditEmployee.UseVisualStyleBackColor = true;
            btEditEmployee.Click += onEditEmployee;
            // 
            // btAssignEmployee
            // 
            btAssignEmployee.AutoSize = true;
            btAssignEmployee.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btAssignEmployee.Location = new Point(282, 7);
            btAssignEmployee.Name = "btAssignEmployee";
            btAssignEmployee.Size = new Size(154, 30);
            btAssignEmployee.TabIndex = 0;
            btAssignEmployee.Text = "Назначить/уволить";
            btAssignEmployee.UseVisualStyleBackColor = true;
            btAssignEmployee.Click += onAssignEmployee;
            // 
            // btSave
            // 
            btSave.AutoSize = true;
            btSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btSave.Location = new Point(442, 7);
            btSave.Name = "btSave";
            btSave.Size = new Size(93, 30);
            btSave.TabIndex = 0;
            btSave.Text = "Сохранить";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += onSave;
            // 
            // grid
            // 
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 44);
            grid.Margin = new Padding(0);
            grid.Name = "grid";
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(1081, 686);
            grid.TabIndex = 1;
            grid.CellDoubleClick += grid_CellDoubleClick;
            grid.KeyDown += grid_KeyDown;
            // 
            // HR2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grid);
            Controls.Add(topBar);
            Name = "HR2";
            Size = new Size(1081, 730);
            Load += HR2_Load;
            topBar.ResumeLayout(false);
            topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel topBar;
        private DataGridView grid;
        private Button btNewEmployee;
        private Button btSave;
        private Button btEditEmployee;
        private Button btAssignEmployee;
    }
}
