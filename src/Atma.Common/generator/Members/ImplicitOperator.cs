﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atma.Math.Types;

namespace Atma.Math.Members
{
    class ImplicitOperator : Function
    {
        public override string MemberPrefix => base.MemberPrefix + " implicit";
        public override string FunctionName => ReturnType.NameThat;
        public override string ReturnName => "operator";

        public ImplicitOperator(AbstractType type) : base(type, type.Name)
        {
            Static = true;
        }
    }
}
