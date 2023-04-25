using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string? NameStatus { get; set; }

    public virtual ICollection<History> Histories { get; } = new List<History>();
}
