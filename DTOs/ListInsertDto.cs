using System.ComponentModel.DataAnnotations;

namespace pMan.DTOs
{
    public class ListInsertDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public long BoardId { get; set; }
    }
}
