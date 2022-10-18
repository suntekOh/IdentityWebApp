CREATE TABLE [dbo].[SecPortalModuleAccess] (
    [PortalModuleAccessId]      INT                IDENTITY (1000000, 1) NOT NULL,
    [PortalModuleId]            INT                NOT NULL,
    [PortalModuleAccessName]    NVARCHAR (2000)    NULL,
    [RowCreatedBy]              VARCHAR (250)      NULL,
    [RowCreatedDateTimeUTC]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          VARCHAR (250)      NULL,
    [RowLastUpdatedDateTimeUTC] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_SecPortalModuleAccess] PRIMARY KEY CLUSTERED ([PortalModuleAccessId] ASC),
    CONSTRAINT [FK_SecPortalModuleAccess_CommonPortalModule] FOREIGN KEY ([PortalModuleId]) REFERENCES [dbo].[SecPortalModule] ([PortalModuleId])
);

