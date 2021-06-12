CREATE TABLE [dbo].[Bookings]
(
	[bookingId] INT NOT NULL PRIMARY KEY, 
    [seatNo] INT NULL, 
    [ticketType] NVARCHAR(50) NULL, 
    [price] INT NULL, 
    [dateOfPurchase] DATE NULL, 
    [customerId] INT NULL, 
    [scheduleId] INT NULL, 
    CONSTRAINT [FK_Bookings_customer] FOREIGN KEY ([customerId]) REFERENCES [customer]([customerId]), 
    CONSTRAINT [FK_Bookings_coachschedule] FOREIGN KEY ([scheduleId]) REFERENCES [coachSchedule]([coachScheduleId])
)
