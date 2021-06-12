CREATE TABLE [dbo].[customer]
(
	[customerId] INT NOT NULL PRIMARY KEY, 
    [firstName] NVARCHAR(50) NULL, 
    [lastName] NVARCHAR(50) NULL, 
    [address] NVARCHAR(50) NULL, 
    [contactNumber] NVARCHAR(50) NULL 
)
