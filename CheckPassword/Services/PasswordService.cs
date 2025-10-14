using CheckPassword.Data;
using CheckPassword.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckPassword.Services
{
    public interface IPasswordService {

    }

    public class PasswordService : IPasswordService
    {
        private readonly PwnedPasswordContext _context;

        public PasswordService(PwnedPasswordContext context)
        {
            _context = context;
        }

        public async Task<Password?> GetPasswordAsync(string password) {
            return await _context.Passwords.FindAsync(password);
        }
    }
}
