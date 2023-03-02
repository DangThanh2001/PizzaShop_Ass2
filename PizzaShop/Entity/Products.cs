using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Entity
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public Supply suppliersId { get; set; }
        public int supplyId { get; set; }
        public Category categoriesId { get; set; }
        public int categoryId { get; set; }
        public int quantityPerUnit { get; set; }
        public double unitPrice { get; set; }
        public string productImage { get; set; }
        public ICollection<OrderDetails> orderDetails { get; set; }
    }
}
