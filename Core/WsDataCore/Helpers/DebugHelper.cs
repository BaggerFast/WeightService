// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsDataCore.Enums;

namespace WsDataCore.Helpers;

public class DebugHelper
{
	#region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	private static DebugHelper _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public static DebugHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

	#endregion

	#region Public and private methods

    public bool IsDevelop => Config switch
    {
        WsConfiguration.DevelopAleksandrov => true,
        WsConfiguration.DevelopMorozov => true,
        WsConfiguration.DevelopVS => true,
        WsConfiguration.ReleaseAleksandrov => false,
        WsConfiguration.ReleaseMorozov => false,
        WsConfiguration.ReleaseVS => false,
        _ => throw new ArgumentOutOfRangeException()
    };

    public bool IsRelease => !IsDevelop;

    public WsConfiguration Config =>
#if DEVELOPALEKSANDROV
        WsConfiguration.DevelopAleksandrov;
#elif DEVELOPMOROZOV
        WsConfiguration.DevelopMorozov;
#elif DEVELOPVS
        WsConfiguration.DevelopVS;
#elif RELEASEALEKSANDROV
        WsConfiguration.ReleaseAleksandrov;
#elif RELEASEMOROZOV
        WsConfiguration.ReleaseMorozov;
#elif RELEASEVS
        WsConfiguration.ReleaseVS;
#else
        WsConfiguration.DevelopVS;
#endif

    #endregion
}