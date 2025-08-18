using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

public partial class BarberReview
{
    [Key]
    public int Id { get; set; }

    public int BarberId { get; set; }

    public int ClientId { get; set; }

    public int Stars { get; set; }

    public string? Comments { get; set; }
}
