using Ws.Database.Entities.Ref1C.Clips;

namespace Ws.DeviceControl.Api.App.Features.References1C.Clips.Impl.Expressions;

public static class ClipExpressions
{
    public static Expression<Func<ClipEntity, PackageDto>> ToDto =>
        clip => new()
        {
            Id = clip.Id,
            Name = clip.Name,
            Weight = clip.Weight,
            CreateDt = clip.CreateDt,
            ChangeDt = clip.ChangeDt
        };
}