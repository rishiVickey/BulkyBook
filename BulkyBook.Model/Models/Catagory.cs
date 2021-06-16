using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Model.Models
{
    public class Catagory
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
