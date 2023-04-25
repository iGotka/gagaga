using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class Student
{
    public int IdStudent { get; set; }

    public string? FiestName { get; set; }

    public string? LastName { get; set; }

    public string? PatronomicName { get; set; }

    public int? IdProfession { get; set; }

    public int? IdFormTime { get; set; }

    public int? IdGroup { get; set; }

    public int? IdYearAdd { get; set; }

    public virtual ICollection<History> Histories { get; } = new List<History>();

    public virtual FormTime? IdFormTimeNavigation { get; set; }

    public virtual Group? IdGroupNavigation { get; set; }

    public virtual Profession? IdProfessionNavigation { get; set; }

    public virtual YearAdd? IdYearAddNavigation { get; set; }

    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();
}
