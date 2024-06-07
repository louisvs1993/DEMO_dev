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

        public async Task<IEnumerable<Label>> GetAllByUser(string userID) 
        {
            return await _dao.GetAllByUser(userID);
        }

        public async Task Add(Label entity)
        {
            await _dao.Add(entity);
        }

        public async Task<int> AddWithReturn(Label entity)
        {
            return await _dao.AddWithReturn(entity);
        }
    }
}
