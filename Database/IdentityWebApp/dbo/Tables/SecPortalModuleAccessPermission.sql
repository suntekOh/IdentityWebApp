CREATE TABLE [dbo].[SecPortalModuleAccessPermission] (
    [PortalModuleAccessPermissionId] INT                IDENTITY (1000000, 1) NOT NULL,
    [PortalModuleAccessId]           INT                NOT NULL,
    [RoutingPath]                    NVARCHAR (500)     NOT NULL,
    [HTTPVerb]                       NVARCHAR (500)     NOT NULL,
    [IsSelectPermission]             BIT                DEFAULT ((0)) NOT NULL,
    [IsInsertPermission]             BIT                DEFAULT ((0)) NOT NULL,
    [IsUpdatePermission]             BIT                DEFAULT ((0)) NOT NULL,
    [IsDeletePermission]             BIT                DEFAULT ((0)) NOT NULL,
    [RowCreatedBy]                   VARCHAR (250)      NULL,
    [RowCreatedDateTimeUTC]          DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]               VARCHAR (250)      NULL,
    [RowLastUpdatedDateTimeUTC]      DATETIMEOFFSET (7) NULL,
    [RowVersion]                     ROWVERSION         NOT NULL,
    CONSTRAINT [PK_SecPortalModuleAccessPermission] PRIMARY KEY CLUSTERED ([PortalModuleAccessPermissionId] ASC),
    CONSTRAINT [FK_SecPortalModuleAccessPermission_SecPortalModuleAccess] FOREIGN KEY ([PortalModuleAccessId]) REFERENCES [dbo].[SecPortalModuleAccess] ([PortalModuleAccessId])
);

