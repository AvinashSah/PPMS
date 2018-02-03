CREATE TABLE [dbo].[UserRoleMapping] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [PK_UserRoleMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRoleMapping_RoleMaster] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[RoleMaster] ([Id]),
    CONSTRAINT [FK_UserRoleMapping_UserMaster] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserMaster] ([Id])
);

