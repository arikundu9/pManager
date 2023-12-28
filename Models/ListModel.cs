namespace pMan.Models{
    public class ListModel {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long ParentBoardId { get; set; }
        public long OrderValue { get; set; }
        public virtual ICollection<CardModel> Cards { get; } = new List<CardModel>();
        public virtual BoardModel ParentBoard { get; set; } = null!;
    }
}
