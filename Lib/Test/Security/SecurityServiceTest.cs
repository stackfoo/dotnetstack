using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using StackFoo.Data;
using Xunit;
using StackFoo.Security.Model;
using StackFoo.Security.Service;

namespace Test.Security {
    public class SecurityServiceTest {

        [Fact]
        public void WrongPasswordReturnsFalse() {

            Credential mockCred = new Credential();
            mockCred.token = "MagicHat";
            mockCred.credential = "Wrong";

            Mock<IRepository<Credential>> mockRepo = new Mock<IRepository<Credential>>();
            mockRepo.Setup(g => g.Get(It.IsAny<System.Linq.Expressions.Expression<Func<Credential, bool>>>(), null, It.IsAny<string>())).Returns(new Credential[] { mockCred });

            ISecurityService securityService = new SecurityService();
            ((SecurityService)securityService).CredentialRepository = mockRepo.Object;

            Assert.False(securityService.Authenticate("MagicHat", "ImNotAFairyTale"));


        }

    }
}
