using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Entity
{
    public class Customers
    {
        [Key]
        public int customerId { get; set; }
        public string password { get; set; }
        public string contactName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
