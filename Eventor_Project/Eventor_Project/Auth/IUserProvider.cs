using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventor_Project.Auth
{
    public interface IUserProvider
    {
        Models.User.User User { get; set; }
    }
}
