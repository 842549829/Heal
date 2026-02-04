BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    DROP INDEX [IX_AbpPermissions_Name] ON [AbpPermissions];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    ALTER TABLE [AbpUsers] ADD [LastSignInTime] datetimeoffset NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    DECLARE @var nvarchar(max);
    SELECT @var = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AbpPermissions]') AND [c].[name] = N'GroupName');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [AbpPermissions] DROP CONSTRAINT ' + @var + ';');
    ALTER TABLE [AbpPermissions] ALTER COLUMN [GroupName] nvarchar(128) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    ALTER TABLE [AbpPermissions] ADD [ManagementPermissionName] nvarchar(128) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    ALTER TABLE [AbpPermissions] ADD [ResourceName] nvarchar(256) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    CREATE TABLE [AbpResourcePermissionGrants] (
        [Id] uniqueidentifier NOT NULL,
        [TenantId] uniqueidentifier NULL,
        [Name] nvarchar(128) NOT NULL,
        [ProviderName] nvarchar(64) NOT NULL,
        [ProviderKey] nvarchar(64) NOT NULL,
        [ResourceName] nvarchar(256) NOT NULL,
        [ResourceKey] nvarchar(256) NOT NULL,
        CONSTRAINT [PK_AbpResourcePermissionGrants] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    CREATE TABLE [AbpUserPasskeys] (
        [CredentialId] varbinary(1024) NOT NULL,
        [TenantId] uniqueidentifier NULL,
        [UserId] uniqueidentifier NOT NULL,
        [Data] nvarchar(max) NULL,
        CONSTRAINT [PK_AbpUserPasskeys] PRIMARY KEY ([CredentialId]),
        CONSTRAINT [FK_AbpUserPasskeys_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    CREATE TABLE [AbpUserPasswordHistories] (
        [UserId] uniqueidentifier NOT NULL,
        [Password] nvarchar(256) NOT NULL,
        [TenantId] uniqueidentifier NULL,
        [CreatedAt] datetimeoffset NOT NULL,
        CONSTRAINT [PK_AbpUserPasswordHistories] PRIMARY KEY ([UserId], [Password]),
        CONSTRAINT [FK_AbpUserPasswordHistories_AbpUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AbpUsers] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_AbpPermissions_ResourceName_Name] ON [AbpPermissions] ([ResourceName], [Name]) WHERE [ResourceName] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_AbpResourcePermissionGrants_TenantId_Name_ResourceName_ResourceKey_ProviderName_ProviderKey] ON [AbpResourcePermissionGrants] ([TenantId], [Name], [ResourceName], [ResourceKey], [ProviderName], [ProviderKey]) WHERE [TenantId] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    CREATE INDEX [IX_AbpUserPasskeys_UserId] ON [AbpUserPasskeys] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260204054612_Update1010Rc2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260204054612_Update1010Rc2', N'10.0.2');
END;

COMMIT;
GO

