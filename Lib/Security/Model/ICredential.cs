using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFoo.Security.Model {
    public interface ICredential {

        int ID { get; }
        int accountID { get; }
        string token { get; }
        string credential { get; }
        string salt { get; }
        string provider { get; }
        DateTimeOffset createDT { get; }
        DateTimeOffset? expireDT { get; }
        DateTimeOffset? renewDT { get; }
        int attempts { get; }
        bool enabled { get; }


    }
}
