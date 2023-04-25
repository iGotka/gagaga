using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class YearAdd
{
    public int IdYear { get; set; }

    public int? Year { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
