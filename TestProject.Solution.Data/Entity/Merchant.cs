using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.Data.Entity
{
    public class Merchant
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public long CountryId { get; set; }
        public long UserId { get; set; }
        public Country Country { get; set; }
        public User User { get; set; }
    }
}
