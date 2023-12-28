namespace pMan.Models{
    public class UserModel {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public virtual ICollection<CardAssignedToUserModel> CardAssignedToUsers { get; } = new List<CardAssignedToUserModel>();
        public virtual ICollection<CardModel> CardCreatedByNavigations { get; } = new List<CardModel>();
        public virtual ICollection<CardModel> CardUpdatedByNavigations { get; } = new List<CardModel>();
    }
}
