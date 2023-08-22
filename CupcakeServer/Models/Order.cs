using CupcakeServer.Models.Items;
using CupcakeServer.Models.Users;

namespace CupcakeServer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get;set; }

    }
}
