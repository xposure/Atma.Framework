using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atma.Math.Members;

namespace Atma.Math.Types
{
    partial class SwizzleType
    {
        public override IEnumerable<Member> GenerateMembers()
        {
            // fields
            // yield return new Field("values", new ArrayType(BaseType, $"[{Components}]"))
            // {
            //     Comment = $"component data"
            // };
            foreach (var f in Fields)
                yield return new Field(f, BaseType)
                {
                    Visibility = "private",
                    Readonly = true,
                    Comment = $"{f}-component"
                };

            // // ctor
            // yield return new Constructor(this, Fields)
            // {
            //     Visibility = "private",
            //     Parameters = Fields.TypedArgs(BaseType),
            //     Initializers = Fields,
            //     Comment = $"Constructor for {Name}."
            // };

            // properties
            foreach (var swizzle in Swizzle(0))
            {
                var type = VectorTypeFor(swizzle.Length);

                // xyzw
                yield return new Property(swizzle, type)
                {
                    GetterLine = Construct(type, swizzle.CommaSeparated()),
                    Comment = $"Returns {VectorType.Name}.{swizzle} swizzling.",
                    Inline = true

                };

                // rgba
                yield return new Property(ToRgba(swizzle), type)
                {
                    GetterLine = Construct(type, swizzle.CommaSeparated()),
                    Comment = string.Format("Returns {0}.{1} swizzling (equivalent to {0}.{2}).", VectorType.Name, ToRgba(swizzle), swizzle),
                    Inline = true
                };
            }
        }
    }
}
