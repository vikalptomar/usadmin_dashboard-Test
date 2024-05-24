using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usadmin_dashboard.Services;

namespace usadmin_dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsGrantsController : ControllerBase
    {
        IUsGrantsService _obj;

        public UsGrantsController(IUsGrantsService obj) 
        {
            _obj = obj;
        }
        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> GetAllRecords(int pageSize)
        {
            var res = await _obj.GetAllRecords(pageSize);
            return Ok(res);
        }
    }
}
