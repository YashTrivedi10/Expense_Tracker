using System.ComponentModel.DataAnnotations;

namespace Expence_tracker.Models
{ 

    public class Limit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Value { get; set; }
    }
}
