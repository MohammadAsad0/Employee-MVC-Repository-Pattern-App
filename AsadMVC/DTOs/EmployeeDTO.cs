using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EmployeeDTO:ResponseDTO
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Father { get; set; }
        public String Designation { get; set; }
        public String Department { get; set; }

        //public EmployeeDTO(int id, string name, string father, string designation, string department)
        //{
        //    Id = id;
        //    Name = name;
        //    Father = father;
        //    Designation = designation;
        //    Department = department;
        //}
    }

    public class EmployeeListDTO:ResponseDTO
    {

        public EmployeeListDTO()
        {
            Employees = new List<EmployeeDTO>();
        }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
