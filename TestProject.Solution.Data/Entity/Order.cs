using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.Data.Entity
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
