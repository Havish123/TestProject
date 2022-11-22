using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.Data.Entity
{
    public class Country
    {
        [Key]
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string ContinentName { get; set; }
    }
}
