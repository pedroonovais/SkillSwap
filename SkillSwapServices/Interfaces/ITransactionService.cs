using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSwapServices.Interfaces
{
    public interface ITransactionService
    {
        Task<bool> CreateTransactionAsync(Guid userId, Guid skillId);
        Task<bool> ConfirmTransactionAsync(Guid transactionId);
    }
}
