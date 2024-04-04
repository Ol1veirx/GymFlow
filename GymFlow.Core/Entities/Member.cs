using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFlow.Core.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string Contact {  get; set; }
        public string Plan {  get; set; }
        public string? MedicalObservation { get; set; }
    }
}
