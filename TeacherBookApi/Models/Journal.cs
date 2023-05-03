using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeacherBookApi.Models;

public partial class Journal
{
    [ValidateNever]
    public int IdJournal { get; set; }

    public int IdStudent { get; set; }

    public int? IdSubject { get; set; }
    [Range(1, 5, ErrorMessage = "недопустимая оценка")]

    public int? Evaluation { get; set; }

    public int? IdGroup { get; set; }

    [ValidateNever]
    public virtual Group? IdGroupNavigation { get; set; }
    [ValidateNever]
    public virtual Student IdStudentNavigation { get; set; } = null!;
    [ValidateNever]
    public virtual Subject? IdSubjectNavigation { get; set; }
}
