using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class Group
{
    public int IdGroup { get; set; }

    public string? NameGroup { get; set; }

    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
