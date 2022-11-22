using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.DTO
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public long CountryId { get; set; }
        public DateTime Created { get; set; }
        public string CountryName { get; set; }
    }
    public class UserInputDto
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }

}
