CREATE TABLE [dbo].[Tanker] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FuelTypeId]  INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Size]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    [IsActive]    BIT            NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_Tanker] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tanker_FuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[Fuel] ([Id])
);

