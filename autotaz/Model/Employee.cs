using System;
using System.Collections.Generic;

namespace autotaz.Model;

public partial class Employee
{
    public int Id { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Worklog> Worklogs { get; set; } = new List<Worklog>();
}
