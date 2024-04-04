using GymFlow.Application.Services.Interfaces;
using GymFlow.Core.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace GymFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstructorAsync()
        {
            try
            {
                var instructors = await _instructorService.GetAllInstructorAsync();

                if(instructors == null)
                {
                    return NotFound();
                }

                return Ok(instructors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{instructorId}")]
        public async Task<IActionResult> GetInstructorById(int instructorId)
        {
            try
            {
                var instructor = await _instructorService.GetInstructorById(instructorId);

                if (instructor == null)
                {
                    return NotFound();
                }

                return Ok(instructor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byname/{nameInstructor}")]
        public async Task<IActionResult> GetInstructorByName(string nameInstructor)
        {
            try
            {
                var instructor = await _instructorService.GetInstructorByName(nameInstructor);

                if (instructor == null)
                {
                    return NotFound();
                }

                return Ok(instructor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructorAsync([FromBody] Instructor instructor)
        {
            try
            {
                var newInstructor = await _instructorService.CreateInstructorAsync(instructor);

                return CreatedAtAction(nameof(GetInstructorById), new { instructorId = newInstructor.Id }, newInstructor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{instructorId}")]
        public async Task<IActionResult> UpdateInstructor(int instructorId, Instructor instructor)
        {
            if (instructorId != instructor.Id)
            {
                return NotFound();
            }

            try
            {
                var updateInstructor = await _instructorService.UpdateInstructorAsync(instructor);

                return Ok(updateInstructor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{instructorId}")]
        public async Task<IActionResult> DeleteInstructor(int instructorId)
        {
            try
            {
                var result = await _instructorService.DeleteInstructorAsync(instructorId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
