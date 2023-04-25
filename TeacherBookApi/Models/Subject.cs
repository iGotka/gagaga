using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class Subject
{
    public int IdSubject { get; set; }

    public string? NameSubject { get; set; }

    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();

    public virtual ICollection<TeacherHasSubject> TeacherHasSubjects { get; } = new List<TeacherHasSubject>();
}
