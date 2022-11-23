using Festival_Hue.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festival_Hue.Interface
{
    public interface ITicket
    {
        Task<List<TicketModel>> GetTicketAll();
        Task<int> CreateTicket(TicketModel ticketModel);
        Task<int> UpdateTicket(TicketModel ticketModel);
        Task<int> DeleteTicket(int id);
    }
}