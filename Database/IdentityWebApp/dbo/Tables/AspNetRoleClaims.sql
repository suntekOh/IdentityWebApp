CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]                        INT                IDENTITY (1, 1) NOT NULL,
    [RoleId]                    UNIQUEIDENTIFIER   NOT NULL,
    [ClaimType]                 NVARCHAR (MAX)     NULL,
    [ClaimValue]                NVARCHAR (MAX)     NULL,
    [RowCreatedBy]              NVARCHAR (MAX)     NULL,
    [RowCreatedDateTimeUtc]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          NVARCHAR (MAX)     NULL,
    [RowLastUpdatedDateTimeUtc] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
);

