CREATE TABLE [dbo].[AspNetRoles] (
    [Id]                        UNIQUEIDENTIFIER   NOT NULL,
    [Name]                      NVARCHAR (256)     NULL,
    [NormalizedName]            NVARCHAR (256)     NULL,
    [ConcurrencyStamp]          NVARCHAR (MAX)     NULL,
    [RowCreatedBy]              NVARCHAR (MAX)     NULL,
    [RowCreatedDateTimeUtc]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          NVARCHAR (MAX)     NULL,
    [RowLastUpdatedDateTimeUtc] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

