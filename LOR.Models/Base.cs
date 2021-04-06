using System.ComponentModel.DataAnnotations;

namespace LOR.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
