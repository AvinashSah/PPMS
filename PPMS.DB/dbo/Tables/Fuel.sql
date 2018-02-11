CREATE TABLE [dbo].[Fuel] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [IsActive]    BIT            CONSTRAINT [DF_FuelType_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [Type] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_FuelType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

