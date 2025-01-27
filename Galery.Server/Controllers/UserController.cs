using BLL.Services;
using EL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService) { 
            _userService = userService;
        }

        // GET: userController
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                bool result = _userService.Create(user);

                if (result) 
                {
                    return CreatedAtAction(nameof(Create), new { id = user.Id }, new
                    {
                        Success = true,
                        Massage = "Usuario Creado",
                        UserId = user.Id
                    });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Success = false,
                    Mesagge = "No se pudo crear el usuario."
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Mesagge = ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new
                {
                    Success = false,
                    Mesagge = ex.Message,
                    Detail = ex.InnerException?.Message
                });

            }
        }

    }
}
