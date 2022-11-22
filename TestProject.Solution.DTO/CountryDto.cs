using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.DTO
{
    public class CountryDto
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string ContinentName { get; set; }
    }
}
