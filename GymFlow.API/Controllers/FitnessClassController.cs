using GymFlow.Application.Services.Interfaces;
using GymFlow.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FitnessClassController : Controller
    {
        private readonly IFitnessClassService _fitnessClassService;
        public FitnessClassController(IFitnessClassService fitnessClassService)
        {
            _fitnessClassService = fitnessClassService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFitnessClass()
        {
            try
            {
                var FitnessClasses = await _fitnessClassService.GetAllFitnessClassesAsync();

                return Ok(FitnessClasses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{fitnessClassId}")]
        public async Task<IActionResult> GetFitnessClassById(int fitnessClassId)
        {
            try
            {
                var fitnessClass = await _fitnessClassService.GetFitnessClassByIdAsync(fitnessClassId);

                if (fitnessClass == null)
                {
                    return NotFound();
                }

                return Ok(fitnessClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFitnessClass([FromBody] FitnessClass fitnessClass)
        {
            try
            {
                var newFitnessClass = await _fitnessClassService.CreateFitnessClassAsync(fitnessClass);

                return CreatedAtAction(nameof(GetFitnessClassById), new { fitnessClassId = newFitnessClass.Id }, newFitnessClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{fitnessClassId}")]
        public async Task<IActionResult> UpdateFitnessClass(int fitnessClassId, FitnessClass fitnessClass)
        {
            if (fitnessClassId != fitnessClass.Id)
            {
                return NotFound();
            }

            try
            {
                var updateFitnessClass = await _fitnessClassService.UpdateFitnessClassAsync(fitnessClass);

                return Ok(fitnessClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{fitnessClassId}")]
        public async Task<IActionResult> DeleteFitnessClass(int fitnessClassId)
        {
            try
            {
                var result = await _fitnessClassService.DeleteFitnessClassAsync(fitnessClassId);

                if(!result)
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
