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
    public class CustomerRepository
    {

        public CustomerListDTO DisplayAll()
        {
            CustomerListDTO customerList = new CustomerListDTO();

            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Customer with (nolock)";
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
                    CustomerDTO dTO = new CustomerDTO();

                    dTO.Id = long.Parse(Dr["Id"].ToString());
                    dTO.Name = Dr["Name"].ToString();
                    dTO.Father = Dr["Father"].ToString();
                    dTO.AccountNo = Dr["AccountNo"].ToString();
                    dTO.CNIC = Dr["CNIC"].ToString();
                    dTO.Branch = Dr["Branch"].ToString();
                    customerList.Customers.Add(dTO);
                }

            }
            return customerList;
        }

        public CustomerDTO Display(long ID)
        {
            CustomerDTO dTO = new CustomerDTO();

            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("id", ID);
            cmd.CommandText = "select * from Testemployee where id=@id with (nolock)";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds;
            ds = new DataSet();
            sda.Fill(ds);
            mCnn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dTO.Id = long.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                dTO.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                dTO.Father = ds.Tables[0].Rows[0]["Father"].ToString();
                dTO.AccountNo = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                dTO.CNIC = ds.Tables[0].Rows[0]["CNIC"].ToString();
                dTO.Branch = ds.Tables[0].Rows[0]["Branch"].ToString();
               
            }
            return dTO;


        }

        public bool Create(CustomerDTO customerDTO)
        {
            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("name", customerDTO.Name);
            cmd.Parameters.AddWithValue("father", customerDTO.Father);
            cmd.Parameters.AddWithValue("accNo", customerDTO.AccountNo);
            cmd.Parameters.AddWithValue("cnic", customerDTO.CNIC);
            cmd.Parameters.AddWithValue("branch", customerDTO.Branch);
            cmd.CommandText = "insert into Customer values(@accNo, @cnic, @name, @father, @branch)";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds;
            ds = new DataSet();
            sda.Fill(ds);
            mCnn.Close();
            return true;
        }

        public bool Edit(CustomerDTO customerDTO)
        {
            SqlConnection mCnn = new SqlConnection(); ;
            mCnn.ConnectionString = "Password=login.123;Persist Security Info=True;User ID=sa;Initial Catalog=axeeed;Data Source=10.51.41.27;Max Pool Size=100";
            mCnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mCnn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("id", customerDTO.Id);
            cmd.Parameters.AddWithValue("name", customerDTO.Name);
            cmd.Parameters.AddWithValue("father", customerDTO.Father);
            cmd.Parameters.AddWithValue("accNo", customerDTO.AccountNo);
            cmd.Parameters.AddWithValue("cnic", customerDTO.CNIC);
            cmd.Parameters.AddWithValue("branch", customerDTO.Branch);
            cmd.CommandText = "update Customer set name=@name, father=@father, AccountNo=@accNo, CNIC=@cnic, Branch=@branch where id=@id";
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
            cmd.CommandText = "delete from Customer where id=@id";
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
