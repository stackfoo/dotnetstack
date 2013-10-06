using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackFoo.Security;

namespace StackFoo {
    internal class BoFoo: IBoFoo {

        public User LastUpdatedBy { get; set; }

        IUser IBoFoo.LastUpdatedBy {
            get { return this.LastUpdatedBy; }
        }


    }
}
