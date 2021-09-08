﻿CREATE TABLE [DW].[FactProdApplications]
(
	[DateID]						int,
	[Marked]						bit,
	[Posted]						bit,
	[DocNum]						nvarchar(12),
	[DocDate]						datetime,
	[OrgID]							binary(16),	     	     
	[Склад сырья]					binary(16),
	[Склад готовой продукции]		binary(16),
	[Комментарий]					nvarchar(1000),
	[Вид операции]					nvarchar(25),
	[Номенклатура]					binary(16),
	[Единица измерения мест]		nvarchar(100),
	[Характеристика]				nvarchar(100),
	[Количество замесов]			float,
	[Замес]							float,
	[Рецептура]						binary(16),
	[Фарш Вес]						float,
	[Фарш Расчет]					float,
	[Фарш Утиль]					float,
	[Средний вес штуки]				float,
	[Выход готовой продукции]		float,
	[Брак готовой продукции]		float,
	[Брак дегустация]				float,
	[Отклонение килограмм]			float,
	[Отклонение процент]			float,
	[Брак из рецепта]				float,
	[Вид оболочки]					binary(16),
	[Примечание]					nvarchar(1000),
	[Заказ на производство]			binary(16),
	[Серия номенклатуры]			binary(16),
	[Количество замесов отдел качества] float,
	[_DateID]						date,
	[_OrgID]						int,	     	     
	[_Склад сырья]					int,
	[_Склад готовой продукции]		int,
	[_Номенклатура]					int,
	[ID]							BIGINT NOT NULL IDENTITY(-9223372036854775808,1),
	[CreateDate]					datetime NOT NULL,
	[DLM]							datetime  NOT NULL,
	[StatusID]						int  NOT NULL,
	[InformationSystemID]			int NOT NULL,
	[CodeInIS]						varbinary(16) NOT NULL,
	[_LineNo]						int NOT NULL, 
    [CHECKSUMM]						BIGINT NOT NULL,
	[Active]						BIT NULL DEFAULT 1, 

    PRIMARY KEY CLUSTERED ([InformationSystemID] ASC,[CodeInIS] ASC,[_LineNo] ASC, [ID] ASC)

) ON [FACTFileGrooup]
GO