// ReSharper disable VirtualMemberCallInConstructor, ClassWithVirtualMembersNeverInherited.Global

using System.Diagnostics;
using Ws.Domain.Models.Common;

namespace Ws.Domain.Models.Entities.Ref1c;

[DebuggerDisplay("{ToString()}")]
public class Bundle : EntityBase
{
    public virtual decimal Weight { get; set; }
    public virtual string Name { get; set; } = string.Empty;

    public override bool IsNew => CreateDt == DateTime.MinValue;
    public override string ToString() => $"{Name} | {Weight}";

    protected override bool CastEquals(EntityBase obj)
    {
        Bundle item = (Bundle)obj;
        return Equals(Weight, item.Weight) && Equals(Name, item.Name);
    }
}