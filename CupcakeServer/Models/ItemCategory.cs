using CupcakeServer.Models.Items;

namespace CupcakeServer.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
