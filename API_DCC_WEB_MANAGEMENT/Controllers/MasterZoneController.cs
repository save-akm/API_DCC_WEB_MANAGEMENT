using API_DCC_WEB_MANAGEMENT.Models;
using API_DCC_WEB_MANAGEMENT.Service;
using Microsoft.AspNetCore.Mvc;

namespace API_DCC_WEB_MANAGEMENT.Controllers
{
    public class MasterZoneController : Controller
    {
        readonly MasterZoneRepository _masterZoneRepository;
        public MasterZoneController()
        {
            _masterZoneRepository = new MasterZoneRepository(); 
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPut("api/UpdateFlgPCB")]
        public bool UpdateFlgPCB([FromBody] MonitorModel monitorModel)
        {
            var result = _masterZoneRepository.UpdateFlgPCB(monitorModel);
            return result;
        }
        [HttpPut("api/UpdateFlgAYT")]
        public bool UpdateFlgAYT([FromBody] MonitorModel monitorModel)
        {
            var result = _masterZoneRepository.UpdateFlgAYT(monitorModel);
            return result;
        }
    }
}
