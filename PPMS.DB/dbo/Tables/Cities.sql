CREATE TABLE [dbo].[Cities] (
    [ID]      BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (30) NOT NULL,
    [StateID] BIGINT       NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([ID])
);

