CREATE TABLE [dbo].[Customer] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [ContactNumber]  INT            NULL,
    [EmailId]        NVARCHAR (50)  NULL,
    [AddressLineOne] NVARCHAR (MAX) NULL,
    [AddressLineTwo] NVARCHAR (MAX) NULL,
    [City]           NVARCHAR (50)  NULL,
    [District]       NVARCHAR (50)  NULL,
    [State]          NVARCHAR (50)  NULL,
    [PinCode]        INT            NULL,
    [CustomerTypeId] INT            NOT NULL,
    [IsActive]       BIT            CONSTRAINT [DF_Customer_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY ([CustomerTypeId]) REFERENCES [dbo].[CustomerType] ([Id])
);

