using DEMO_dev.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO_dev.Repository
{
    public class CountryDAO
    {
        private readonly DemoDevContext _dbContext;

        public CountryDAO()
        {
            _dbContext = new DemoDevContext();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _dbContext.Countries.ToListAsync();
        }
    }
}
