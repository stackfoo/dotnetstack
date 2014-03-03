using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using StackFoo.Data;
using StackFoo.Security.Model;

namespace StackFoo.Security.Service {
    public class SecurityService:ISecurityService {

        [Dependency]
        public SecurityContext DBContext { get; set; }

        private IRepository<Credential> credentialRepository = null;
        public IRepository<Credential> CredentialRepository {
            get {
                if (this.credentialRepository == null) return new Repository<Credential>(this.DBContext);
                return this.credentialRepository;
            }
            set {
                this.credentialRepository = value;
            }
        }


        bool ISecurityService.Authenticate(string securityToken, string passWord) {

            bool returnValue = false;

            if (string.IsNullOrEmpty(securityToken)) throw new ArgumentNullException("token");
            if (string.IsNullOrEmpty(passWord)) throw new ArgumentNullException("passWord");

            ICredential credential = null;
            IEnumerable<Credential> results = null;
            using (this.CredentialRepository) {

                results = this.CredentialRepository.Get(g => g.token == securityToken && g.provider == "stackfoodemo", null, "Account");

            }

            if ((results != null) && (results.Count() > 0)) {
                credential = results.First();

                returnValue = credential.credential == passWord;

            }

            return returnValue;

        }
    }

}
