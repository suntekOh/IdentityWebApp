CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]             NVARCHAR (450)     NOT NULL,
    [ProviderKey]               NVARCHAR (450)     NOT NULL,
    [ProviderDisplayName]       NVARCHAR (MAX)     NULL,
    [UserId]                    UNIQUEIDENTIFIER   NOT NULL,
    [RowCreatedBy]              NVARCHAR (MAX)     NULL,
    [RowCreatedDateTimeUtc]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          NVARCHAR (MAX)     NULL,
    [RowLastUpdatedDateTimeUtc] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

