using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Solution.Data.DatabaseContext;

namespace TestProject.Solution.Services
{
    public interface IOrderService
    {

    }
    public class OrderService: IOrderService
    {
        private readonly TestProjectContext _context;
        public OrderService(TestProjectContext context)
        {
            _context = context;
        }
    }
}
