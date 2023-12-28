namespace pMan.Models{
    public class CardModel {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long ParentListId { get; set; }
        public long OrderValue { get; set; }
        public virtual ICollection<CardAssignedToUserModel> CardAssignedToUsers { get; } = new List<CardAssignedToUserModel>();
        public virtual UserModel CreatedByNavigation { get; set; } = null!;
        public virtual ListModel ParentList { get; set; } = null!;
        public virtual UserModel UpdatedByNavigation { get; set; } = null!;
    }
}
