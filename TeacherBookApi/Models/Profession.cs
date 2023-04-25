using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class Profession
{
    public int IdProfession { get; set; }

    public string? NameProfession { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
