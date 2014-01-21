using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFoo.Security.Service {
    public interface ISecurityService {

        bool TestCredentials(string securityToken, string passWord);

    }
}
