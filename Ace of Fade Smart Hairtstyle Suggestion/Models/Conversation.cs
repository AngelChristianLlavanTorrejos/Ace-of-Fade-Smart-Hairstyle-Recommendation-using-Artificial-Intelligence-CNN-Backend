using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

public partial class Conversation
{
    [Key]
    public int Id { get; set; }

    public int SenderId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? SentAt { get; set; }

    public int ChatRoomId { get; set; }

    [ForeignKey("ChatRoomId")]
    [InverseProperty("Conversations")]
    public virtual ChatRoom ChatRoom { get; set; } = null!;
}
