using Microsoft.AspNetCore.Mvc;
using SkillSwapCore.Entities;
using SkillSwapServices.Interfaces;
using System;
using System.Threading.Tasks;
using SkillSwapCommon.DTOs;

namespace SkillSwapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Email))
                return BadRequest("Nome e Email são obrigatórios.");

            var userCreated = await _userService.CreateUserAsync(dto.Name, dto.Email, dto.Password);
            if (!userCreated)
                return BadRequest("Erro ao criar o usuário.");

            return CreatedAtAction(nameof(GetUser), new { email = dto.Email }, null);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            return Ok(user);
        }

        [HttpPut("{userId}/credits")]
        public async Task<IActionResult> UpdateUserCredits(Guid userId, [FromBody] int creditChange)
        {
            var success = await _userService.UpdateUserCreditsAsync(userId, creditChange);
            if (!success)
                return NotFound("Usuário não encontrado ou erro na atualização.");

            return NoContent();
        }
    }
}
