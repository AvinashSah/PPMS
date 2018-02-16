CREATE TABLE [dbo].[States] (
    [ID]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [country_id] BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([country_id]) REFERENCES [dbo].[Countries] ([ID])
);

