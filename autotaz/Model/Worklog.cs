using System;
using System.Collections.Generic;

namespace autotaz.Model;

public partial class Worklog
{
    public int EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public int? Hours { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
