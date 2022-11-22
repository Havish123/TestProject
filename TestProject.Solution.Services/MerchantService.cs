using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Solution.Data.DatabaseContext;

namespace TestProject.Solution.Services
{
    public interface IMerchantService
    {

    }
    public class MerchantService: IMerchantService
    {
        private readonly TestProjectContext _context;
        public MerchantService(TestProjectContext context)
        {
            _context = context;
        }
    }
}
