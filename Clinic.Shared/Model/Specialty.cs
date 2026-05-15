using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Shared.Model
{
   
        public class Specialty
        {
            public int SpecialtyID { get; set; }
            public string SpecialtyName { get; set; } = string.Empty;
            public string? Description { get; set; }
        }
    
}
