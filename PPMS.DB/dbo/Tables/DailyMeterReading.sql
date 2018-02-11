CREATE TABLE [dbo].[DailyMeterReading] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [MeterId]         INT           NOT NULL,
    [DayStartReading] NVARCHAR (50) NOT NULL,
    [DayEndReading]   NVARCHAR (50) NOT NULL,
    [Date]            DATE          NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_DailyMeterReading_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_DailyMeterReading] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DailyMeterReading_Meter] FOREIGN KEY ([MeterId]) REFERENCES [dbo].[Meter] ([Id])
);

