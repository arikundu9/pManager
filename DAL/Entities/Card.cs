using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pMan.DAL.Entities;

[Table("card")]
public partial class Card
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [Column("created_by")]
    public long CreatedBy { get; set; }

    [Column("updated_by")]
    public long? UpdatedBy { get; set; }

    [Column("parent_list_id")]
    public long ParentListId { get; set; }

    [Column("order_value")]
    public long OrderValue { get; set; }

    [InverseProperty("Card")]
    public virtual ICollection<CardAssignedToUser> CardAssignedToUsers { get; } = new List<CardAssignedToUser>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("CardCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ParentListId")]
    [InverseProperty("Cards")]
    public virtual List ParentList { get; set; } = null!;

    [ForeignKey("UpdatedBy")]
    [InverseProperty("CardUpdatedByNavigations")]
    public virtual User? UpdatedByNavigation { get; set; }
}
