using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pMan.DAL.Entities;

[Table("card_assigned_to_user")]
[Index("CardId", "UserId", Name = "card_assigned_to_user_pk_carduser", IsUnique = true)]
public partial class CardAssignedToUser
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [Column("created_by")]
    public long CreatedBy { get; set; }

    [Column("updated_by")]
    public long? UpdatedBy { get; set; }

    [Column("card_id")]
    public long CardId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("CardId")]
    [InverseProperty("CardAssignedToUsers")]
    public virtual Card Card { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("CardAssignedToUsers")]
    public virtual User User { get; set; } = null!;
}
