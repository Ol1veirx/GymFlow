using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymFlow.Core.Entities;

namespace GymFlow.Application.Services.Interfaces
{
    public interface IFitnessClassService
    {
        Task<ICollection<FitnessClass>> GetAllFitnessClassesAsync();
        Task<FitnessClass> GetFitnessClassByIdAsync(int fitnessClassId);
        Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass);
        Task<FitnessClass> UpdateFitnessClassAsync(FitnessClass fitnessClass);
        Task<bool> DeleteFitnessClassAsync(int fitnessClassId);
    }
}
