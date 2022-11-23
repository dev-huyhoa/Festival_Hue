using Festival_Hue.Models;
using Festival_Hue.Models.ViewModel;
using System.Threading.Tasks;

namespace Festival_Hue.Interface
{
    public interface IAuthentication
    {
        Task<UserModel> Login(ViewLogin viewLogin);
        Task<UserModel> GetUserEmail(ViewLogin viewLogin);
    }
}
