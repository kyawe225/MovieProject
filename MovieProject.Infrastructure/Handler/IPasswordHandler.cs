using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Infrastructure.Handler
{
    public interface IPasswordHandler
    {
        public PasswordResult Hash(string password);
        public bool Verify(string passwordHash, string password, string salt);
    }

    public class PasswordResult
    {
        public string PasswordHash { set; get; }
        public string Salt { set; get; }
        public PasswordResult(string PasswordHash, string Salt)
        {
            this.PasswordHash = PasswordHash;
            this.Salt = Salt;
        }
    };
}
