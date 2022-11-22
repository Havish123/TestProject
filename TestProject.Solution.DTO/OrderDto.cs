using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.DTO
{
    public class OrderDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
