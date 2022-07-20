namespace CRM.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public Product InterestProduct { get; set; }

        public int AsignedSeller { get; set; }
        

    }

    public enum Product
    {
        Training,
        Hardware,
        Licence
    }
    
}