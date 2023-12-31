﻿using CupcakeServer.Models.Users;

namespace CupcakeServer.Models.Items
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<ItemCart> ItemCarts { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public int StockAmount { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
    }
}
