CREATE TABLE [dbo].[employeeLogin]
(
	[employeeLoginId] INT NOT NULL PRIMARY KEY, 
    [email] NVARCHAR(50) NULL, 
    [password] NVARCHAR(50) NULL, 
    [employeeId] INT NULL, 
    CONSTRAINT [FK_employeeLogin_employee] FOREIGN KEY (employeeId) REFERENCES [employee]([employeeId])
)
