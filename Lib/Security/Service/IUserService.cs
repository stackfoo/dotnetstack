using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFoo.Security.Service {
    public interface IUserService {

        IUser GetUser(string token);

    }
}
