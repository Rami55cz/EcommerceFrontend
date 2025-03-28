using System;

namespace EcommerceFrontend.Models{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Pending"; // Shipped, Delivered

        public int UserId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}