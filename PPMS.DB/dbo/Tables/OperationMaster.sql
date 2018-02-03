CREATE TABLE [dbo].[OperationMaster] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [OperationName] NVARCHAR (50)  NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_OperationMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

