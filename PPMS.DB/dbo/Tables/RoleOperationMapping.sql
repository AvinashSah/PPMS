CREATE TABLE [dbo].[RoleOperationMapping] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [RoleId]      INT NOT NULL,
    [OperationId] INT NOT NULL,
    CONSTRAINT [PK_RoleOperationMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleOperationMapping_OperationMaster] FOREIGN KEY ([OperationId]) REFERENCES [dbo].[OperationMaster] ([Id]),
    CONSTRAINT [FK_RoleOperationMapping_RoleMaster] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[RoleMaster] ([Id])
);

