using Microsoft.AspNetCore.Mvc;
using SkillSwapCore.Entities;
using SkillSwapServices.Interfaces;
using SkillSwapCommon.DTOs;
using System;
using System.Threading.Tasks;

namespace SkillSwapAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IUserService _userService;

        public SkillController(ISkillService skillService, IUserService userService)
        {
            _skillService = skillService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillCreateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Title) || string.IsNullOrWhiteSpace(dto.Description))
                return BadRequest("Título e descrição são obrigatórios.");

            var owner = await _userService.GetUserByIdAsync(dto.OwnerId);
            if (owner == null)
                return BadRequest("Usuário proprietário não encontrado.");

            var skill = new Skill
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                CreditValue = dto.CreditValue,
                OwnerId = dto.OwnerId,
                Owner = owner
            };

            await _skillService.AddAsync(skill);
            return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var skill = await _skillService.GetByIdAsync(id);
            if (skill == null)
                return NotFound("Habilidade não encontrada.");

            return Ok(skill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _skillService.DeleteAsync(id);
            if (!deleted)
                return NotFound("Habilidade não encontrada.");

            return NoContent();
        }
    }
}
