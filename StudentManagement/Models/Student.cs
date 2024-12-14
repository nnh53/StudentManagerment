using System;
using System.Collections.Generic;

namespace StudentManagement.Models;

public partial class Student
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid RoomId { get; set; }

    public virtual Room Room { get; set; } = null!;
}