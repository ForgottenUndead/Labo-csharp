CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NomEvent] NVARCHAR(50) NOT NULL, 
    [EventTime] DATE NOT NULL, 
    [isComplete] BIT NULL
)
