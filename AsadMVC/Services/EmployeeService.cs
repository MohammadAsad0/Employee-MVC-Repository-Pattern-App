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
    public class EmployeeService
    {
        public EmployeeListDTO DisplayAll()
        {
            EmployeeListDTO employeeList = new EmployeeListDTO();
            EmployeeRepository repository = new EmployeeRepository();

            try
            {
                employeeList = repository.DisplayAll();
            }
            catch (Exception e)
            {
                employeeList.Result = false;
                employeeList.Message.Add(new Message("", e.Message));
            }

            return employeeList;
        }

        public EmployeeDTO Display(long ID)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            EmployeeRepository repository = new EmployeeRepository();

            try
            {
                employeeDTO = repository.Display(ID);
            }
            catch (Exception e)
            {
                employeeDTO.Result = false;
                employeeDTO.Message.Add(new Message("", e.Message));
            }


            return employeeDTO;
        }

        public ResponseDTO Create(EmployeeDTO employeeDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();

            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    responseDTO = BusinessValidate(employeeDTO);

                    if (responseDTO.Message.Count == 0)
                    {
                        EmployeeRepository repository = new EmployeeRepository();

                        repository.Create(employeeDTO);
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

        public ResponseDTO Edit(EmployeeDTO employeeDTO)
        {

            ResponseDTO responseDTO = new ResponseDTO();
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    responseDTO = BusinessValidate(employeeDTO);
                    if (responseDTO.Message.Count == 0)
                    {
                        EmployeeRepository repository = new EmployeeRepository();

                        repository.Edit(employeeDTO);
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
            EmployeeRepository repository = new EmployeeRepository();

            repository.Delete(ID);
            return true;
        }

        private ResponseDTO BusinessValidate(EmployeeDTO employeeDTO)
        {
            ResponseDTO responseDTO = new ResponseDTO();

            if (string.IsNullOrEmpty(employeeDTO.Name))
            {
                responseDTO.Message.Add(new Message("Name", "Name is mandatory"));
            }

            if (string.IsNullOrEmpty(employeeDTO.Father))
            {
                responseDTO.Message.Add(new Message("Father", "Father is mandatory"));
            }

            if (string.IsNullOrEmpty(employeeDTO.Designation))
            {
                responseDTO.Message.Add(new Message("Designation", "Designation is mandatory"));
            }

            if (string.IsNullOrEmpty(employeeDTO.Department))
            {
                responseDTO.Message.Add(new Message("Department", "Department is mandatory"));
            }

            return responseDTO;
        }
    }
}
