-- ���������. ������������
-- �������
select
	 cast([CreateDate] as date) [CreateDate]
	,count(*) [Count]
from [db_scales].[Nomenclature]
group by cast([CreateDate] as date)
-- ��������
select
	 cast([ModifiedDate] as date) [ModifiedDate]
	,count(*) [Count]
from [db_scales].[Nomenclature]
group by cast([ModifiedDate] as date)
