-- ������ ������.
-- ������ 0.0.10.
USE [ScalesDB]
SET NOCOUNT	ON
DECLARE @FILE_EXISTS INT
DECLARE @STR_COUNT INT
DECLARE @FILE NVARCHAR(255)
-- [db_scales].[AttributeDefinationList]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[AttributeDefinationList]
	BULK INSERT [db_scales].[AttributeDefinationList]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.AttributeDefinationList.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[AttributeDefinationList])
	PRINT CONVERT(CHAR(38), '[db_scales].[AttributeDefinationList]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[AttributeDefinationList]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[AttributeValues]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[AttributeValues]
	BULK INSERT [db_scales].[AttributeValues]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.AttributeValues.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[AttributeValues])
	PRINT CONVERT(CHAR(38), '[db_scales].[AttributeValues]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[AttributeValues]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[Orders]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[Orders]
	BULK INSERT [db_scales].[Orders]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.Orders.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[Orders])
	PRINT CONVERT(CHAR(38), '[db_scales].[Orders]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[Orders]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[OrderStatus]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[OrderStatus]
	BULK INSERT [db_scales].[OrderStatus]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.OrderStatus.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[OrderStatus])
	PRINT CONVERT(CHAR(38), '[db_scales].[OrderStatus]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[OrderStatus]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[OrderTypes]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[OrderTypes]
	BULK INSERT [db_scales].[OrderTypes]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.OrderTypes.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[OrderTypes])
	PRINT CONVERT(CHAR(38), '[db_scales].[OrderTypes]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[OrderTypes]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[PLU]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[PLU]
	BULK INSERT [db_scales].[PLU]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.PLU.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[PLU])
	PRINT CONVERT(CHAR(38), '[db_scales].[PLU]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[PLU]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[Scales]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[Scales]
	BULK INSERT [db_scales].[Scales]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.Scales.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[Scales])
	PRINT CONVERT(CHAR(38), '[db_scales].[Scales]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[Scales]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[SSCCStorage]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[SSCCStorage]
	BULK INSERT [db_scales].[SSCCStorage]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.SSCCStorage.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[SSCCStorage])
	PRINT CONVERT(CHAR(38), '[db_scales].[SSCCStorage]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[SSCCStorage]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[TemplateResources]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[TemplateResources]
	BULK INSERT [db_scales].[TemplateResources]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.TemplateResources.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[TemplateResources])
	PRINT CONVERT(CHAR(38), '[db_scales].[TemplateResources]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[TemplateResources]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[Templates]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[Templates]
	BULK INSERT [db_scales].[Templates]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.Templates.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[Templates])
	PRINT CONVERT(CHAR(38), '[db_scales].[Templates]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[Templates]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_scales].[WeithingFact]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_scales].[WeithingFact]
	BULK INSERT [db_scales].[WeithingFact]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_scales.WeithingFact.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_scales].[WeithingFact])
	PRINT CONVERT(CHAR(38), '[db_scales].[WeithingFact]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_scales].[WeithingFact]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
-- [db_sscc].[SSCCStorage]
BEGIN TRANSACTION
BEGIN TRY
	TRUNCATE TABLE [db_sscc].[SSCCStorage]
	BULK INSERT [db_sscc].[SSCCStorage]
		FROM 'd:\DevSource\Job\SVN-Scales\ScalesSQL\Data\db_sscc.SSCCStorage.csv'
		WITH (CODEPAGE = '1251', FIRSTROW = 2, FIELDTERMINATOR = ';', ROWTERMINATOR = '\n', TABLOCK)
	COMMIT TRANSACTION
	SET @STR_COUNT = (SELECT COUNT(*) FROM [db_sscc].[SSCCStorage])
	PRINT CONVERT(CHAR(38), '[db_sscc].[SSCCStorage]') + ' [+] ������������� ' + CONVERT(NVARCHAR(10), @STR_COUNT) + ' ����� '
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT CONVERT(CHAR(38), '[db_sscc].[SSCCStorage]') + ' [!] ������ �������, ���������� ��������!'
END CATCH
--
SET NOCOUNT	OFF
