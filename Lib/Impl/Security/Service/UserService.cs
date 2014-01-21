using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFoo.Security.Service {
    internal class UserService: IUserService {
        IUser IUserService.GetUser(string token) {

            Console.WriteLine("Getting User through UserService");
            return new User() { UserID = 1 };

        }
    }
}
