-- Table Nomenclature. ���������
select
	 [Id]
	,[CreateDate]
	,[ModifiedDate]
	,[Code]
	,[IdRRef]
	,[Name]
	,[SerializedRepresentationObject]
from [db_scales].[Nomenclature]
where name like '%���� �����%'
order by [Nomenclature].[Id]
