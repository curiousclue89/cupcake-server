using CupcakeServer.Models.Users;

namespace CupcakeServer.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Price { get; set; }
        public List<ItemCart> ItemCarts { get; set; }

    }
}
