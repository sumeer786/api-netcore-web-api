using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogsService _logsService;
        public LogsController(LogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpGet("get-all-logs-from-db")]
        public IActionResult GetAllLogsFromDB()
        {
            try
            {
                var alllogs = _logsService.GetAllLogsFromDB();
                return Ok(alllogs);
            }
            catch (System.Exception)
            {

                return BadRequest("Could Load Logs from DB");
            }
        }
    }
}
