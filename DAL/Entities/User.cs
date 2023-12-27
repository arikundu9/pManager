using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pMan.DAL.Entities;

[Table("user")]
public partial class User
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

    [InverseProperty("User")]
    public virtual ICollection<CardAssignedToUser> CardAssignedToUsers { get; } = new List<CardAssignedToUser>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Card> CardCreatedByNavigations { get; } = new List<Card>();

    [InverseProperty("UpdatedByNavigation")]
    public virtual ICollection<Card> CardUpdatedByNavigations { get; } = new List<Card>();
}
