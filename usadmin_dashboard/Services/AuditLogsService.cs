using Microsoft.EntityFrameworkCore;
using usadmin_dashboard.Models;
using usadmin_dashboard.MyDatabase;

namespace usadmin_dashboard.Services
{
    public interface IAuditLogsService
    {
        Task<List<AuditLogs>> GetAuditLogsAsync();
        Task<AuditLogs> InsertLogs(AuditLogs auditLogs);
    }
    public class AuditLogsService: IAuditLogsService
    {
        AppDbContext _dbcontext;
        public AuditLogsService(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<AuditLogs>> GetAuditLogsAsync()
        {
            var result = await _dbcontext.masters_audit_trail.ToListAsync();
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
