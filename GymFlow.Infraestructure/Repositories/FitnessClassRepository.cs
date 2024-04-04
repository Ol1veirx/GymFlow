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
    public class FitnessClassRepository : IFitnessClassRepository
    {
        private readonly ApiDbContext _context;
        public FitnessClassRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<FitnessClass>> GetFitnessClassesAsync()
        {
            var fitnessClasses = await _context.FitnessClasses.AsNoTracking().OrderBy(f => f.Time).ToListAsync();

            return fitnessClasses;
        }


        public async Task<FitnessClass> GetFitnessClassByIdAsync(int fitnessClassId)
        {
            var fitnessClass = await _context.FitnessClasses.SingleOrDefaultAsync(f => f.Id == fitnessClassId);

            if (fitnessClass == null)
            {
                throw new InvalidOperationException("FitnessClass not found");
            }

            return fitnessClass;
        }

        public async Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass)
        {
            _context.FitnessClasses.Add(fitnessClass);
            await _context.SaveChangesAsync();

            return fitnessClass;
        }

        public async Task<FitnessClass> UpdateFitnessClassAsync(FitnessClass fitnessClass)
        {
            var updateFitnessClass = await _context.FitnessClasses.FindAsync(fitnessClass.Id);

            if(updateFitnessClass == null)
            {
                throw new InvalidOperationException("FitnessClass Not Found");
            }

            updateFitnessClass.Name = fitnessClass.Name;
            updateFitnessClass.Time = fitnessClass.Time;
            updateFitnessClass.InstructorId = fitnessClass.InstructorId;
            await _context.SaveChangesAsync();

            return updateFitnessClass;
        }

        public async Task<bool> DeleteFitnessClassAsync(int fitnessClassId)
        {
            var result = await _context.FitnessClasses.FindAsync(fitnessClassId);

            if(result == null)
            {
                throw new InvalidOperationException("FitnessClass Not Found");
            }

            _context.FitnessClasses.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
