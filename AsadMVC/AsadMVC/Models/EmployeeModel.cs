namespace AsadMVC.Models
{
    public class EmployeeModel
    {
        public long Id { get; set; }
        public String? Name { get; set; }
        public String? Father { get; set; }
        public String? Designation { get; set; }
        public String? Department { get; set; }

        //public EmployeeModel(int id, string name, string father, string designation, string department)
        //{
        //    Id = id;
        //    Name = name;
        //    Father = father;
        //    Designation = designation;
        //    Department = department;
        //}
    }

    public class EmployeeListModel
    {
        public List<EmployeeModel> Employees { get; set; }

        public EmployeeListModel()
        {
            Employees = new List<EmployeeModel>();
        }
    }
}


