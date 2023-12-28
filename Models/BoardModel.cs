namespace pMan.Models
{
    public class BoardModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public ICollection<ListModel> Lists { get; set; } = new List<ListModel>();
    }
}
