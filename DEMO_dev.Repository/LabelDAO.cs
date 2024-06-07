using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DEMO_dev.Domain.Entities;


namespace DEMO_dev.Repository
{
    public class LabelDAO
    {
        private readonly DemoDevContext _dbContext;

        public LabelDAO()
        {
            _dbContext = new DemoDevContext();
        }

        public async Task<IEnumerable<Label>> GetAll()
        {
            return await _dbContext.Labels.ToListAsync();
        }

        //TODO change to get all labels by user
        public async Task<IEnumerable<Label>> GetAllByUser(int userID)
        {
            return await _dbContext.LabelUsers
                                    .Where(lu => lu.UserId == userID.ToString())
                                    .Select(lu => lu.Label)
                                    .ToListAsync();
        }

    }
}
