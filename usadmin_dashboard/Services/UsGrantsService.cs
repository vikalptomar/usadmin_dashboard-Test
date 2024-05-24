using usadmin_dashboard.MyDatabase;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using usadmin_dashboard.Models;

namespace usadmin_dashboard.Services
{

    public interface IUsGrantsService
    {
        Task<List<masters_us_grants>> GetAllRecords(int pageSize);

    }
    public class UsGrantsService : IUsGrantsService
    {
        AppDbContext _dbContext;

        public UsGrantsService(AppDbContext dbContext)
        { 
           _dbContext = dbContext; 
        }
        public async Task<List<masters_us_grants>> GetAllRecords(int pageSize)
        {
            var result = await _dbContext.masters_us_grants.Take(pageSize).ToListAsync();

            return result;
        }
    }
}