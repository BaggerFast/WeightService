-- Blazor. 2. ����������
use [ScalesDB]
select
	 [sc].[Id]                 -- ID
	,[sc].[Description]        -- ������������
	,[sc].[DeviceNumber]       -- �����
	,'' [Storage]              -- �����
	,0 [State]                 -- ������
	,[sc].[TemplateIdDefault] [TemplateDefaultId] -- ������� ������ ��������. Id
	,[t1].[Title] [TemplateDefaultTitle]          -- ������� ������ ��������. ���������
	,[sc].[TemplateIdSeries] [TemplateSeriesId]   -- ������ ���. ��������. Id
	,[t2].[Title] [TemplateSeriesTitle]           -- ������ ���. ��������. Id. ���������
from [db_scales].[Scales] [sc]
left join [db_scales].[Templates] [t1] on [sc].[TemplateIdDefault] = [t1].[1CTemplateID]
left join [db_scales].[Templates] [t2] on [sc].[TemplateIdSeries] = [t2].[1CTemplateID]
