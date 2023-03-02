using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Entity
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; } 
        public string categoryName { get; set; }
        public string description { get; set; }
    }
}
