using System.ComponentModel.DataAnnotations;

namespace OrderBook.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public string Discription { get; set; }
    }
}
