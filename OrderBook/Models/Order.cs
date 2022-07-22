using System.ComponentModel.DataAnnotations;

namespace OrderBook.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Date { get; set; }

        public string? Price { get; set; }

        public string? Amount { get; set; }

        public string? Discription { get; set; }
    }
}
