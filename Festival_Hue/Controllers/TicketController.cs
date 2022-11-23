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
    public class TicketController : Controller
    {
        private readonly ITicket _ticketSvc;

        public TicketController(ITicket ticketSvc)
        {
            _ticketSvc = ticketSvc;
        }
        [HttpPost]
        [Authorize(Roles = "1")]
        [Route("Create-Ticket")]
        public async Task<ActionResult<int>> CreateTicket(TicketModel ticketModel)
        {
            try
            {
                await _ticketSvc.CreateTicket(ticketModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Success");
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        [Route("Get-Ticket")]
        public async Task<ActionResult<IEnumerable<TicketModel>>> GetTicket()
        {
            var getEv = await _ticketSvc.GetTicketAll();
            return getEv;
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        [Route("Update-Ticket")]
        public async Task<ActionResult<int>> UpdateTicket(TicketModel ev)
        {
            try
            {
                var upEv = await _ticketSvc.UpdateTicket(ev);
                ev.IdTicket = upEv;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Success");
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        [Route("DeleteTicket/{id}")]
        public async Task<ActionResult<int>> DeleteEvent(int id)
        {
            try
            {
                await _ticketSvc.DeleteTicket(id);
            }
            catch (Exception)
            {
                return BadRequest("Lỗi");
            }

            return Ok("Success");
        }
    }
}
