CREATE TABLE [dbo].[DailyTankerReading] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [TankerId]          INT           NOT NULL,
    [DailyStartReading] NVARCHAR (50) NOT NULL,
    [DailyEndReading]   NVARCHAR (50) NOT NULL,
    [Date]              DATE          NOT NULL,
    [IsActive]          BIT           CONSTRAINT [DF_DailyTankerReading_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_DailyTankerReading] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DailyTankerReading_Tanker] FOREIGN KEY ([TankerId]) REFERENCES [dbo].[Tanker] ([Id])
);

