using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymFlow.Core.Entities;

namespace GymFlow.Infraestructure.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        Task<ICollection<Instructor>> GetAllInstructorAsync();
        Task<Instructor> GetInstructorById(int instructorId);
        Task<Instructor> GetInstructorByName(string nameInstructor);
        Task<Instructor> CreateInstructorAsync(Instructor instructor);
        Task<Instructor> UpdateInstructorAsync(Instructor instructor);
        Task<bool> DeleteInstructorAsync(int instructorId);

    }
}
