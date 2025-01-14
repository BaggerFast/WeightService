// ReSharper disable VirtualMemberCallInConstructor, ClassWithVirtualMembersNeverInherited.Global

using System.Diagnostics;
using System.Net;
using TscZebra.Plugin.Abstractions.Enums;
using Ws.Domain.Models.Common;
using Ws.Domain.Models.Entities.Ref;

namespace Ws.Domain.Models.Entities.Devices;

[DebuggerDisplay("{ToString()}")]
public class Printer : EntityBase
{
    public virtual IPAddress Ip { get; set; } = IPAddress.Parse("127.0.0.1");
    public virtual ProductionSite ProductionSite { get; set; } = new();
    public virtual PrinterTypes Type { get; set; } = PrinterTypes.Tsc;
    public virtual string Name { get; set; } = string.Empty;
    public virtual string DisplayName => IsExists ? $"{Name} | {Ip}" : Name;

    protected override bool CastEquals(EntityBase obj)
    {
        Printer item = (Printer)obj;
        return Equals(Ip, item.Ip) &&
               Equals(Type, item.Type) &&
               Equals(Name, item.Name) &&
               Equals(ProductionSite, item.ProductionSite);
    }
}