CREATE TABLE [dbo].[CustomerType] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [TypeName] NVARCHAR (MAX) NOT NULL,
    [IsActive] BIT            CONSTRAINT [DF_CustomerType_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

