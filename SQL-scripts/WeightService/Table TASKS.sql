-- Table [TASKS]
select
	 [tasks].[UID] [TASK_UID]
	,[scales].[ID] [SCALE_ID]
	,[scales].[DESCRIPTION] [SCALE]
	,[types].[UID] [TASK_TYPE_UID]
	,[types].[NAME] [TASK]
	,[tasks].[ENABLED]
from [db_scales].[TASKS] [tasks]
left join [db_scales].[TASKS_TYPES] [types] on [types].[UID]=[tasks].[TASK_UID]
left join [db_scales].[SCALES] [scales] on [scales].[ID]=[tasks].[SCALE_ID]
order by [SCALE], [TASK]