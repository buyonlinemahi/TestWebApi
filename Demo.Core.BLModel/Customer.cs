using System.ComponentModel.DataAnnotations;
namespace Demo.Core.BLModel
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    }
}
