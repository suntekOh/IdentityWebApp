CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]                    UNIQUEIDENTIFIER   NOT NULL,
    [LoginProvider]             NVARCHAR (450)     NOT NULL,
    [Name]                      NVARCHAR (450)     NOT NULL,
    [Value]                     NVARCHAR (MAX)     NULL,
    [RowCreatedBy]              NVARCHAR (MAX)     NULL,
    [RowCreatedDateTimeUtc]     DATETIMEOFFSET (7) NULL,
    [RowLastUpdatedBy]          NVARCHAR (MAX)     NULL,
    [RowLastUpdatedDateTimeUtc] DATETIMEOFFSET (7) NULL,
    [RowVersion]                ROWVERSION         NOT NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [Name] ASC),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

