using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecooperation_backend.Entities;
using Ecooperation_backend.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Ecooperation_backend.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Login lub has³o jest nieprawid³owe");

            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);

            if (user == null)
                throw new NullReferenceException("Podany u¿ytkownik nie istnieje");

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Login lub has³o jest nieprawid³owe");

            return user;
        }

        public async Task Create(User user, string password)
        {
            if (_context.Users.Any(x => x.UserName == user.UserName))
                throw new Exception("Nazwa u¿ytkownika " + user.UserName + " jest ju¿ zajêta");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Wartoœæ nie mo¿e byæ pusta");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                throw new NullReferenceException("U¿ytkownik o podanym ID nie istnieje");

            return user;
        }

        public async Task Update(User userParam, string password)
        {
            var user = await _context.Users.FindAsync(userParam.Id);

            if (user == null)
                throw new NullReferenceException("U¿ytkownik o podanym ID nie istnieje");

            if (userParam.UserName != user.UserName)
            {
                if (_context.Users.Any(x => x.UserName == userParam.UserName))
                    throw new Exception("Nazwa u¿ytkownika " + userParam.UserName + " jest ju¿ zajêta");
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.UserName = userParam.UserName;
            user.Email = userParam.Email;

            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("U¿ytkownik o podanym ID nie istnieje");
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Has³o nie mo¿e byæ puste");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}