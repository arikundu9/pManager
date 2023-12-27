namespace pMan.Models{
    public class CardModel {
        public long Id { get; set; }
        public TimeOnly CreatedAt { get; set; }
        public TimeOnly UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long ParentListId { get; set; }
        public long OrderValue { get; set; }
        public virtual ICollection<CardAssignedToUser> CardAssignedToUsers { get; } = new List<CardAssignedToUser>();
        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual List ParentList { get; set; } = null!;
        public virtual User UpdatedByNavigation { get; set; } = null!;
    }
}