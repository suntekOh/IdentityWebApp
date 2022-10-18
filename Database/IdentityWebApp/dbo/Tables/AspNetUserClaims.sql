CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]                        INT                IDENTITY (1, 1) NOT NULL,
    [UserId]                    UNIQUEIDENTIFIER   NOT NULL,
    [ClaimType]                 NVARCHAR (MAX)     NULL,
    [ClaimValue]                NVARCHAR (MAX)     NULL,
    [RowCreatedBy]              NVARCHAR (MAX)     NULL,
    [RowCreatedDateTimeUtc]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          NVARCHAR (MAX)     NULL,
    [RowLastUpdatedDateTimeUtc] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

