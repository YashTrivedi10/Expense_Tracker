using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Expence_tracker.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ExpName{ get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? ExpDesc { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
