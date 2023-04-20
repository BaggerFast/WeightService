// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.TableScaleModels.TasksTypes;

/// <summary>
/// Table validation "TASKS_TYPES".
/// </summary>
public sealed class TaskTypeValidator : WsSqlTableValidator<TaskTypeModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public TaskTypeValidator() : base(false, false)
    {
        RuleFor(item => item.Name)
            .NotEmpty()
            .NotNull();
    }
}