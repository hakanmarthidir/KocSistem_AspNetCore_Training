using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_2_AutofacImplementation.DependencySample
{
    public interface IStringServices
    {
        string SetPrefix(string text, string prefix);
    }

}
