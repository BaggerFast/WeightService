-- Scales - Nomenclature WeightTara
-- Connect from SQLSRSP01\LEEDS
use [VSDWH]
SELECT [Name], [Code], [n].[boxTypeName], [n].[packTypeName]
FROM [DW].[DimNomenclatures] [n]
where [n].[Code]='���00028396'
--where [n].[Name]='���������� �.�. 350 �'

-- boxWeight (360) + quantly (20) * packWeight (5) = 460 �� / 1000 = 0,46 ��
