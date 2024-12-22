using System;
using System.Collections.Generic;

namespace autotaz.Model;

public partial class Assignment
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int? DepartmentId { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly Since { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
