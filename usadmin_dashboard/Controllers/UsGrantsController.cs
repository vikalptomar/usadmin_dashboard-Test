using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usadmin_dashboard.Models;
using usadmin_dashboard.Services;
using Newtonsoft.Json;

namespace usadmin_dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsGrantsController : ControllerBase
    {
        IUsGrantsService _usGrantsService;
        IAuditLogsService auditLogsService;

        public UsGrantsController(IUsGrantsService usGrantsService, IAuditLogsService auditLogsService)
        {
            _usGrantsService = usGrantsService;
            this.auditLogsService = auditLogsService;
        }
        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> GetAllRecords(int pageSize)
        {
            var res = await _usGrantsService.GetAllRecords(pageSize);
            return Ok(res);
        }
        [HttpPost("InsertRecord")]
        public async Task<IActionResult> InsertRecords(masters_us_grants _Us_Grants)
        {
            String SuccessMessage = "Success";
            int SuccessCode = 200;
            Boolean ValidRecord = true;

            if (_Us_Grants.DDValue <= _Us_Grants.PDValue)
            {
                SuccessMessage = $"Deadline date [{_Us_Grants.DDValue}] of a grant must be after the Post date [{_Us_Grants.PostDate}].";
                SuccessCode = 102;
                ValidRecord = false;
                return Ok(new { SuccessMessage, SuccessCode });
            }
            if (ValidRecord == true)
            {
                var res = await _usGrantsService.InsertRecord(_Us_Grants);
               // var getAudit = await auditLogsService.GetAuditLogsAsync();
                var jsonData = new
                {
                    CountyIndex = res.GrantIndex,
                    CountyName = "",
                    StateIndex = 1,
                    CountryIndex = 230,
                    Latitude = "0.00",
                    Longitude = "0.00",
                    UserIndex = (uint?)null,
                    UserEmail = (string)null
                };
                var addAudit = await auditLogsService.InsertLogs(new AuditLogs()
                {
                    TrailLogIndex = 0,
                    UserIndex = (uint)res.Id,
                    UserEmail = res.Email,
                    Operation = "Add",
                    OperationOnTable = "UsGrants",
                    RecordIndex = (uint)res.GrantIndex,
                    Json = JsonConvert.SerializeObject(jsonData),
                    Changes = "",
                    Created = DateTime.Now,
                });
                return Ok(new { res, SuccessMessage, SuccessCode });
            }
            else
            {
                SuccessMessage = "Some Error";
                SuccessCode = 403;
                return Ok(new { SuccessMessage, SuccessCode });
            }
        }

        [HttpGet("GetUsersRecord")]

        public async Task<IActionResult> GetUsersRecord(DateTime date)
        {
            var res = await auditLogsService.GetAuditLogsAsync(date);

            return Ok(res);
        }


          
    
    }

}
