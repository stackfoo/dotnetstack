using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace StackFoo.Security.Service {
    public class SecurityService:ISecurityService {

        [Dependency]
        public IUserService UserService { get; set; }

        bool ISecurityService.TestCredentials(string securityToken, string passWord) {


            IUser test = this.UserService.GetUser("dummy");
            return true;

        }
    }

}
