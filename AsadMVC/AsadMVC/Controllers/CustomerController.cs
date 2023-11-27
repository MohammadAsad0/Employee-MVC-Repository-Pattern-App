using AsadMVC.Models;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Reflection;

namespace AsadMVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            CustomerService service = new CustomerService();
            CustomerListDTO result = service.DisplayAll();

            CustomerListModel model = new CustomerListModel();

            if (!result.Result)
            {
                foreach (Message item in result.Message)
                {
                    ModelState.AddModelError(item.Key, item.ErrorMsg);
                }
            }

            foreach (CustomerDTO item in result.Customers)
            {
                CustomerModel customerModel = new CustomerModel();
                customerModel.Id = item.Id;
                customerModel.Name = item.Name;
                customerModel.Father = item.Father;
                customerModel.AccountNo = item.AccountNo;
                customerModel.CNIC = item.CNIC;
                customerModel.Branch = item.Branch;

                model.Customers.Add(customerModel);
            }

            return View(model);
        }

        public IActionResult Create()
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerService service = new CustomerService();
                CustomerDTO customerDTO = new CustomerDTO();

                customerDTO.AccountNo = model.AccountNo;
                customerDTO.CNIC = model.CNIC;
                customerDTO.Name = model.Name;
                customerDTO.Father = model.Father;
                customerDTO.Branch = model.Branch;

                ResponseDTO response = service.Create(customerDTO);

                if (!response.Result)
                {
                    foreach (Message item in response.Message)
                    {
                        ModelState.AddModelError(item.Key, item.ErrorMsg);
                    }
                    return View(model);
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(long? id)
        {
            CustomerService service = new CustomerService();

            CustomerDTO result = service.Display((long)id);

            CustomerModel model = new CustomerModel();

            model.Id = result.Id;
            model.Name = result.Name;
            model.Father = result.Father;
            model.AccountNo = result.AccountNo;
            model.CNIC = result.CNIC;
            model.Branch = result.Branch;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerService service = new CustomerService();
                CustomerDTO dTO = new CustomerDTO();

                dTO.Id = model.Id;
                dTO.Name = model.Name;
                dTO.Father = model.Father;
                dTO.AccountNo = model.AccountNo;
                dTO.CNIC = model.CNIC;
                dTO.Branch = model.Branch;

                ResponseDTO responseDTO = service.Edit(dTO);

                if (!responseDTO.Result)
                {
                    foreach (Message item in responseDTO.Message)
                    {
                        ModelState.AddModelError(item.Key, item.ErrorMsg);
                    }
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(long? id)
        {
            CustomerService service = new CustomerService();

            service.Delete((long)id);

            return RedirectToAction("Index");
        }
        public IActionResult Display(long? id)
        {
            CustomerService service = new CustomerService();

            CustomerDTO result = service.Display((long)id);

            CustomerModel model = new CustomerModel();

            if (!result.Result)
            {
                foreach (Message item in result.Message)
                {
                    ModelState.AddModelError(item.Key, item.ErrorMsg);
                }
            }

            model.Id = result.Id;
            model.Name = result.Name;
            model.Father = result.Father;
            model.AccountNo = result.AccountNo;
            model.CNIC = result.CNIC;
            model.Branch = result.Branch;

            return View(model);
        }
    }
}
