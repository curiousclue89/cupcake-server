using CupcakeServer.Models.Users;

namespace CupcakeServer.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Status { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }


    }
}
