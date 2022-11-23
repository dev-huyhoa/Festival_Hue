using Festival_Hue.Interface;
using Festival_Hue.Model;
using Festival_Hue.Models;
using Festival_Hue.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue.Service
{
    public class EventSvc : IEvent
    {
        protected DataContext _db;
        protected IEncode _enCode;

        public EventSvc(DataContext context, IEncode encode)
        {
            _db = context;
            _enCode = encode;
        }

        public async Task<int> CreateEvent(EventModel eventModel)
        {
            int ret = 0;
            try
            {
                EventModel Event = new EventModel();
                Event.IsDelete = false;
                await _db.AddAsync(eventModel);
                await _db.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteEvent(int id)
        {
            int ret = 0;
            try
            {
                var ev = await GetEventId(id);
                _db.Remove(ev);
                await _db.SaveChangesAsync();
                ret = ev.IdEvent;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }


        public async Task<List<EventModel>> GetEventAll()
        {  
                var ev = await _db.EventModels.Where(u => u.IsDelete == false).ToListAsync();
                return ev;
        }
        public async Task<EventModel> GetEventId(int id)
        {

            var ev = await _db.EventModels.FindAsync(id);
            return ev;
        }
        public async Task<int> UpdateEvent(EventModel eventModel)
        {
            int ret = 0;
            try
            {
                EventModel ev = null;
                ev = await GetEventId(ev.IdEvent);
                ev.NameEvent = eventModel.NameEvent;
                ev.PriceEvent = eventModel.PriceEvent;
                ev.StartDate = eventModel.StartDate;
                ev.EndDate = eventModel.EndDate;
                ev.Description = eventModel.Description;
                ev.Quantity = eventModel.Quantity;
                _db.Update(ev);
                await _db.SaveChangesAsync();
                ret = eventModel.IdEvent;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }
    }
}
