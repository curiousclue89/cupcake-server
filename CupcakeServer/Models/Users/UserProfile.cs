namespace CupcakeServer.Models.Users
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
