using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Room
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}