using DEMO_dev.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO_dev.Domain.Entities;

namespace DEMO_dev.Service
{
    public class CountryService
    {
        private readonly CountryDAO _dao;

        public CountryService(CountryDAO dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _dao.GetAll();
        }
    }
}
