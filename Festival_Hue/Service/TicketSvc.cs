using Festival_Hue.Interface;
using Festival_Hue.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue.Service
{
    public class TicketSvc : ITicket
    {
        protected DataContext _db;
        public TicketSvc(DataContext context)
        {
            _db = context;
        }
        public async Task<TicketModel> GetTicketId(int id)
        {

            var tk = await _db.TicketModels.FindAsync(id);
            return tk;
        }
        public async Task<int> CreateTicket(TicketModel ticketModel)
        {
            int ret = 0;
            try
            {
                ticketModel.IsDelete = false;
                ticketModel.Status = 1;

                await _db.AddAsync(ticketModel);
                await _db.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteTicket(int id)
        {
            int ret = 0;
            try
            {
                var tk = await GetTicketId(id);
                _db.Remove(tk);
                await _db.SaveChangesAsync();
                ret = tk.IdTicket;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<TicketModel>> GetTicketAll()
        {
            var tk = await _db.TicketModels.Where(u => u.IsDelete == false).ToListAsync();
            return tk;
        }

        public async Task<int> UpdateTicket(TicketModel ticketModel)
        {
            int ret = 0;
            try
            {
                TicketModel tk = null;
                tk = await GetTicketId(tk.IdTicket);

                tk.NameTicket = ticketModel.NameTicket;
                tk.PriceTicket = tk.PriceTicket;
                tk.Status = ticketModel.Status;
                tk.VoucherCode = ticketModel.VoucherCode;
                tk.FinalPrice = ticketModel.FinalPrice;
                tk.DatePurchase = ticketModel.DatePurchase;
                _db.Update(tk);
                await _db.SaveChangesAsync();
                ret = ticketModel.IdTicket;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }
    }
}
