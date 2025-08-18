using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

public partial class Appointment
{
    [Key]
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int BarberId { get; set; }

    public int? StatusId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly TimeIn { get; set; }

    public TimeOnly TimeOut { get; set; }

    public string? Message { get; set; }

    public string? Haircut { get; set; }

    [ForeignKey("BarberId")]
    [InverseProperty("Appointments")]
    public virtual Barber Barber { get; set; } = null!;

    [ForeignKey("ClientId")]
    [InverseProperty("Appointments")]
    public virtual User Client { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("Appointments")]
    public virtual AppointmentStatus? Status { get; set; }
}
