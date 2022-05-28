using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    
    // public class UsersController : ControllerBase
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        // public UsersController(IUserRepository userRepository)
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        // [AllowAnonymous]
        // public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // var users = _context.Users.ToList();
            // return users;

            // var users = await _userRepository.GetUsersAsync();
            // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            // return Ok(usersToReturn);

            var users = await _userRepository.GetMembersAsync();
            return Ok(users);


        }

        // api/users/3
        // [Authorize]
        // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        // {
        //     // var user = _context.Users.Find(id);
        //     // return user;
        //     return await _context.Users.FindAsync(id);
        // }

        // //  [Authorize]
        // // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        // {
        //     // var user = _context.Users.Find(id);
        //     // return user;
        //     return await _userRepository.GetUserByIdAsync(id);
        // }


        // api/users/3
        // [Authorize]
        [HttpGet("{username}")]
        // public async Task<ActionResult<AppUser>> GetUser(string username)
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            // var user = _context.Users.Find(id);
            // return user;

            // var user = await _userRepository.GetUserByUsernameAsync(username);
            // return _mapper.Map<MemberDto>(user);

            return await _userRepository.GetMemberAsync(username);            
        }

        [HttpPut]
        public async Task<ActionResult> Updateuser(MemberUpdateDTO memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                        var user = await _userRepository.GetUserByUsernameAsync(username);

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    
    }
}