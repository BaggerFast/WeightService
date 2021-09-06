-- Nomenclature. Master records.
use [VSDWH]
select 
	 [n].[ID]
	,[n].[Code]
	,[n].[Marked]
	,[n].[Name]
	,[n].[Parents]
	,[n].[Article]
	,[n].[Weighted]
	,[n].[GUID_Mercury]
	,[n].[KeepTrackOfCharacteristics]
	,[n].[NameFull]
	,[n].[Comment]
	,[n].[IsService]
	,[n].[IsProduct]
	,[n].[AdditionalDescriptionOfNomenclature]
	--,[n].[NomenclatureGroupCost]
	,[ngc].[Name] [NomenclatureGroupCost]
	--,[n].[NomenclatureGroup]
	,[ng].[Name] [NomenclatureGroup]
	,[n].[ArticleCost]
	--,[n].[Brand]
	,[br].[Name] [Brand]
	--,[n].[NomenclatureType]
	,[nt].[Name] [NomenclatureType]
	,[n].[VATRate]
	,[n].[Unit]
	,[n].[Weight]
	,[n].[boxTypeID]
	,[n].[boxTypeName]
	,[n].[packTypeID]
	,[n].[packTypeName]
	,[n].[SerializedRepresentationObject]
	,[n].[CreateDate]
	,[n].[DLM]
	--,[n].[StatusID]
	,[st].[Name] [Status]
	,[n].[InformationSystemID]
	,[n].[CodeInIS]
	,[n].[RelevanceStatus]
	,[n].[NormalizationStatus]
	,[n].[MasterId]
from [DW].[DimNomenclatures] [n]
left join [DW].[DimBrands] [br] on [n].[Brand] = [br].[CodeInIS]
left join [DW].[DimNomenclatureGroups] [ng] on [n].[NomenclatureGroup] = [ng].[CodeInIs]
left join [DW].[DimNomenclatureGroups] [ngc] on [n].[NomenclatureGroupCost] = [ngc].[CodeInIs]
left join [DW].[DimTypesOfNomenclature] [nt] on [n].[NomenclatureType] = [nt].[CodeInIs]
left join [ETL].[Statuses] [st] on [n].[StatusID] = [st].[StatusID]
where [n].[IsProduct] = 1 and [n].[InformationSystemID] = 7 and [n].[MasterId] = [n].[Id]
order by [n].[Name]
--select * from [ETL].[Statuses]

select * from [DW].[DimNomenclatures] where id = -2147424992
select [Id], [MasterId], * from [DW].[DimNomenclatures] where [Name] = N'���������� �������'