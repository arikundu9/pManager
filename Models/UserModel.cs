namespace pMan.Models{
    public class UserModel {
        public long Id { get; set; }
        public TimeOnly CreatedAt { get; set; }
        public TimeOnly UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public virtual ICollection<CardAssignedToUser> CardAssignedToUsers { get; } = new List<CardAssignedToUser>();
        public virtual ICollection<Card> CardCreatedByNavigations { get; } = new List<Card>();
        public virtual ICollection<Card> CardUpdatedByNavigations { get; } = new List<Card>();
    }
}