-- ���������. ������ ��������
-- �������
select
	 cast([CreateDate] as date) [CreateDate]
	,count(*) [Count]
from [db_scales].[ProductionFacility]
group by cast([CreateDate] as date)
-- ��������
select
	 cast([ModifiedDate] as date) [ModifiedDate]
	,count(*) [Count]
from [db_scales].[ProductionFacility]
group by cast([ModifiedDate] as date)
