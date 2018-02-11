CREATE TABLE [dbo].[DailyCashSaleDenomination] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Date]               DATE           NOT NULL,
    [DenominationTypeId] INT            NOT NULL,
    [Count]              INT            NOT NULL,
    [Description]        NVARCHAR (MAX) NOT NULL,
    [IsActive]           BIT            CONSTRAINT [DF_DailyCashSaleDenomination_IsActive] DEFAULT ((1)) NOT NULL,
	[CreatedBy] BIGINT NULL, 
    [Updatedby] BIGINT NULL, 
    [CreatedOn] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedOn] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_DailyCashSaleDenomination] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DailyCashSaleDenomination_DenominationType] FOREIGN KEY ([DenominationTypeId]) REFERENCES [dbo].[DenominationType] ([Id])
);

