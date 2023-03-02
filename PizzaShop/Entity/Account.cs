using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Entity
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int accountId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public int type { get; set; }
    }
}
