using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Solution.Data.Entity
{
    public class OrderDetails
    {
        [Key]
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
