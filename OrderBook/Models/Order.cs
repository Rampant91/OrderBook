using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderBook.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public bool Enabled { get; set; } = false;

        public string? Name { get; set; }

        public string? Date { get; set; }

        public string? Price { get; set; }

        public string? Amount { get; set; }

        public string? Discription { get; set; }
    }
}