using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymFlow.Core.Entities;

namespace GymFlow.Application.Services.Interfaces
{
    public interface IMemberServices
    {
        Task<ICollection<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(int memberId);
        Task<Member> GetMemberByNameAsync(string memberName);
        Task<Member> GetMemberByCpfAsync(string memberCpf);
        Task<Member> CreateMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(int memberId);
    }
}
