using System.Collections.Generic;
using System.Threading.Tasks;
using SFQG.Entities;
using SFQG.Models;

namespace SFQG.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(UserModel userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}