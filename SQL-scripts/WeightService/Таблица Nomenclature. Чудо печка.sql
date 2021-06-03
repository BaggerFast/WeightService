-- ������� Nomenclature. ���� �����
use [VSDWH]
--select * from [DW].[DimNomenclatures] where name like '�������� �� ��������� �������� 400 �'
go
declare @name nvarchar(255) = N'���� �����'
declare @namefull nvarchar(255) = N'���������� ������� ������'
declare @comment nvarchar(255) = N'�����������'
declare @insert bit = 0
if not exists (select 1 from [DW].[DimNomenclatures] where [Name] = @name) and @insert = 1 begin
	insert into [DW].[DimNomenclatures] ([Code],[Marked],[Name],[Parents]
		,[Article],[Weighted],[GUID_Mercury],[KeepTrackOfCharacteristics],[NameFull],[Comment]
		,[IsService],[IsProduct],[AdditionalDescriptionOfNomenclature],[NomenclatureGroupCost],[NomenclatureGroup],[ArticleCost]
		,[Brand],[NomenclatureType],[VATRate],[Unit],[Weight]
		,[boxTypeID],[boxTypeName],[packTypeID],[packTypeName]
		,[SerializedRepresentationObject],[CreateDate],[DLM],[StatusID],[InformationSystemID],[CodeInIS],[RelevanceStatus],[NormalizationStatus],[MasterId])
	values (
		 ''            -- [Code]
		,0             -- [Marked]
		,@name         -- [Name]
		,'{"parents":["������ ��������","������������� ��������","�������� �� ��������� �������� 400 �"]}'  -- [Parents]
		,''            -- [Article]
		,1             -- [Weighted]
		,null          -- [GUID_Mercury]
		 ,0            -- [KeepTrackOfCharacteristics]
		 ,@namefull    -- [[NameFull]]
		 ,@comment     -- [Comment]
		 ,0  -- [IsService]
		 ,1  -- [IsProduct]
		 ,NULL  -- [AdditionalDescriptionOfNomenclature]
		 ,NULL  -- [NomenclatureGroupCost]
		 ,NULL  -- [NomenclatureGroup]
		 ,NULL  -- [ArticleCost]
		 ,0xA21BA4BF0139EB1B11EA225CFD85FE39  -- [Brand]
		 ,0x9FD1001A4D872B0E11E085DB174FF519  -- [NomenclatureType]
		 ,'���10'  -- [VATRate]
		 ,'��'  -- [Unit]
		 ,0.400  -- [Weight]
		 ,0x93FD001E6722B44911E2F2F2391231C3  -- [boxTypeID]
		 ,'������� �2 400 ����� (380*230*230)'  -- [boxTypeName]
		 ,0xA219A4BF0139EB1B11E9F0E7AE9810DF  -- [packTypeID]
		 ,'����� 15 �����'  -- [packTypeName]
		 ,NULL  -- [SerializedRepresentationObject]
		 --,-2147441687  -- [ID]
		 ,getdate()  -- [CreateDate]
		 ,getdate()  -- [DLM]
		 ,1  -- [StatusID]
		 ,1  -- [InformationSystemID]
		 ,0xA21CA4BF0139EB1B11EA48C777CD34BC  -- [CodeInIS]
		 ,NULL  -- [RelevanceStatus]
		 ,NULL  -- [NormalizationStatus]
		 ,null  -- [MasterId]
	)
end
select [Id],* from [DW].[DimNomenclatures] where [Name] like '���� �����%'
