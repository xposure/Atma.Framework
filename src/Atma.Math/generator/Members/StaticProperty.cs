using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atma.Math.Types;

namespace Atma.Math.Members
{
    class StaticProperty : Property
    {
        public StaticProperty(string name, AbstractType type) : base(name, type)
        {
            Static = true;
        }
    }
}
