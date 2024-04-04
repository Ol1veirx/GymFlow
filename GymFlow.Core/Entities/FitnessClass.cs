using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFlow.Core.Entities
{
    public class FitnessClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        /*public Instructor Instructor { get; set; }*/
        public int InstructorId { get; set; }
    }
}
