using Begge.Data;
using Begge.Services.Contracts;
using Begge.Services.DTOs;
using Begge.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Begge.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly BeggeDBContext _db;

        public AuthService(BeggeDBContext db)
        {
            this._db = db;
        }
        public Task<ResponseAuthDTO> AuthenticateAsync(RequestAuthDTO model)
        {
            throw new NotImplementedException(); //ToDo: implement later
        }

        public async Task<ResponseAuthDTO> GetByEmailAsync(string email)
        {
            return await _db.Beggers
                .Where(x => x.Email == email)
                .Select(x => x.GetAuthDTO())
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistingAsync(string email)
        {
            return await _db.Beggers.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IsPasswordValidAsync(string email, string password)
        {
            var passHash = await _db.Beggers
                .Where(x => x.Email == email)
                .Select(x => x.Password)
                .FirstOrDefaultAsync();

            return BCrypt.Net.BCrypt.Verify(password, passHash);
        }
    }
}
