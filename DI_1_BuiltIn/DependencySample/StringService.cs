using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_1_BuiltIn.DependencySample
{
    public class StringServices : IStringServices
    {
        public string SetPrefix(string text, string prefix)
        {
            return string.Format("{0}_{1}", prefix, text);
        }
    }
}
