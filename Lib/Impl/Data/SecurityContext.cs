using StackFoo.Security.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFoo.Data {
    public class SecurityContext : DbContext {

        static SecurityContext() {
            Database.SetInitializer<SecurityContext>(null);

        }



        public DbSet<Account> Accounts { get; set; }
        public DbSet<Credential> Credentials { get; set; }

        public SecurityContext()
            : base("dxcontext") {

            base.Configuration.LazyLoadingEnabled = false;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {



            modelBuilder.Configurations.Add(new CredentialMap());
            modelBuilder.Configurations.Add(new AccountMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
