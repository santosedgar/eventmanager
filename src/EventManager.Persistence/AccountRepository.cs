using EventManager.Core.Interfaces;
using EventManager.Database;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Persistence
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EventManagerContext _context;

        public AccountRepository(EventManagerContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Method to sign in the user, if user name exist/valid and password is valid, return the user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> SignInAsync(string username, string password)
        {
            var result = await this._context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            //TODO password should be hashed and salted
            if (result != null) //&& Policy.VerifyHashedPassword(result.Password, password))
                return result;
            else
                return null;
        }
    }
}
