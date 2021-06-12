CREATE TABLE [dbo].[employee]
(
	[employeeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [firstName] NVARCHAR(50) NULL, 
    [lastName] NVARCHAR(50) NULL, 
    [position] NVARCHAR(50) NULL, 
    [contactNumber] NVARCHAR(50) NULL 
)
