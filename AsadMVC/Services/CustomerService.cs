using DTOs;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services
{
    public class CustomerService
    {
        public CustomerListDTO DisplayAll()
        {
            CustomerListDTO customerListDTO = new CustomerListDTO();
            CustomerRepository repository = new CustomerRepository();

            try
            {
                customerListDTO = repository.DisplayAll();
            }
            catch (Exception e)
            {
                customerListDTO.Result = false;
                customerListDTO.Message.Add(new Message("", e.Message));
            }

            return customerListDTO;
        }

        public CustomerDTO Display(long ID)
        {
            CustomerDTO customerDTO = new CustomerDTO();
            CustomerRepository repository = new CustomerRepository();

            try
            {
                customerDTO = repository.Display(ID);
            }
            catch (Exception e)
            {
                customerDTO.Result = false;
                customerDTO.Message.Add(new Message("", e.Message));
            }


            return customerDTO;
        }

        public ResponseDTO Create(CustomerDTO customerDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();

            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    responseDTO = BusinessValidate(customerDTO);

                    if (responseDTO.Message.Count == 0)
                    {
                        CustomerRepository repository = new CustomerRepository();

                        repository.Create(customerDTO);
                        responseDTO.Result = true;
                        transactionScope.Complete();
                    }
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    responseDTO.Result = false;
                    responseDTO.Message.Add(new Message("", e.Message));
                }
            }
            return responseDTO;

        }

        public ResponseDTO Edit(CustomerDTO customerDTO)
        {

            ResponseDTO responseDTO = new ResponseDTO();
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    responseDTO = BusinessValidate(customerDTO);
                    if (responseDTO.Message.Count == 0)
                    {
                        CustomerRepository repository = new CustomerRepository();

                        repository.Edit(customerDTO);
                        responseDTO.Result = true;
                        transactionScope.Complete();
                    }
                }
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    responseDTO.Result = false;
                    responseDTO.Message.Add(new Message("", e.Message));
                }
            }


            return responseDTO;

        }
        public bool Delete(long ID)
        {
            CustomerRepository repository = new CustomerRepository();

            repository.Delete(ID);
            return true;
        }

        private ResponseDTO BusinessValidate(CustomerDTO customerDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();

            if (string.IsNullOrEmpty(customerDTO.Name))
            {
                responseDTO.Message.Add(new Message("Name", "Name is mandatory"));
            }

            if (string.IsNullOrEmpty(customerDTO.Father))
            {
                responseDTO.Message.Add(new Message("Father", "Father is mandatory"));
            }

            if (string.IsNullOrEmpty(customerDTO.AccountNo))
            {
                responseDTO.Message.Add(new Message("AccountNo", "AccountNo is mandatory"));
            }

            if (string.IsNullOrEmpty(customerDTO.CNIC))
            {
                responseDTO.Message.Add(new Message("CNIC", "CNIC is mandatory"));
            }
            
            if (string.IsNullOrEmpty(customerDTO.Branch))
            {
                responseDTO.Message.Add(new Message("Branch", "Branch is mandatory"));
            }

            return responseDTO;
        }
    }
}
