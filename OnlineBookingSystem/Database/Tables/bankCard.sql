CREATE TABLE [dbo].[bankCard]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [cardType] NVARCHAR(50) NULL, 
    [cardNumber] BIGINT NULL, 
    [nameOnCard] NVARCHAR(50) NULL, 
    [expiryDate] NVARCHAR(50) NULL, 
    [customerId] INT NULL, 
    CONSTRAINT [FK_bankCard_customer] FOREIGN KEY ([customerId]) REFERENCES [customer]([customerId])
)
