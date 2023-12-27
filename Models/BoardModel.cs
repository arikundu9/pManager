namespace pMan.Models{
    public class BoardModel {
        public long Id { get; set; }
        public TimeOnly CreatedAt { get; set; }
        public TimeOnly UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public virtual ICollection<ListModel> Lists { get; } = new List<ListModel>();
    }
}
