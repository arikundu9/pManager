using System.ComponentModel.DataAnnotations;

namespace pMan.DTOs
{
    public class CardInsertDto
    {
        public string? Body { get; set; }
        [Required]
        public long ListId { get; set; }
    }
}
