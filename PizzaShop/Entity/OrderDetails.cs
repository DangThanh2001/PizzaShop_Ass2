using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Entity
{
    public class OrderDetails
    {
        [Key]
        public int orderDetailId { get; set; }
        public Orders orders { get; set; }
        public int orderId { get; set; }
        public Products products { get; set; }
        public int productId { get; set; }
        public Double unitPrice { get; set; }
        public int quantity { get; set; }
    }
}
