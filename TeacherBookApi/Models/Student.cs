using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class Student
{
    [ValidateNever]
    public int IdStudent { get; set; }

    public string? FiestName { get; set; }

    public string? LastName { get; set; }

    public string? PatronomicName { get; set; }

    public int? IdProfession { get; set; }

    public int? IdFormTime { get; set; }

    public int? IdGroup { get; set; }

    public int? IdYearAdd { get; set; }
    [ValidateNever]
    public virtual ICollection<History> Histories { get; } = new List<History>();
    [ValidateNever]
    public virtual FormTime? IdFormTimeNavigation { get; set; }
    [ValidateNever]
    public virtual Group? IdGroupNavigation { get; set; }
    [ValidateNever]
    public virtual Profession? IdProfessionNavigation { get; set; }
    [ValidateNever]
    public virtual YearAdd? IdYearAddNavigation { get; set; }
    [ValidateNever]
    public virtual ICollection<Journal> Journals { get; } = new List<Journal>();
}
