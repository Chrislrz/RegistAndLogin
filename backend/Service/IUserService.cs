using Service.Dto;
using Table;

namespace Service;

public interface IUserService
{
    Task<newusers> Login(LoginDto login);
    
    newusers AddUser (RegistDto input);
    
}