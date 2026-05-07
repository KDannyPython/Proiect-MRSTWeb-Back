using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer; 
using HealthMonitor.Domain.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace HealthMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminLogic _adminLogic;

        public AdminController()
        {
            var bl = new BusinessLogic();
            _adminLogic = bl.GetAdminLogic();
        }

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminCreateDto adminDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _adminLogic.CreateAdmin(adminDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetAdminById/{id}")]
        public IActionResult GetAdminById(int id)
        {
            var response = _adminLogic.GetAdminById(id);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("GetAllAdmins")]
        public IActionResult GetAdminList()
        {
            var response = _adminLogic.GetAdminList();
            return Ok(response);
        }

        [HttpPut("UpdateAdmin/{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] AdminCreateDto adminDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var response = _adminLogic.UpdateAdmin(id, adminDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteAdmin/{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            var response = _adminLogic.DeleteAdmin(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
