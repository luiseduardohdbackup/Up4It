using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Up4It.Models;
using Up4It.Repositories;
using Xamarin.Forms;

namespace Up4It
{
    public static class Up4ItApp
    {
        static Assembly _reflectionAssembly;
        internal static IDictionary<Type, Type> TypeMap;
        internal static readonly MethodInfo GetDependency;

        static Up4ItApp()
        {
            TypeMap = new Dictionary<Type, Type>{
                {typeof(User), typeof(UserRepository)},
                {typeof(MeetUp), typeof(MeetUpRepository)}
            };

            GetDependency = typeof(DependencyService).GetRuntimeMethods().Single(m => m.Name.Equals("Get"));
        }

        public static void Init(Assembly assembly)
        {
            System.Threading.Interlocked.CompareExchange(ref _reflectionAssembly, assembly, null);
        }

        public static Stream LoadResource(string name)
        {
            return _reflectionAssembly.GetManifestResourceStream(name);
        }
    }
}
