using Microsoft.EntityFrameworkCore;
using usadmin_dashboard.Models;
using usadmin_dashboard.MyDatabase;

namespace usadmin_dashboard.Services
{
    public interface IAuditLogsService
    {
        Task<List<UserEmailCountDto>> GetAuditLogsAsync(DateTime date);
        Task<AuditLogs> InsertLogs(AuditLogs auditLogs);
    }
    public class AuditLogsService : IAuditLogsService
    {
        AppDbContext _dbcontext;
        public AuditLogsService(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<UserEmailCountDto>> GetAuditLogsAsync(DateTime date)
        {
            var result = await _dbcontext.masters_audit_trail.Where(a => a.Created >= date && a.Created <= DateTime.Now).
                GroupBy(a => a.UserEmail).
                Select(g => new UserEmailCountDto
                {
                    UserEmail = g.Key,
                    RecordCount = g.Count(),
                    Activity = g.GroupBy(a => a.OperationOnTable)
                    .Select(ag => new UserActivityDto
                    {
                        OperationOn = ag.Key,
                        Operations = new OperationsDto
                        {
                            Add = ag.Where(a => a.Operation == "Add").Select(a => (int)a.RecordIndex).ToList(),
                            Update = ag.Where(a => a.Operation == "Update").Select(a => (int)a.RecordIndex).ToList()
                        }
                    }).ToList()
                }).
                ToListAsync();

            return result;

        }
        public async Task<AuditLogs> InsertLogs(AuditLogs auditLogs)
        {
            await _dbcontext.masters_audit_trail.AddAsync(auditLogs);
            await _dbcontext.SaveChangesAsync();
            return auditLogs;
        }
    }
}
