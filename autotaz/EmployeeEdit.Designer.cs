namespace autotaz
{
    partial class EmployeeEdit
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
            txLastName = new TextBox();
            label2 = new Label();
            txFirstName = new TextBox();
            label3 = new Label();
            txPatronymic = new TextBox();
            btOK = new Button();
            btCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Фамилия";
            // 
            // txLastName
            // 
            txLastName.Location = new Point(12, 32);
            txLastName.Name = "txLastName";
            txLastName.Size = new Size(462, 27);
            txLastName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 0;
            label2.Text = "Имя";
            // 
            // txFirstName
            // 
            txFirstName.Location = new Point(12, 92);
            txFirstName.Name = "txFirstName";
            txFirstName.Size = new Size(462, 27);
            txFirstName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 130);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 0;
            label3.Text = "Отчество";
            // 
            // txPatronymic
            // 
            txPatronymic.Location = new Point(12, 153);
            txPatronymic.Name = "txPatronymic";
            txPatronymic.Size = new Size(462, 27);
            txPatronymic.TabIndex = 3;
            // 
            // btOK
            // 
            btOK.Location = new Point(492, 31);
            btOK.Name = "btOK";
            btOK.Size = new Size(94, 29);
            btOK.TabIndex = 4;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // btCancel
            // 
            btCancel.DialogResult = DialogResult.Cancel;
            btCancel.Location = new Point(492, 68);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(94, 29);
            btCancel.TabIndex = 5;
            btCancel.Text = "Отмена";
            btCancel.UseVisualStyleBackColor = true;
            // 
            // EmployeeEdit
            // 
            AcceptButton = btOK;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = btCancel;
            ClientSize = new Size(602, 195);
            Controls.Add(btCancel);
            Controls.Add(btOK);
            Controls.Add(txPatronymic);
            Controls.Add(txFirstName);
            Controls.Add(txLastName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeEdit";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "EmployeeEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txLastName;
        private Label label2;
        private TextBox txFirstName;
        private Label label3;
        private TextBox txPatronymic;
        private Button btOK;
        private Button btCancel;
    }
}