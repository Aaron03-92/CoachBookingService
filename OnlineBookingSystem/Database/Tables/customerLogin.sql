CREATE TABLE [dbo].[Login]
(
	[customerLoginId] INT NOT NULL PRIMARY KEY, 
    [email] NVARCHAR(50) NULL, 
    [password] NCHAR(10) NULL, 
    [customerId] INT NULL, 
    CONSTRAINT [FK_Login_customer] FOREIGN KEY ([customerId]) REFERENCES [customer]([customerId])
)
