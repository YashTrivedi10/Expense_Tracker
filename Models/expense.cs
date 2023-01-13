using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace Expence_tracker.Models
{
    public class expense

    {
        
        public string? Name { get; set; }

        [System.ComponentModel.DataAnnotations.Key]
        public int categoryid { get; set; }
        public Category? Category { get; set; }

        public int Amount { get; set; }
    }



}

