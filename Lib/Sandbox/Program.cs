using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using StackFoo.Security.Service;


namespace Sandbox {

    class Program {
        static void Main(string[] args) {

            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            section.Configure(container, "Core");


            ISecurityService svc = container.Resolve<ISecurityService>();
            Console.WriteLine(svc.Authenticate("MagicHat", "ImNotAFairyTale"));



            Console.ReadLine();

        }
    }
}
