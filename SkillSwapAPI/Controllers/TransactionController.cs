using Microsoft.AspNetCore.Mvc;
using SkillSwapCommon.DTOs;
using SkillSwapCore.Entities;
using SkillSwapServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace SkillSwapAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        private readonly ISkillService _skillService;

        public TransactionController(
            ITransactionService transactionService,
            IUserService userService,
            ISkillService skillService)
        {
            _transactionService = transactionService;
            _userService = userService;
            _skillService = skillService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionDto dto)
        {
            if (dto == null)
                return BadRequest("Dados da transação são obrigatórios.");

            var requester = await _userService.GetUserByIdAsync(dto.RequesterId);
            if (requester == null)
                return BadRequest("Usuário solicitante não encontrado.");

            var skill = await _skillService.GetByIdAsync(dto.SkillId);
            if (skill == null)
                return BadRequest("Habilidade não encontrada.");

            var created = await _transactionService.CreateTransactionAsync(dto.RequesterId, dto.SkillId);
            if (!created)
                return BadRequest("Não foi possível criar a transação. Verifique créditos ou dados.");

            return Ok();
        }

        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            var confirmed = await _transactionService.ConfirmTransactionAsync(id);
            if (!confirmed)
                return NotFound("Transação não encontrada ou já confirmada.");

            return NoContent();
        }
    }
}