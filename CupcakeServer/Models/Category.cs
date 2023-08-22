using CupcakeServer.Models.Items;

namespace CupcakeServer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public List<ItemCategory> ItemCategories { get; set; }
        public string Description { get; set; }
    }
}
