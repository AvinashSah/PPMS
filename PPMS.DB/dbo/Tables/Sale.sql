CREATE TABLE [dbo].[Sale] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [CustomerId]        INT           NULL,
    [SellerId]          INT           NULL,
    [ItemType]          NVARCHAR (50) NOT NULL,
    [FuelTypeId]        INT           NOT NULL,
    [SalesAmount]       NVARCHAR (50) NOT NULL,
    [PaymentMode]       NVARCHAR (50) NOT NULL,
    [FuelQuantity]      NVARCHAR (50) NOT NULL,
    [UniqueTokenNumber] NVARCHAR (50) NULL,
    [IsActive]          BIT           CONSTRAINT [DF_Sale_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sale_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Sale_FuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[Fuel] ([Id])
);

