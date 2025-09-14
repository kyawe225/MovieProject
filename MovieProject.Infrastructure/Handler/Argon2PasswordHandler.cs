using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Infrastructure.Handler
{
    public class Argon2PasswordHandler : IPasswordHandler
    {
        protected static readonly RandomNumberGenerator cryptoRandom = RandomNumberGenerator.Create();
        public PasswordResult Hash(string password)
        {
            byte[] salt = new byte[16];
            cryptoRandom.GetBytes(salt);
            return new PasswordResult(Argon2.Hash(password), salt.ToB64String());
        }

        public bool Verify(string passwordHash, string password, string salt)
        {
            return Argon2.Verify(passwordHash, password);
        }
    }
}
