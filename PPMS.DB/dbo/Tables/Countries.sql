CREATE TABLE [dbo].[Countries] (
    [ID]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [ShortName] VARCHAR (3)   NOT NULL,
    [Name]      VARCHAR (150) NOT NULL,
    [Phonecode] BIGINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

