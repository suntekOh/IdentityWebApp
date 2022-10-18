CREATE TABLE [dbo].[SecPortal] (
    [PortalId]                  INT                IDENTITY (1000000, 1) NOT NULL,
    [PortalName]                NVARCHAR (300)     NOT NULL,
    [RowCreatedBy]              VARCHAR (250)      NULL,
    [RowCreatedDateTimeUTC]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          VARCHAR (250)      NULL,
    [RowLastUpdatedDateTimeUTC] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_SecPortal] PRIMARY KEY CLUSTERED ([PortalId] ASC)
);

