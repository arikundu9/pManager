namespace pMan.Models{
    public class CardAssignedToUserModel {
        public long Id { get; set; }
        public TimeOnly CreatedAt { get; set; }
        public TimeOnly UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long CardId { get; set; }
        public long UserId { get; set; }
        public virtual CardModel Card { get; set; } = null!;
        public virtual UserModel User { get; set; } = null!;
    }
}
