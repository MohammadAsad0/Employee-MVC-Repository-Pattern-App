namespace AsadMVC.Models
{
    public class CustomerModel
    {
        
        public long Id { get; set; }
        public string? AccountNo { get; set; }
        public string? CNIC { get; set; }
        public string? Name { get; set; }
        public string? Father { get; set; }
        public string? Branch { get; set; }

    
    }
    public class CustomerListModel
    {
        public CustomerListModel()
        {
            Customers = new List<CustomerModel>();
        }

        public List<CustomerModel> Customers { get; set; }
    }
}
