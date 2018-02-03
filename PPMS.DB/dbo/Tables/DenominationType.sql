CREATE TABLE [dbo].[DenominationType] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Currency]    NVARCHAR (50)  NOT NULL,
    [Value]       INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedOn]   ROWVERSION     NOT NULL,
    CONSTRAINT [PK_DenominationType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

