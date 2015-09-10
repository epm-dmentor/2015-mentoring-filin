using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace SelfHostedSDesk
{
    public class CustomAssemblyResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            List<Assembly> baseAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            Assembly controllersAssembly =
                Assembly.LoadFrom(@"C:\GitHub\Mentoring\practice\WebAPI\SDesk\SDesk\bin\SDesk.dll");
            baseAssemblies.Add(controllersAssembly);
            return baseAssemblies;
        }
    }
}