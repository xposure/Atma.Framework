using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atma.Math.Types;

namespace Atma.Math.Members
{
    class AggregatedProperty : Property
    {
        public AggregatedProperty(IEnumerable<string> fields, string name, AbstractType type, string sep, string comment) : base(name, type)
        {
            GetterLine = fields.Aggregated(" " + sep + " ");
            Comment = comment;
        }
    }
}
