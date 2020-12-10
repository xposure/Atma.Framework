using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atma.Math.Members;

namespace Atma.Math.Types
{
    class AnyType : AbstractType
    {
        public AnyType(string name)
        {
            Name = name;
        }

        public override string Name { get; }

        public override string TypeComment
        {
            get { throw new NotSupportedException(); }
        }

        public override IEnumerable<Member> GenerateMembers()
        {
            throw new NotSupportedException();
        }
    }
}
