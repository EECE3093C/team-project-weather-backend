CREATE TABLE [dbo].[Plant] (
    [Plant_ID]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [PlantName]        NVARCHAR (255) NOT NULL,
    [PlantDescription] VARCHAR (MAX)  NULL,
    [WeatherType_FK]   INT            NOT NULL,
    CONSTRAINT [PK_Plant] PRIMARY KEY CLUSTERED ([Plant_ID] ASC)
);


GO

