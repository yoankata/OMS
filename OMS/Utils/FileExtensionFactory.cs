using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Utils
{
    public static class FileExtensionFactory
    {
        public static string GetTypeExtension(Type type)
        {
            if (type.Name == "AAATransaction")
                return OMS.AAA.ToString().ToLower();
                        
            if (type.Name == "BBBTransaction")
                return OMS.BBB.ToString().ToLower();

            if (type.Name == "CCCTransaction")
                return OMS.CCC.ToString().ToLower();

            throw new InvalidOperationException($"Type {type} is unexpected!");
        }
    }
}
