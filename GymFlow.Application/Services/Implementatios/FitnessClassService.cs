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
    public class FitnessClassService : IFitnessClassService
    {
        private readonly IFitnessClassRepository _repository;
        private readonly ILogger<FitnessClassService> _logger;
        public FitnessClassService(IFitnessClassRepository repository, ILogger<FitnessClassService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ICollection<FitnessClass>> GetAllFitnessClassesAsync()
        {
            try
            {
                _logger.LogInformation("GetAllFitnessClassesAsync call");

                return await _repository.GetFitnessClassesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<FitnessClass> GetFitnessClassByIdAsync(int fitnessClassId)
        {
            try
            {
                _logger.LogInformation("GetFitnessClassByIdAsync call");

                return await _repository.GetFitnessClassByIdAsync(fitnessClassId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass)
        {
            try
            {
                _logger.LogInformation("CreateFitnessClassAsync call");

                return await _repository.CreateFitnessClassAsync(fitnessClass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<FitnessClass> UpdateFitnessClassAsync(FitnessClass fitnessClass)
        {
            try
            {
                _logger.LogInformation("UpdateFitnessClassAsync call");

                return await _repository.UpdateFitnessClassAsync(fitnessClass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

        public async Task<bool> DeleteFitnessClassAsync(int fitnessClassId)
        {
            try
            {
                _logger.LogInformation("DeleteFitnessClassAsync call");

                return await _repository.DeleteFitnessClassAsync(fitnessClassId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                throw;
            }
        }

    }
}
