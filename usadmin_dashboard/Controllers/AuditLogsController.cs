using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usadmin_dashboard.Services;

namespace usadmin_dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        IAuditLogsService _obj1;

        public AuditLogsController(IAuditLogsService obj) 
        {
            _obj1 = obj;
        }
        [HttpGet("GetAuditRecord")]
        public async Task<IActionResult> GetAuditLogsAsync()
        {
            var res = await _obj1.GetAuditLogsAsync();
            return Ok(res);
        }
    }
}
