using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CRUD.BusinessLogicLayer.User _user;
        public UserController(CRUD.BusinessLogicLayer.User user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _user.GetAllUsers();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            var response = await _user.InsertUser(user);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            bool response = await _user.UpdateUser(user);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(User user)
        {
            bool response = await _user.DeleteUser(user);
            return Ok(response);
        }
    }
}
