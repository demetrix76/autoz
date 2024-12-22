namespace autotaz
{
    partial class EmployeeAssign
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
            label1 = new Label();
            cbDepartments = new ComboBox();
            label2 = new Label();
            txSalary = new TextBox();
            dpDate = new DateTimePicker();
            label3 = new Label();
            btnAssign = new Button();
            btFire = new Button();
            btCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "Подразделение";
            // 
            // cbDepartments
            // 
            cbDepartments.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDepartments.FormattingEnabled = true;
            cbDepartments.Location = new Point(12, 32);
            cbDepartments.Name = "cbDepartments";
            cbDepartments.Size = new Size(458, 28);
            cbDepartments.TabIndex = 1;
            cbDepartments.SelectionChangeCommitted += cbDepartments_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "З/п в месяц";
            // 
            // txSalary
            // 
            txSalary.CausesValidation = false;
            txSalary.Location = new Point(12, 102);
            txSalary.Name = "txSalary";
            txSalary.Size = new Size(235, 27);
            txSalary.TabIndex = 2;
            // 
            // dpDate
            // 
            dpDate.Location = new Point(12, 168);
            dpDate.Name = "dpDate";
            dpDate.Size = new Size(250, 27);
            dpDate.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(183, 20);
            label3.TabIndex = 5;
            label3.Text = "Дата начала/увольнения";
            // 
            // btnAssign
            // 
            btnAssign.Location = new Point(493, 31);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(109, 29);
            btnAssign.TabIndex = 4;
            btnAssign.Text = "Назначить";
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // btFire
            // 
            btFire.Location = new Point(493, 169);
            btFire.Name = "btFire";
            btFire.Size = new Size(109, 29);
            btFire.TabIndex = 6;
            btFire.Text = "Уволить";
            btFire.UseVisualStyleBackColor = true;
            btFire.Click += btFire_Click;
            // 
            // btCancel
            // 
            btCancel.DialogResult = DialogResult.Cancel;
            btCancel.Location = new Point(493, 66);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(109, 29);
            btCancel.TabIndex = 5;
            btCancel.Text = "Отмена";
            btCancel.UseVisualStyleBackColor = true;
            // 
            // EmployeeAssign
            // 
            AcceptButton = btnAssign;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btCancel;
            ClientSize = new Size(612, 217);
            Controls.Add(btCancel);
            Controls.Add(btFire);
            Controls.Add(btnAssign);
            Controls.Add(label3);
            Controls.Add(dpDate);
            Controls.Add(txSalary);
            Controls.Add(label2);
            Controls.Add(cbDepartments);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeAssign";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Назначить сотрудника";
            Load += EmployeeAssign_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbDepartments;
        private Label label2;
        private TextBox txSalary;
        private DateTimePicker dpDate;
        private Label label3;
        private Button btnAssign;
        private Button btFire;
        private Button btCancel;
    }
}