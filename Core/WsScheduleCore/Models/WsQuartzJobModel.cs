// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsScheduleCore.Models;

public sealed class WsQuartzJobModel : IJob
{
    #region Public and private fields, properties, constructor

    private List<Action> Actions { get; } = new();

    #endregion

    #region Public and private methods

    public async Task Execute(IJobExecutionContext context)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        foreach (Action action in Actions)
        {
            action();
        }
    }

    #endregion
}