using autotaz.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autotaz
{
    public partial class EmployeeEdit : Form
    {
        private Employee _editedEmployee;
        public EmployeeEdit()
        {
            InitializeComponent();
        }

        public EmployeeEdit(string caption, Employee employee)
        {
            InitializeComponent();
            this.Text = caption;
            // instead of using Bindings, we'll copy values manually to ensure
            // that we only modify the Employee record upon OK

            txLastName.Text = employee.Lastname;
            txFirstName.Text = employee.Firstname;
            txPatronymic.Text = employee.Patronymic ?? string.Empty;

            _editedEmployee = employee;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            // validate first
            var lastName = txLastName.Text.Trim();
            var firstName = txFirstName.Text.Trim();
            var patronymic = txPatronymic.Text.Trim();

            if (lastName == string.Empty || firstName == string.Empty)
                return;

            _editedEmployee.Lastname = lastName;
            _editedEmployee.Firstname = firstName;
            _editedEmployee.Patronymic = patronymic;

            DialogResult = DialogResult.OK;
        }
    }
}
