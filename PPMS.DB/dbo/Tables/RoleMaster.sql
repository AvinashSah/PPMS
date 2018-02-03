CREATE TABLE [dbo].[RoleMaster] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [RoleName]    NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

