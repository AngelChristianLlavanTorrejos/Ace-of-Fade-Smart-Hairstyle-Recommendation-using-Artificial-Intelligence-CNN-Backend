using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

[Index("Email", Name = "UQ__Users__A9D105348085B820", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string Role { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? ContactNumber { get; set; }

    public string? Address { get; set; }

    [StringLength(255)]
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateOnly RegistrationDate { get; set; }

    [InverseProperty("Client")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
