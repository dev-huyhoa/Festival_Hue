using Festival_Hue.Interface;
using Festival_Hue.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue.Service
{
    public class CustomerSvc: ICustomer
    {
            protected DataContext _db;

            public CustomerSvc(DataContext context)
            {
                _db = context;
            }

            public async Task<int> CreateCustomer(CustomerModel customerModel)
            {
                int ret = 0;
                try
                {
                    CustomerModel Event = new CustomerModel();
                    Event.IsDelete = false;
                    await _db.AddAsync(customerModel);
                    await _db.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    ret = 0;
                }
                return ret;
            }

            public async Task<int> DeleteCustomer(Guid id)
            {
                var ret = 0;
                try
                {
                    var cus = await GetCustomerId(id);
                    _db.Remove(cus);
                    await _db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    ret = 0;
                }
                return ret;
            }

        public Task<List<CustomerModel>> GetCustomerAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerModel> GetCustomerId(Guid id)
            {

                var ev = await _db.CustomerModels.FindAsync(id);
                return ev;
            }

        public Task<int> UpdateCustomer(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateEvent(EventModel eventModel)
            {
                int ret = 0;
                //try
                //{
                //    EventModel ev = null;
                //    ev = await GetEventId(ev.IdEvent);
                //    ev.NameEvent = eventModel.NameEvent;
                //    ev.PriceEvent = eventModel.PriceEvent;
                //    ev.StartDate = eventModel.StartDate;
                //    ev.EndDate = eventModel.EndDate;
                //    ev.Description = eventModel.Description;
                //    ev.Quantity = eventModel.Quantity;
                //    _db.Update(ev);
                //    await _db.SaveChangesAsync();
                //    ret = eventModel.IdEvent;
                //}
                //catch (Exception)
                //{
                //    ret = 0;
                //}
                return ret;
            }
        }
}
