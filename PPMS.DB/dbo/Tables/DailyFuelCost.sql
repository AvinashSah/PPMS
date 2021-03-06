﻿CREATE TABLE [dbo].[DailyFuelCost] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [FuelTypeId]   INT           NOT NULL,
    [CostPerLiter] NVARCHAR (50) NOT NULL,
    [Date]         DATE          NOT NULL,
    [IsActive]     BIT           CONSTRAINT [DF_DailyFuelCost_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_DailyFuelCost] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DailyFuelCost_FuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[Fuel] ([Id])
);

