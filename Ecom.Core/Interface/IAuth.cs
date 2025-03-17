using Ecom.Core.DTO;
using Ecom.Core.Entities;

namespace Ecom.Core.Interface
{
    public interface IAuth
    {
        
        Task<string> RegisterAsync(RegisterDto register);
        Task<string> LoginAsync(LoginDto login);
    }
}
