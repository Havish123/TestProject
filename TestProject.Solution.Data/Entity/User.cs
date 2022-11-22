using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.Data.Entity
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public long CountryId { get; set; }
        public DateTime Created { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
