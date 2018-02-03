CREATE TABLE [dbo].[CustomerType] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [TypeName] NVARCHAR (MAX) NOT NULL,
    [IsActive] BIT            CONSTRAINT [DF_CustomerType_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

