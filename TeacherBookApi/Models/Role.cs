using System;
using System.Collections.Generic;

namespace TeacherBookApi.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
