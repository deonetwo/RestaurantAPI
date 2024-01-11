using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }
        public required string customerName { get; set; }
        public required string email { get; set; }
        public required string phoneNumber { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}
