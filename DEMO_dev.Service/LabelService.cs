using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO_dev.Repository;
using DEMO_dev.Domain.Entities;

namespace DEMO_dev.Service
{
    public class LabelService : LabelDAO
    {
        private readonly LabelDAO _dao;

        public LabelService(LabelDAO dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<Label>> GetAll()
        {
            return await _dao.GetAll();
        }
    }
}
