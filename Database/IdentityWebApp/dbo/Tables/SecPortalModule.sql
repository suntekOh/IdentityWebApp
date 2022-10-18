CREATE TABLE [dbo].[SecPortalModule] (
    [PortalModuleId]            INT                IDENTITY (1000000, 1) NOT NULL,
    [PortalId]                  INT                NOT NULL,
    [PortalModuleName]          NVARCHAR (300)     NULL,
    [RowCreatedBy]              VARCHAR (250)      NULL,
    [RowCreatedDateTimeUTC]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          VARCHAR (250)      NULL,
    [RowLastUpdatedDateTimeUTC] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_SecPortalModule] PRIMARY KEY CLUSTERED ([PortalModuleId] ASC),
    CONSTRAINT [FK_SecPortalModule_CommonPortal] FOREIGN KEY ([PortalId]) REFERENCES [dbo].[SecPortal] ([PortalId])
);

