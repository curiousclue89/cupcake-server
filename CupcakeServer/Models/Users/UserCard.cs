namespace CupcakeServer.Models.Users
{
    public class UserCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Number { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CCV { get; set; } 
    }
}
