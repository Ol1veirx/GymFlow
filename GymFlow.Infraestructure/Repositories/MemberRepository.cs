using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymFlow.Core.Entities;
using GymFlow.Infraestructure.Persistence;
using GymFlow.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymFlow.Infraestructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApiDbContext _dbContext;
        public MemberRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Member>> GetAllMembersAsync()
        {
            var members = await _dbContext.Members.AsNoTracking().OrderBy(m => m.Name).ToListAsync();

            return members;
        }

        public async Task<Member> GetMemberByIdAsync(int memberId)
        {
            var member = await _dbContext.Members.SingleOrDefaultAsync(m => m.Id == memberId);

            if(member == null)
            {
                return null;
            }

            return member;
        }

        public async Task<Member> GetMemberByCpfAsync(string memberCpf)
        {
            var member = await _dbContext.Members.SingleOrDefaultAsync(m => m.CPF == memberCpf);

            if(member == null)
            {
                return null;
            }

            return member;
        }

        public async Task<Member> GetMemberByNameAsync(string memberName)
        {
            var member = await _dbContext.Members.SingleOrDefaultAsync(m => m.Name == memberName);

            if(member == null)
            {
                return null;
            }

            return member;
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();

            return member;
        }

        public async Task<Member> UpdateMemberAsync(Member member)
        {
            var updateMember = await _dbContext.Members.FindAsync(member.Id);

            if(updateMember == null)
            {
                return null;
            }

            updateMember.Name = member.Name;
            updateMember.Contact = member.Contact;
            updateMember.CPF = member.CPF;
            updateMember.Birthday = member.Birthday;
            updateMember.Plan = member.Plan;
            updateMember.MedicalObservation = member.MedicalObservation;

            await _dbContext.SaveChangesAsync();

            return updateMember;
        }

        public async Task<bool> DeleteMemberAsync(int memberId)
        {
            var result = await _dbContext.Members.FindAsync(memberId);

            if (result == null)
            {
                return false;
            }

            _dbContext.Members.Remove(result);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
