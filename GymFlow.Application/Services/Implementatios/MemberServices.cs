using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymFlow.Application.Services.Interfaces;
using GymFlow.Core.Entities;
using GymFlow.Infraestructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace GymFlow.Application.Services.Implementatios
{
    public class MemberServices : IMemberServices
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILogger<MemberServices> _logger;

        public MemberServices(IMemberRepository memberRepository, ILogger<MemberServices> logger)
        {
            _memberRepository = memberRepository;
            _logger = logger;
        }

        public async Task<ICollection<Member>> GetAllMembersAsync()
        {
            try
            {
                _logger.LogInformation("GetAllMembersAsync call");

                return await _memberRepository.GetAllMembersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error: ");
                throw;
            }
        }

        public async Task<Member> GetMemberByIdAsync(int memberId)
        {
            try
            {
                _logger.LogInformation("GetMemberByIdAsync call");

                return await _memberRepository.GetMemberByIdAsync(memberId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error: ");
                throw;
            }
        }

        public async Task<Member> GetMemberByCpfAsync(string memberCpf)
        {
            try
            {
                _logger.LogInformation("GetMemberByCpfAsync call");

                return await _memberRepository.GetMemberByCpfAsync(memberCpf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<Member> GetMemberByNameAsync(string memberName)
        {
            try
            {
                _logger.LogInformation("GetMemberByNameAsync call");

                return await _memberRepository.GetMemberByNameAsync(memberName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            try
            {
                _logger.LogInformation("CreateMemberAsync call");

                return await _memberRepository.CreateMemberAsync(member);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<Member> UpdateMemberAsync(Member member)
        {
            try
            {
                _logger.LogInformation("UpdateMemberAsync call");

                return await _memberRepository.UpdateMemberAsync(member);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<bool> DeleteMemberAsync(int memberId)
        {
            try
            {
                _logger.LogInformation("DeleteMemberAsync call");

                return await _memberRepository.DeleteMemberAsync(memberId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }
    }
}
