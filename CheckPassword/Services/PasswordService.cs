using CheckPassword.Data;
using CheckPassword.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckPassword.Services {
    public interface IPasswordService {
        public Task<List<Password>> GetAllPasswords();
        public Task<Password?> GetPassword(string password);
    }

    public class PasswordService : IPasswordService {
        private readonly PwnedPasswordContext _context;

        public PasswordService(PwnedPasswordContext context) {
            _context = context;
        }

        public async Task<List<Password>> GetAllPasswords() {
            return await _context.Passwords.ToListAsync();
        }

        public async Task<Password?> GetPassword(string password) {
            return await _context.Passwords.FindAsync(password);
        }
    }
}
