using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    [StringLength(30,ErrorMessage ="your userName is to long")]
    public string? UserName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
