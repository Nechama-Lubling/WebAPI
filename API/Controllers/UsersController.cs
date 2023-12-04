using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

   
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IMapper _mapper;

        private readonly ILogger<UsersController> _logger;


        public UsersController(IUserService userService , IMapper mapper , ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;

        }

        // GET api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<UserDTO>> Get(
            [FromQuery] string userName="", [FromQuery] string password="")
        {
            User findUser = await _userService.getUser(userName, password);

            if(findUser == null)
            {
               return  NotFound();
            }

            UserDTO userAgsist = _mapper.Map<User, UserDTO>(findUser);      
            _logger.LogInformation("Login attempt with userName, {0} and password {1}", userName, password);
            return  Ok(userAgsist);

        }





        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {

            User user = _mapper.Map<UserDTO,User>(userDTO);
            User newUser =await _userService.addUser(user);
            if (newUser == null)
            {
                return  NoContent();
                
            }
            return  CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);

        }




        [HttpPost("check")]
        public async Task<int> Check([FromBody] string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return  result.Score;
            }
            return  -1;

        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDTO userToUpdateDTO)
        {

            User userToUpdate = _mapper.Map<UserDTO, User>(userToUpdateDTO);

            User newUser = await _userService.editUser(userToUpdate);
            if (newUser != null)
            {
                return  Ok(newUser);
            }

            return  NoContent();

        }
    }
}
