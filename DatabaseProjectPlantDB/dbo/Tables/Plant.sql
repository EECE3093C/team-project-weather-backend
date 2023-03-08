CREATE TABLE [dbo].[Plant] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [Description]    VARCHAR (MAX)  NULL,
    [WeatherType_FK] INT            NOT NULL,
    CONSTRAINT [PK_Plant] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

