using Festival_Hue.Interface;
using Festival_Hue.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festival_Hue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEvent _eventSvc;
     
        public EventController(IEvent eventSvc)
        {
            _eventSvc = eventSvc;
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        [Route("Create-Event")]
        public async Task<ActionResult<int>> CreateEvent(EventModel eventModel)
        {
            try
            {
               await _eventSvc.CreateEvent(eventModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Success");
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        [Route("Get-Event")]
        public async Task<ActionResult<IEnumerable<EventModel>>> GetEvent()
        {
            var getEv = await _eventSvc.GetEventAll();
            return getEv;
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        [Route("Update-Event")]
        public async Task<ActionResult<int>> UpdateEvent(EventModel ev)
        {
            try
            {
                var upEv = await _eventSvc.UpdateEvent(ev);
                ev.IdEvent = upEv;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Success");
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        [Route("DeleteEvent/{id}")]
        public async Task<ActionResult<int>> DeleteEvent(int id)
        {
            try
            {
                await _eventSvc.DeleteEvent(id);
            }
            catch (Exception)
            {
                return BadRequest("Lỗi");
            }

            return Ok("Success");
        }
    }
}
