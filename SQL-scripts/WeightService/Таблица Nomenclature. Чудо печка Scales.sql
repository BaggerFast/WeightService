-- ������� Nomenclature. ���� ����� Scales.sql
USE [ScalesDB]

INSERT INTO [db_scales].[Nomenclature]([Id],[Code],[Name],[IdRRef],[SerializedRepresentationObject],[CreateDate],[ModifiedDate])
VALUES (-2147422336,'','���� ����� ������� ������',null,'{"parents":["������ ��������","������������� ��������","�������� �� ��������� �������� 400 �"]}',getdate(),getdate())
SELECT * FROM [ScalesDB].[db_scales].[Nomenclature] where [Name] like '���� �����%'
