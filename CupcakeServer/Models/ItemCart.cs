using CupcakeServer.Models.Items;

namespace CupcakeServer.Models
{
    public class ItemCart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item item { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
    }
}
