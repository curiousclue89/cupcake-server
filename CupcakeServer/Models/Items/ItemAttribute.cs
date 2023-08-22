namespace CupcakeServer.Models.Items
{
    public class ItemAttribute
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string description { get; set; }

    }
}
