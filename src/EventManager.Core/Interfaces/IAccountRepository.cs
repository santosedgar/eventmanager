using EventManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<User> SignInAsync(string username, string password);
    }
}
