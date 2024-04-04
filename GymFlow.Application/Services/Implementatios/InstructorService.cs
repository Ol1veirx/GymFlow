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
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly ILogger<InstructorService> _logger;
        public InstructorService(IInstructorRepository instructorRepository, ILogger<InstructorService> logger)
        {
            _instructorRepository = instructorRepository;
            _logger = logger;
        }

        public async Task<ICollection<Instructor>> GetAllInstructorAsync()
        {
            try
            {
                _logger.LogInformation("GetAllInstructorAsync call");

                return await _instructorRepository.GetAllInstructorAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<Instructor> GetInstructorById(int instructorId)
        {
            try
            {
                _logger.LogInformation("GetInstructorById call");

                return await _instructorRepository.GetInstructorById(instructorId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<Instructor> GetInstructorByName(string nameInstructor)
        {
            try
            {
                _logger.LogInformation("GetInstructorByName call");

                return await _instructorRepository.GetInstructorByName(nameInstructor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<Instructor> CreateInstructorAsync(Instructor instructor)
        {
            try
            {
                _logger.LogInformation("CreateInstructorAsync call");

                return await _instructorRepository.CreateInstructorAsync(instructor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<Instructor> UpdateInstructorAsync(Instructor instructor)
        {
            try
            {
                _logger.LogInformation("UpdateInstructorAsync call");

                return await _instructorRepository.UpdateInstructorAsync(instructor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<bool> DeleteInstructorAsync(int instructorId)
        {
            try
            {
                _logger.LogInformation("DeleteInstructorAsync call");

                return await _instructorRepository.DeleteInstructorAsync(instructorId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

    }
}
