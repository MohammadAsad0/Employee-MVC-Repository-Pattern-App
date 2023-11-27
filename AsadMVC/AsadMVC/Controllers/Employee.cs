using AsadMVC.Models;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace AsadMVC.Controllers
{
    public class Employee : Controller
    {
        public IActionResult Index()
        {
            EmployeeService employeeService = new EmployeeService();
            EmployeeListDTO result = employeeService.DisplayAll();

            EmployeeListModel model = new EmployeeListModel();

            if(!result.Result)
            {
                foreach (Message item in result.Message)
                {
                    ModelState.AddModelError(item.Key, item.ErrorMsg);
                }
            }
          
            foreach (EmployeeDTO item in result.Employees)
            {
                EmployeeModel employeeModel = new EmployeeModel();
                employeeModel.Id = item.Id;
                employeeModel.Name = item.Name;
                employeeModel.Father = item.Father;
                employeeModel.Department = item.Department;
                employeeModel.Designation = item.Designation;

                model.Employees.Add(employeeModel);
            }
            
            return View(model);
        }
        public IActionResult Create()
        {
            EmployeeModel employee = new EmployeeModel();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeService service = new EmployeeService();
                EmployeeDTO dTO = new EmployeeDTO();

                dTO.Name = employee.Name;
                dTO.Father = employee.Father;
                dTO.Department = employee.Department;
                dTO.Designation = employee.Designation;

                ResponseDTO responseDTO = service.Create(dTO);

                if (!responseDTO.Result)
                {
                    foreach (Message item in responseDTO.Message)
                    {
                        ModelState.AddModelError(item.Key, item.ErrorMsg);
                    }
                    return View(employee);
                }
                return RedirectToAction("Index");

            }

            return View(employee);
        }
        public IActionResult Edit(long? id)
        {
            EmployeeService employeeService = new EmployeeService();

            EmployeeDTO result = employeeService.Display((long)id);

            EmployeeModel model = new EmployeeModel();

            model.Id = result.Id;
            model.Name = result.Name;
            model.Father = result.Father;
            model.Department = result.Department;
            model.Designation = result.Designation;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeService service = new EmployeeService();
                EmployeeDTO dTO = new EmployeeDTO();

                dTO.Id = employee.Id;
                dTO.Name = employee.Name;
                dTO.Father = employee.Father;
                dTO.Department = employee.Department;
                dTO.Designation = employee.Designation;

                ResponseDTO responseDTO = service.Edit(dTO);

                if (!responseDTO.Result)
                {
                    foreach (Message item in responseDTO.Message)
                    {
                        ModelState.AddModelError(item.Key, item.ErrorMsg);
                    }
                    return View(employee);
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Delete(long? id)
        {
            EmployeeService service = new EmployeeService();

            service.Delete((long)id);

            return RedirectToAction("Index");
        }
        public IActionResult Display(long? id)
        {
            EmployeeService employeeService = new EmployeeService();

            EmployeeDTO result = employeeService.Display((long)id);

            EmployeeModel model = new EmployeeModel();

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
            model.Department = result.Department;
            model.Designation = result.Designation;

            return View(model);
        }

    }
}
