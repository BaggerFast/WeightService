-- ������� Nomenclature
use [ScalesDB]
--delete from [db_scales].[BarCodes]
--delete from [db_scales].[NomenclatureUnits]
select
	 [Id]
	,[CreateDate]
	,[ModifiedDate]
	,[Code]
	,[Name]
	,[SerializedRepresentationObject]
from [db_scales].[Nomenclature]
where name like '%���������� ��������%'
order by [Nomenclature].[Id]
