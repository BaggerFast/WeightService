// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.TableScaleModels.Scales;
using DataCore.Sql.TableScaleModels.TasksTypes;

namespace DataCore.Sql.TableScaleModels.Tasks;

/// <summary>
/// Table validation "TASKS".
/// </summary>
public sealed class TaskValidator : SqlTableValidator<TaskModel>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public TaskValidator() : base(false, false)
    {
        RuleFor(item => item.TaskType)
            .NotEmpty()
            .NotNull()
            .SetValidator(new TaskTypeValidator());
        RuleFor(item => item.Scale)
            .NotEmpty()
            .NotNull()
            .SetValidator(new ScaleValidator());
    }
}
