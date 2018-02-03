CREATE TABLE [dbo].[Meter] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [FuelTypeId]  INT            NOT NULL,
    [Type]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    [IsActive]    BIT            CONSTRAINT [DF_Meter_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Meter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Meter_FuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[FuelType] ([Id])
);

