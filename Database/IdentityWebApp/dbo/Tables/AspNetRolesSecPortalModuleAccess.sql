CREATE TABLE [dbo].[AspNetRolesSecPortalModuleAccess] (
    [RoleId]                    UNIQUEIDENTIFIER   NOT NULL,
    [PortalModuleAccessId]      INT                NOT NULL,
    [RowCreatedBy]              VARCHAR (250)      NULL,
    [RowCreatedDateTimeUTC]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          VARCHAR (250)      NULL,
    [RowLastUpdatedDateTimeUTC] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    [HasSelectPermission]       BIT                DEFAULT ((0)) NOT NULL,
    [HasInsertPermission]       BIT                DEFAULT ((0)) NOT NULL,
    [HasUpdatePermission]       BIT                DEFAULT ((0)) NOT NULL,
    [HasDeletePermission]       BIT                DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AspNetRolesSecPortalModuleAccess] PRIMARY KEY CLUSTERED ([RoleId] ASC, [PortalModuleAccessId] ASC),
    CONSTRAINT [FK_AspNetRolesSecPortalModuleAccess_AspNetRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]),
    CONSTRAINT [FK_AspNetRolesSecPortalModuleAccess_PortalModuleAccess] FOREIGN KEY ([PortalModuleAccessId]) REFERENCES [dbo].[SecPortalModuleAccess] ([PortalModuleAccessId])
);

