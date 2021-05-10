﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


--ALTER DATABASE [ScalesDB] SET TRUSTWORTHY ON;
--GO
--ALTER ASSEMBLY [ScalesDB]	WITH PERMISSION_SET=EXTERNAL_ACCESS;
ALTER ASSEMBLY [ScalesDB]  WITH PERMISSION_SET = UNSAFE;
GO


IF  EXISTS (
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[ZplPipe]') 
AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
) 
DROP PROCEDURE [db_scales].[ZplPipe]
ALTER SCHEMA [db_scales] TRANSFER [dbo].[ZplPipe]
GO


IF  EXISTS (
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[XSLTTransform]') 
AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
)
DROP PROCEDURE [db_scales].[XSLTTransform]
ALTER SCHEMA [db_scales] TRANSFER [dbo].[XSLTTransform]
GO

IF  EXISTS (
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[ZplPipeNow]') 
AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
)
DROP PROCEDURE [db_scales].[ZplPipeNow]
ALTER SCHEMA [db_scales] TRANSFER [dbo].[ZplPipeNow]
GO

IF  EXISTS (
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[ZplСalibration]') 
AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
)
DROP PROCEDURE [db_scales].[ZplСalibration]
ALTER SCHEMA [db_scales] TRANSFER [dbo].[ZplСalibration]
GO

IF  EXISTS (
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[ZplHostStatus]') 
AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
)
DROP PROCEDURE [db_scales].[ZplHostStatus]
ALTER SCHEMA [db_scales] TRANSFER [dbo].[ZplHostStatus]
GO



IF  EXISTS (
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[ZplFontsClear]') 
AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
)
DROP PROCEDURE [db_scales].[ZplFontsClear]
ALTER SCHEMA [db_scales] TRANSFER [dbo].[ZplFontsClear]
GO



IF  EXISTS (
SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[ZplFontUpload]') 
AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
)
DROP PROCEDURE [db_scales].[ZplFontUpload]
ALTER SCHEMA [db_scales] TRANSFER [dbo].[ZplFontUpload]
GO




--IF  EXISTS (
--SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[LogoUpload]') 
--AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
--)
--DROP PROCEDURE [db_scales].[LogoUpload]
--ALTER SCHEMA [db_scales] TRANSFER [dbo].[LogoUpload]
--GO


--IF  EXISTS (
--SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db_scales].[LogoClear]') 
--AND type in (N'PC',N'FN', N'IF', N'TF', N'FS', N'FT')
--)
--DROP PROCEDURE [db_scales].[LogoClear]
--ALTER SCHEMA [db_scales] TRANSFER [dbo].[LogoClear]
--GO





TRUNCATE TABLE [db_sscc].[SSCCStorage];
INSERT INTO [db_sscc].[SSCCStorage] VALUES 
(460781257,0), (460710023,0);



IF NOT EXISTS( SELECT * FROM [db_scales].[ProductionFacility] ) BEGIN

	SET IDENTITY_INSERT [db_scales].[ProductionFacility] ON
	INSERT INTO [db_scales].[ProductionFacility] ([Id],[Name])
	VALUES
		(1,'Площадка 13'),
		(2,'Площадка 16'),
		(3,'Площадка 9'),
		(4,'Площадка "Камни"'),
		(0,'ProductionFacility unknown (undefined)')

	SET IDENTITY_INSERT [db_scales].[ProductionFacility] OFF

	UPDATE [db_scales].[WorkShop] SET [ProductionFacilityID] = 0 WHERE [ProductionFacilityID] IS NULL;

END

IF NOT EXISTS( SELECT * FROM [db_scales].[WorkShop] ) BEGIN

	SET IDENTITY_INSERT [db_scales].[WorkShop] ON
	INSERT INTO [db_scales].[WorkShop] ([Name], [Id],[ProductionFacilityID])
	VALUES
		('Unknown (undefined)',0,0),
		('Фасовка 1',1,1),
		('Фасовка 2',2,1),
		('Заморозка',3,2),
		('Фасока 3',4,4)
	SET IDENTITY_INSERT [db_scales].[WorkShop] OFF

END



IF NOT EXISTS( SELECT * FROM [db_scales].[OrderTypes] ) BEGIN

	INSERT INTO [db_scales].[OrderTypes] 
	VALUES
		(1,'ORDER'),
		(2,'PLU')

END


IF NOT EXISTS( SELECT * FROM [db_scales].[BarCodeTypes] ) BEGIN

	INSERT INTO [db_scales].[BarCodeTypes] 
	VALUES
		(1,'Code128'),
		(2,'Code39'),
		(3,'EAN128'),
		(4,'EAN13'),
		(5,'EAN8'),
		(6,'ITF14')

END



IF NOT EXISTS( SELECT * FROM [db_scales].[AttributeDefinationList] ) BEGIN

INSERT INTO [db_scales].[AttributeDefinationList] ([AttDefDescription],[Code],[DefaultValue],[Notes]) 
VALUES
	('GoodsName','A1','<xs:element name="GoodsName" type="xs:string" value = ""/>','Наименование товара'),
	('PlaneBoxCount','A2','<xs:element name="PlaneBoxCount" type="xs:integer" value = "15"/>','Плановое кол-во упаковок'),
	('PlanePalletCount','A3','<xs:element name="PlanePalletCount" type="xs:integer" value = "15"/>','Плановое кол-во паллет'),
	('PlanePackingOperationBeginDate','A4','<xs:element name="PlanePackingOperationBeginDate" type="xs:date" value = ""/>','Дата начала упаковки'),
	('PlanePackingOperationEndDate','A5','<xs:element name="PlanePackingOperationEndDate" type="xs:date" value = ""/>','Дата окончания упаковки'),
	('GoodsDescription','A6','<xs:element name="GoodsDescription" type="xs:string" value = ""/>','Описание товара'),
	('GoodsFullName','A7','<xs:element name="GoodsFullName" type="xs:string" value = ""/>','Полное наименование товара'),
	('GTIN','A8','<xs:element name="GTIN" type="xs:string" value = ""/>','GTIN'),
	('GLN','A9','<xs:element name="GLN" type="xs:integer" value = ""/>','GLN'),
	('GoodsShelfLifeDays','AA','<xs:element name="GoodsShelfLifeDays" type="xs:integer" value = "30"/>','Срок годности'),
	('GoodsTareWeight','AB','<xs:element name="GoodsTareWeight" type="xs:string" value = ""/>','Вес единицы тары'),
	('GoodsBoxQuantly','AC','<xs:element name="GoodsBoxQuantly" type="xs:string" value = ""/>','Кол-во вложений'),
	('ProductDate','AD','<xs:element name="ProductDate" type="xs:date" value = ""/>','Дата упаковки'),
	('Template','AE','<xs:element name="TemplateName" type="xs:string" value = ""/>','Шаблон этикетки')
END

--DECLARE @OrderID	int = 1
--DECLARE @Weight	decimal(10,3) = 15.264
--DECLARE @SSCC		varchar(50)
--DECLARE @WeithingDate datetime

--EXECUTE [db_scales].[SetWeithingFact] 
--   @OrderID
--  ,@Weight
--  ,@SSCC OUTPUT
--  ,@WeithingDate OUTPUT 

--SELECT @SSCC, @WeithingDate



