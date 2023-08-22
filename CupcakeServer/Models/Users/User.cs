
namespace CupcakeServer.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public UserCredential credential { get; set; }
        public List<Order> Orders { get;set; } 
        public List<Delivery> Deliveries { get;set; } 

    }

    public enum UserCredential
    {
        administrator = 1,
        driver = 2,
        customer = 3
    }
}
