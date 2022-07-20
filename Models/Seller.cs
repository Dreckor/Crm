using System.Text.Json.Serialization;
namespace CRM.Models
{
    public class Seller
    {
        public int SellerId { get; set; }

        public string SellerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Customer>? Customers {get;set;}

    }
}