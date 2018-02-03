CREATE TABLE [dbo].[UserMaster] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [EmailId]   NVARCHAR (50) NULL,
    [Mobile]    INT           NOT NULL,
    [IsActive]  BIT           CONSTRAINT [DF_UserMaster_IsActive] DEFAULT ((1)) NOT NULL,
    [EmpId]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

