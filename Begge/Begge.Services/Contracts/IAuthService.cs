using Begge.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Begge.Services.Contracts
{
    public interface IAuthService
    {
        Task<bool> IsExistingAsync(string email);

        Task<ResponseAuthDTO> AuthenticateAsync(RequestAuthDTO model);

        Task<ResponseAuthDTO> GetByEmailAsync(string email);

        Task<bool> IsPasswordValidAsync(string email, string password);
    }
}
