using Festival_Hue.Interface;
using Festival_Hue.Model;
using Festival_Hue.Models;
using Festival_Hue.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue.Service.Authencation
{
    public class AuthenticationSvc : IAuthentication
    {
        protected DataContext _context;
        protected IEncode _enCode;
        public AuthenticationSvc(DataContext context, IEncode encode)
        {
            _context = context;
            _enCode = encode;
        }
        public async Task<UserModel> GetUserEmail(ViewLogin viewLogin)
        {
            UserModel user = null;
            user = await _context.UserModels.FirstOrDefaultAsync(u => u.EmailUser == viewLogin.UserEmail);
            return user;
        }

        public async Task<UserModel> Login(ViewLogin viewLogin)
        {
            var admin = await _context.UserModels.Where(
              p => p.EmailUser.Equals(viewLogin.UserEmail) && p.PasswordUser.Equals(viewLogin.UserPassword)
                ).FirstOrDefaultAsync();
            return admin;
        }
    }
}
