using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository
    {
        public EmployeeListDTO DisplayAll()
        {
            EmployeeListDTO employeeList = new EmployeeListDTO();

            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Testemployee";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds;
            ds = new DataSet();
            sda.Fill(ds);
            mCnn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow Dr = ds.Tables[0].Rows[i];
                    EmployeeDTO dTO = new EmployeeDTO();

                    dTO.Id = long.Parse(Dr["Id"].ToString());
                    dTO.Name = Dr["Name"].ToString();
                    dTO.Father = Dr["Father"].ToString();
                    dTO.Designation = Dr["Designation"].ToString();
                    dTO.Department = Dr["Department"].ToString();
                    employeeList.Employees.Add(dTO);
                }

            }
            return employeeList;
        }
        
        public EmployeeDTO Display(long ID)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();

            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("id", ID);
            cmd.CommandText = "select * from Testemployee where id=@id";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds;
            ds = new DataSet();
            sda.Fill(ds);
            mCnn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                employeeDTO.Id = long.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                employeeDTO.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                employeeDTO.Father = ds.Tables[0].Rows[0]["Father"].ToString();
                employeeDTO.Designation = ds.Tables[0].Rows[0]["Designation"].ToString();
                employeeDTO.Department = ds.Tables[0].Rows[0]["Department"].ToString();
            }
            return employeeDTO;


        }

        public bool Create(EmployeeDTO employeeDTO)
        {
            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("name", employeeDTO.Name);
            cmd.Parameters.AddWithValue("father", employeeDTO.Father);
            cmd.Parameters.AddWithValue("designation", employeeDTO.Designation);
            cmd.Parameters.AddWithValue("department", employeeDTO.Department);
            cmd.CommandText = "insert into Testemployee values(@name, @father, @designation, @department)";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds;
            ds = new DataSet();
            sda.Fill(ds);
            mCnn.Close();
            return true;
        }

        public bool Edit(EmployeeDTO employeeDTO)
        {
            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("id", employeeDTO.Id);
            cmd.Parameters.AddWithValue("name", employeeDTO.Name);
            cmd.Parameters.AddWithValue("father", employeeDTO.Father);
            cmd.Parameters.AddWithValue("designation", employeeDTO.Designation);
            cmd.Parameters.AddWithValue("department", employeeDTO.Department);
            cmd.CommandText = "update Testemployee set name=@name, father=@father, designation=@designation, department=@department where id=@id";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds;
            ds = new DataSet();
            sda.Fill(ds);
            mCnn.Close();

            return true;
        }

        public bool Delete(long ID)
        {
            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("id", ID);
            cmd.CommandText = "delete from Testemployee where id=@id";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds;
            ds = new DataSet();
            sda.Fill(ds);
            mCnn.Close();

            return true;
        }
    }
}
