namespace autotaz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabsMain = new TabControl();
            tabHR2 = new TabPage();
            hR22 = new HR2();
            tabEmployee = new TabPage();
            employeeControl1 = new EmployeeControl();
            tabForeman = new TabPage();
            managerControl21 = new ManagerControl2();
            tabsMain.SuspendLayout();
            tabHR2.SuspendLayout();
            tabEmployee.SuspendLayout();
            tabForeman.SuspendLayout();
            SuspendLayout();
            // 
            // tabsMain
            // 
            tabsMain.Controls.Add(tabHR2);
            tabsMain.Controls.Add(tabEmployee);
            tabsMain.Controls.Add(tabForeman);
            tabsMain.Dock = DockStyle.Fill;
            tabsMain.ItemSize = new Size(74, 48);
            tabsMain.Location = new Point(0, 0);
            tabsMain.Margin = new Padding(0);
            tabsMain.Name = "tabsMain";
            tabsMain.Padding = new Point(0, 0);
            tabsMain.SelectedIndex = 0;
            tabsMain.Size = new Size(1153, 939);
            tabsMain.TabIndex = 1;
            tabsMain.Selecting += tabsMain_Selecting;
            tabsMain.Selected += tabsMain_Selected;
            // 
            // tabHR2
            // 
            tabHR2.Controls.Add(hR22);
            tabHR2.Location = new Point(4, 52);
            tabHR2.Margin = new Padding(0);
            tabHR2.Name = "tabHR2";
            tabHR2.Size = new Size(1145, 883);
            tabHR2.TabIndex = 2;
            tabHR2.Text = "HR2";
            tabHR2.UseVisualStyleBackColor = true;
            // 
            // hR22
            // 
            hR22.Dock = DockStyle.Fill;
            hR22.Location = new Point(0, 0);
            hR22.Margin = new Padding(0);
            hR22.Name = "hR22";
            hR22.Size = new Size(1145, 883);
            hR22.TabIndex = 0;
            // 
            // tabEmployee
            // 
            tabEmployee.Controls.Add(employeeControl1);
            tabEmployee.Location = new Point(4, 52);
            tabEmployee.Margin = new Padding(0);
            tabEmployee.Name = "tabEmployee";
            tabEmployee.Size = new Size(192, 44);
            tabEmployee.TabIndex = 1;
            tabEmployee.Text = "Сотрудник";
            tabEmployee.UseVisualStyleBackColor = true;
            // 
            // employeeControl1
            // 
            employeeControl1.Dock = DockStyle.Fill;
            employeeControl1.Location = new Point(0, 0);
            employeeControl1.Margin = new Padding(0);
            employeeControl1.Name = "employeeControl1";
            employeeControl1.Size = new Size(192, 44);
            employeeControl1.TabIndex = 1;
            // 
            // tabForeman
            // 
            tabForeman.Controls.Add(managerControl21);
            tabForeman.Location = new Point(4, 52);
            tabForeman.Name = "tabForeman";
            tabForeman.Size = new Size(1145, 883);
            tabForeman.TabIndex = 3;
            tabForeman.Text = "Нач. подразделения";
            tabForeman.UseVisualStyleBackColor = true;
            // 
            // managerControl21
            // 
            managerControl21.Dock = DockStyle.Fill;
            managerControl21.Location = new Point(0, 0);
            managerControl21.Name = "managerControl21";
            managerControl21.Size = new Size(1145, 883);
            managerControl21.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1153, 939);
            Controls.Add(tabsMain);
            Name = "Form1";
            Text = "Auto Management";
            Load += Form1_Load;
            tabsMain.ResumeLayout(false);
            tabHR2.ResumeLayout(false);
            tabEmployee.ResumeLayout(false);
            tabForeman.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabsMain;
        private TabPage tabEmployee;
        private TabPage tabHR2;
        private EmployeeControl employeeControl1;
        private HR2 hR22;
        private TabPage tabForeman;
        private ManagerControl2 managerControl21;
    }
}
