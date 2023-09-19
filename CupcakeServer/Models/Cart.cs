namespace CupcakeServer.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public List<ItemCart> ItemCarts { get; set; }

    }
}
