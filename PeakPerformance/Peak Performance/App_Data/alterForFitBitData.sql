--This adds the two columns for FitBit data. UserId and Token

ALTER TABLE dbo.Athletes
ADD FitBitUserID NVARCHAR(50) NULL; 

ALTER TABLE dbo.Athletes
ADD FitBitAccessToken NVARCHAR(MAX) NULL; 