﻿CREATE LOGIN [scale01] 
WITH 
	PASSWORD = 'Pa$$w0rd',
	DEFAULT_DATABASE = [$(DatabaseName)],
	CHECK_EXPIRATION = OFF, 
	CHECK_POLICY     = OFF
GO

CREATE USER [scale01] 
FOR LOGIN [scale01] WITH DEFAULT_SCHEMA=[scales_db]
GO

ALTER ROLE [db_scales_users] ADD MEMBER [Scale01]
GO