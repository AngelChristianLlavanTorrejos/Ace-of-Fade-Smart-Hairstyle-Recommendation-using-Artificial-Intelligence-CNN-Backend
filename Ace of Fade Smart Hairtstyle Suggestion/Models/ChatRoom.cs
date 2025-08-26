using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

public partial class ChatRoom
{
    [Key]
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int AdminId { get; set; }

    [ForeignKey("AdminId")]
    [InverseProperty("ChatRoomAdmins")]
    public virtual User Admin { get; set; } = null!;

    [ForeignKey("ClientId")]
    [InverseProperty("ChatRoomClients")]
    public virtual User Client { get; set; } = null!;

    [InverseProperty("ChatRoom")]
    public virtual ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();
}
