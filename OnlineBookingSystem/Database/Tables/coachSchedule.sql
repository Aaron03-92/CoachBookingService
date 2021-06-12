CREATE TABLE [dbo].[coachSchedule]
(
	[coachScheduleId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [stationDeparture] NVARCHAR(50) NULL, 
    [stationArrival ] NVARCHAR(50) NULL, 
    [timeOfDeparture] VARCHAR(50) NULL, 
    [timeOfArrival] VARCHAR(50) NULL, 
    [dateOfDeparture] DATE NULL, 
    [Price] INT NULL, 
    [coachId] INT NULL, 
    CONSTRAINT [FK_coachSchedule_Coach] FOREIGN KEY ([coachId]) REFERENCES [Coach]([coachId])
)
