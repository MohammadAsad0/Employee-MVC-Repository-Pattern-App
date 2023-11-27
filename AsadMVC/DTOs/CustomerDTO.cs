using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CustomerDTO: ResponseDTO
    {
        public long Id { get; set; }
        public string AccountNo { get; set; }
        public string CNIC { get; set; }
        public string Name { get; set; }
        public string Father { get; set; }
        public string Branch { get; set; }

    }
    public class CustomerListDTO: ResponseDTO
    {
        public CustomerListDTO()
        {
            Customers = new List<CustomerDTO>();
        }

        public List<CustomerDTO> Customers { get; set; }
    }
}
