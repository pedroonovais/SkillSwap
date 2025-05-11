using SkillSwapCore;
using SkillSwapCore.Entities;
using SkillSwapServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSwapCommon.Enums;

namespace SkillSwapServices.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTransactionAsync(Guid userId, Guid skillId)
        {
            var user = await _context.Users.FindAsync(userId);
            var skill = await _context.Skills.FindAsync(skillId);

            if (user == null || skill == null)
                return false;

            if (user.Credits < skill.CreditValue)
                return false;

            var skillOwner = await _context.Users.FindAsync(skill.OwnerId);

            if (skillOwner == null)
                return false;

            var transaction = new Transaction
            {
                FromUserId = userId,
                ToUserId = skill.OwnerId,
                SkillId = skillId,
                CreditValue = skill.CreditValue,
                Status = TransactionStatus.Pending,
                Skill = skill, 
                FromUser = user,
                ToUser = skillOwner
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            user.Credits -= skill.CreditValue;
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> ConfirmTransactionAsync(Guid transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);

            if (transaction == null || transaction.Status == "Confirmed")
                return false;

            transaction.Status = "Confirmed";
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(transaction.UserId);
            var skill = await _context.Skills.FindAsync(transaction.SkillId);

            if (user != null && skill != null)
            {
                user.Credits += skill.CreditValue;
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
