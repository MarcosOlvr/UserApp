using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Repository.Contracts;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<dynamic>> Get([FromRoute] int id)
        {
            var user = _userRepository.GetUser(id);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<dynamic>> Create([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = _userRepository.CreateUser(model);

            return StatusCode(201, user);
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<ActionResult<dynamic>> Update([FromRoute] int id, [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = _userRepository.UpdateUser(id, model);

            if (user == null) 
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<dynamic>> Delete([FromRoute] int id)
        {
            bool conf = _userRepository.DeleteUser(id);

            if (!conf)
                return BadRequest();

            return Ok();
        }
    }
}
