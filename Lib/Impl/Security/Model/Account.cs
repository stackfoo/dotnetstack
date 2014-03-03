using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFoo.Security.Model {
    public class Account : IAccount {

        public int ID { get; set; }
        public Guid UID { get; set; }
        public string displayName { get; set; }
        public DateTimeOffset createDT { get; set; }

        public byte enabled { get; set; }
        bool IAccount.enabled { get { return ((byte)1).Equals(this.enabled); } }

        [Timestamp]
        public byte[] rv { get; set; }

        public virtual List<Credential> Credentials { get; set; }
        List<ICredential> IAccount.Credentials {
            get {
                if (null != this.Credentials) {
                    return new List<ICredential>(from c in this.Credentials select (ICredential)c);
                } else return new List<ICredential>();
            }
        }


    }

    internal class AccountMap : EntityTypeConfiguration<Account> {

        public AccountMap() {

            this.HasKey(k => k.ID).ToTable("Account", "dxsecurity");
            this.HasMany(r => r.Credentials).WithRequired(r => r.Account).HasForeignKey(k => k.accountID);



        }

    }
}
