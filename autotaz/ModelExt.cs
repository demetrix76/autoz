using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotaz.Model
{
    public partial class Employee
    {
        public string FullName { get => $"{Lastname} {Firstname} {Patronymic}"; }
    }

    public partial class Assignment
    {
        public string HistoryRecord { get => DepartmentId is null ? "Уволен" : $"Назначен в {Department?.Name}"; }
    }

}
