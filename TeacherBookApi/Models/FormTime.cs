using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class FormTime
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
