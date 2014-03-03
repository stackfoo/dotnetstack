using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFoo.Security.Model {

    public interface IAccount {

        int ID { get; }
        Guid UID { get; }
        string displayName { get; }
        DateTimeOffset createDT { get; }
        bool enabled { get; }

        List<ICredential> Credentials { get; }


    }
}
