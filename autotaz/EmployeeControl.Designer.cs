namespace autotaz
{
    partial class EmployeeControl
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
            cbEmployee = new ComboBox();
            label2 = new Label();
            dtPeriod = new DateTimePicker();
            splitView = new SplitContainer();
            assignmentHistory = new AssignmentHistoryControl();
            label4 = new Label();
            payView = new Microsoft.Web.WebView2.WinForms.WebView2();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitView).BeginInit();
            splitView.Panel1.SuspendLayout();
            splitView.Panel2.SuspendLayout();
            splitView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)payView).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(cbEmployee);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(dtPeriod);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(4);
            flowLayoutPanel1.Size = new Size(1140, 42);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 10);
            label1.Margin = new Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Сотрудник";
            // 
            // cbEmployee
            // 
            cbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmployee.FormattingEnabled = true;
            cbEmployee.Location = new Point(95, 7);
            cbEmployee.Name = "cbEmployee";
            cbEmployee.Size = new Size(383, 28);
            cbEmployee.TabIndex = 1;
            cbEmployee.SelectionChangeCommitted += cbEmployee_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(484, 10);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 0;
            label2.Text = "Месяц";
            // 
            // dtPeriod
            // 
            dtPeriod.CustomFormat = "MMMM yyyy";
            dtPeriod.Format = DateTimePickerFormat.Custom;
            dtPeriod.Location = new Point(544, 7);
            dtPeriod.Name = "dtPeriod";
            dtPeriod.ShowUpDown = true;
            dtPeriod.Size = new Size(199, 27);
            dtPeriod.TabIndex = 2;
            dtPeriod.ValueChanged += dtPeriod_ValueChanged;
            // 
            // splitView
            // 
            splitView.Dock = DockStyle.Fill;
            splitView.Location = new Point(0, 42);
            splitView.Name = "splitView";
            // 
            // splitView.Panel1
            // 
            splitView.Panel1.Controls.Add(assignmentHistory);
            splitView.Panel1.Controls.Add(label4);
            // 
            // splitView.Panel2
            // 
            splitView.Panel2.Controls.Add(payView);
            splitView.Size = new Size(1140, 672);
            splitView.SplitterDistance = 537;
            splitView.TabIndex = 3;
            // 
            // assignmentHistory
            // 
            assignmentHistory.DbContext = null;
            assignmentHistory.Dock = DockStyle.Fill;
            assignmentHistory.EmployeeId = null;
            assignmentHistory.Location = new Point(0, 20);
            assignmentHistory.Name = "assignmentHistory";
            assignmentHistory.Size = new Size(537, 652);
            assignmentHistory.TabIndex = 0;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.GradientInactiveCaption;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(537, 20);
            label4.TabIndex = 3;
            label4.Text = "История назначений";
            // 
            // payView
            // 
            payView.AllowExternalDrop = true;
            payView.CreationProperties = null;
            payView.DefaultBackgroundColor = Color.White;
            payView.Dock = DockStyle.Fill;
            payView.Location = new Point(0, 0);
            payView.Name = "payView";
            payView.Size = new Size(599, 672);
            payView.TabIndex = 0;
            payView.ZoomFactor = 1D;
            // 
            // EmployeeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitView);
            Controls.Add(flowLayoutPanel1);
            Name = "EmployeeControl";
            Size = new Size(1140, 714);
            Load += EmployeeControl_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            splitView.Panel1.ResumeLayout(false);
            splitView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitView).EndInit();
            splitView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)payView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ComboBox cbEmployee;
        private Label label2;
        private DateTimePicker dtPeriod;
        private SplitContainer splitView;
        private Label label4;
        private AssignmentHistoryControl assignmentHistory;
        private Microsoft.Web.WebView2.WinForms.WebView2 payView;
    }
}
