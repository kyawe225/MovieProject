using MovieProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Services
{
    public interface IAuthRepository
    {
        public Task<User> Login(string Email , string Password);
    }
}
