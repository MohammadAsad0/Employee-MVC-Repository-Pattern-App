using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Route("EmployeeAPI")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [Route("~/EmployeeAPI/XGetAll")]
        [HttpPost]
        public async Task<ActionResult<EmployeeListDTO>> XGetAll()
        {
            EmployeeService service = new EmployeeService();
            EmployeeListDTO dTO = service.DisplayAll();

            return dTO;
        }

        [Route("~/EmployeeAPI/XGet")]
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> XGet(IDDto dto)
        {
            EmployeeService service = new EmployeeService();
            EmployeeDTO dTO = service.Display(dto.ID);

            return dTO;
        }


        [Route("~/EmployeeAPI/XCreate")]
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> XCreate(EmployeeDTO dto)
        {
            EmployeeService service = new EmployeeService();
            ResponseDTO dTO = service.Create(dto);

            return dTO;
        }

        [Route("~/EmployeeAPI/XEdit")]
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> XEdit(EmployeeDTO dto)
        {
            EmployeeService service = new EmployeeService();
            ResponseDTO dTO = service.Edit(dto);

            return dTO;
        }

        [Route("~/EmployeeAPI/XDelete")]
        [HttpPost]
        public async Task<ActionResult<bool>> XDelete(IDDto dto)
        {
            EmployeeService service = new EmployeeService();
            bool response = service.Delete(dto.ID);

            return response;
        }
    }


}
