using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pMan.DAL.Entities;

[Table("list")]
public partial class List
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

    [Column("parent_board_id")]
    public long ParentBoardId { get; set; }

    [Column("order_value")]
    public long OrderValue { get; set; }

    [InverseProperty("ParentList")]
    public virtual ICollection<Card> Cards { get; } = new List<Card>();

    [ForeignKey("ParentBoardId")]
    [InverseProperty("Lists")]
    public virtual Board ParentBoard { get; set; } = null!;
}
