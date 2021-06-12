CREATE TABLE [dbo].[Coach]
(
	[coachId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [coachName] NVARCHAR(50) NULL, 
    [coachType] NVARCHAR(50) NULL, 
    [numberOfSeats] INT NULL
)
