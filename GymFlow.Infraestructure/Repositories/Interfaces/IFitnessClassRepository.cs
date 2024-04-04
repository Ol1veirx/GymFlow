using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymFlow.Core.Entities;

namespace GymFlow.Infraestructure.Repositories.Interfaces
{
    public interface IFitnessClassRepository
    {
        Task<ICollection<FitnessClass>> GetFitnessClassesAsync();
        Task<FitnessClass> GetFitnessClassByIdAsync(int fitnessClassId);
        Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass);
        Task<FitnessClass> UpdateFitnessClassAsync(FitnessClass fitnessClass);
        Task<bool> DeleteFitnessClassAsync(int fitnessClassId);
    }
}
