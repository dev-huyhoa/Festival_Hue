using Festival_Hue.Model;
using Festival_Hue.Models;
using Festival_Hue.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festival_Hue.Interface
{
    public interface IEvent
    {
        Task<List<EventModel>> GetEventAll();
        //Task<int> GetEventById(int id);
        Task<int> CreateEvent(EventModel eventModel);
        Task<int> UpdateEvent(EventModel eventModel);
        Task<int> DeleteEvent (int id);
    }
}
