using System.ComponentModel.DataAnnotations;

namespace pMan.DTOs
{
    public class BoardDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
