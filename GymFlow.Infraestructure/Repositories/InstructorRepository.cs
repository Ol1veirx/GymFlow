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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApiDbContext _context;
        public InstructorRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Instructor>> GetAllInstructorAsync()
        {
            var instructors = await _context.Instructors.AsNoTracking().OrderBy(x => x.Name).ToListAsync();

            return instructors;
        }

        public async Task<Instructor> GetInstructorById(int instructorId)
        {
            var instructor = await _context.Instructors.SingleOrDefaultAsync(i => i.Id == instructorId);

            if (instructor == null)
            {
                throw new InvalidOperationException("Instructor not found");
            }

            return instructor;
        }

        public async Task<Instructor> GetInstructorByName(string nameInstructor)
        {
            var instructor = await _context.Instructors.SingleOrDefaultAsync(i => i.Name == nameInstructor);

            if (instructor == null)
            {
                throw new InvalidOperationException("Instructor not found");
            }

            return instructor;
        }

        public async Task<Instructor> CreateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            return instructor;
        }

        public async Task<Instructor> UpdateInstructorAsync(Instructor instructor)
        {
            var updateInstructor = await _context.Instructors.FindAsync(instructor.Id);

            if (updateInstructor == null)
            {
                throw new InvalidOperationException("Instructor not found");
            }

            updateInstructor.Name = instructor.Name;
            updateInstructor.Specialty = instructor.Specialty;
            await _context.SaveChangesAsync();

            return updateInstructor;
        }

        public async Task<bool> DeleteInstructorAsync(int instructorId)
        {
            var result = await _context.Instructors.FindAsync(instructorId);

            if (result == null)
            {
                throw new InvalidOperationException("Instructor not found");
            }

            _context.Instructors.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
