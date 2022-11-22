using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.DTO
{
    public class MerchantDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public long CountryCode { get; set; }
        public DateTime Created { get; set; }
    }
}
