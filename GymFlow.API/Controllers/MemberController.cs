using GymFlow.Application.Services.Interfaces;
using GymFlow.Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GymFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberServices _memberServices;

        public MemberController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembersAsync()
        {
            try
            {
                var members = await _memberServices.GetAllMembersAsync();

                if(members == null)
                {
                    return NotFound();
                }

                return Ok(members);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{memberId}")]
        public async Task<IActionResult> GetMemberById(int memberId)
        {
            try
            {
                var member = await _memberServices.GetMemberByIdAsync(memberId);

                if(member == null)
                {
                    return NotFound();
                }

                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bycpf/{memberCpf}")]
        public async Task<IActionResult> GetMemberByCpfAsync(string memberCpf)
        {
            try
            {
                var member = await _memberServices.GetMemberByCpfAsync(memberCpf);

                if(member == null)
                {
                    return NotFound();
                }

                return Ok(member);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byname/{memberName}")]
        public async Task<IActionResult> GetMemberByNameAsync(string memberName)
        {
            try
            {
                var member = await _memberServices.GetMemberByNameAsync(memberName);

                if (member == null)
                {
                    return NotFound();
                }

                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateMemberAsync([FromBody] Member member)
        {
            try
            {
                var newMember = await _memberServices.CreateMemberAsync(member);

                return CreatedAtAction(nameof(GetMemberById), new { memberId = newMember.Id }, newMember);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{memberId}")]
        public async Task<IActionResult> UpdateMemberAsync(int memberId, Member member)
        {
            if (memberId != member.Id)
            {
                return NotFound();
            }

            try
            {
                var updateMember = await _memberServices.UpdateMemberAsync(member);

                if(updateMember == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{memberId}")]
        public async Task<IActionResult> DeleteMemberAsync(int memberId)
        {
            try
            {
                var result = await _memberServices.DeleteMemberAsync(memberId);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
