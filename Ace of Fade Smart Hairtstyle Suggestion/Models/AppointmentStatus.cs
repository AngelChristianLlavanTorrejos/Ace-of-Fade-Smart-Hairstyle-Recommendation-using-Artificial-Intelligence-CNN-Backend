using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

[Table("AppointmentStatus")]
public partial class AppointmentStatus
{
    [Key]
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
