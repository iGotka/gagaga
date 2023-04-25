using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class TeacherHasSubject
{
    public int IdTd { get; set; }

    public int? IdTeacher { get; set; }

    public int? IdSubject { get; set; }

    public int? Duration { get; set; }

    public virtual Subject? IdSubjectNavigation { get; set; }

    public virtual Teacher? IdTeacherNavigation { get; set; }
}
