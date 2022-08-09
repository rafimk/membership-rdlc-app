using membership_rdlc_app.Dtos;
using membership_rdlc_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace membership_rdlc_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(MembershipCardDto command)
        {
            var result = _reportService.GenerateMembershipCard(command);
            return File(result.File, result.FileType, result.FileName);
        }
    }
}