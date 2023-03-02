using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Entity
{
    public class Supply
    {
        [Key]
        public int supplierId { get; set; }
        public string companyName { get; set;}
        public string address { get; set;}
        public string phone { get; set;}
    }
}
