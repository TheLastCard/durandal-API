﻿USE "aspnet-Durandal-API-20160416085226"
GO

ALTER ROLE db_datareader ADD MEMBER [NT-MYNDIGHET\NETTVERKSTJENESTE]
GO
ALTER ROLE db_datawriter ADD MEMBER [NT-MYNDIGHET\NETTVERKSTJENESTE]
GO