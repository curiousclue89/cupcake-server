namespace CupcakeServer.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }

        
    }

    public enum PaymentMethod
    {
        Card = 1,
        PIX = 2,
        DINHEIRO = 3
    }

}
