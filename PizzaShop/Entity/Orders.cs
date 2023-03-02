using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Entity
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }
        public int customerId { get; set; }
        public Customers customers { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime shippedDate { get; set; }
        public string freight { get; set; }
        public string shipAddress { get; set; }
        public ICollection<OrderDetails> orderDetails { get; set; }
    }
}
