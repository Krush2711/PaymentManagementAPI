using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentManagementAPI.DTOs.User;
using PaymentManagementAPI.Interfaces;
using static PaymentManagementAPI.DTOs.User.DataAnnotations;

namespace PaymentManagementAPI.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            [Authorize(Roles = "Admin")]
            [HttpGet]

        public IActionResult GetAllUsers()
            {
                return Ok(_userService.GetAllUsers());
            }

            [HttpGet("{id}")]
            public IActionResult GetUserById(int id)
            {
                var user = _userService.GetUserById(id);

                if (user == null)
                    return NotFound("User not found.");

                return Ok(user);
            }

            [HttpPost]
            public IActionResult AddUser(CreateUserDto dto)
            {
            var result = _userService.AddUser(dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

            [HttpPut("{id}")]
            public IActionResult UpdateUser(int id, UpdateUserDto dto)
            {
                bool updated = _userService.UpdateUser(id, dto);

                if (!updated)
                    return NotFound("User not found.");

                return Ok("User Updated Successfully");
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteUser(int id)
            {
                bool deleted = _userService.DeleteUser(id);

                if (!deleted)
                    return NotFound("User not found.");

                return Ok("User Deleted Successfully");
            }

        [Authorize(Roles = "Admin")]
        [HttpPatch("soft-delete/{id}")]
        public IActionResult SoftDeleteUser(int id)
        {
            bool deleted = _userService.SoftDeleteUser(id);

            if (!deleted)
            {
                return NotFound("User not found.");
            }

            return Ok("User deactivated successfully.");
        }

    }

    }

