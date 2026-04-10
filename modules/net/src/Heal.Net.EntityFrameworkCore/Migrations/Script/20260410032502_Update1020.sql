BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260410032502_Update1020'
)
BEGIN
    ALTER TABLE [AbpUsers] ADD [Leaved] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260410032502_Update1020'
)
BEGIN
    DECLARE @var nvarchar(max);
    SELECT @var = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AbpEntityPropertyChanges]') AND [c].[name] = N'PropertyTypeFullName');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [AbpEntityPropertyChanges] DROP CONSTRAINT ' + @var + ';');
    ALTER TABLE [AbpEntityPropertyChanges] ALTER COLUMN [PropertyTypeFullName] nvarchar(512) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260410032502_Update1020'
)
BEGIN
    DROP INDEX [IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId] ON [AbpEntityChanges];
    DECLARE @var1 nvarchar(max);
    SELECT @var1 = QUOTENAME([d].[name])
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AbpEntityChanges]') AND [c].[name] = N'EntityTypeFullName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AbpEntityChanges] DROP CONSTRAINT ' + @var1 + ';');
    ALTER TABLE [AbpEntityChanges] ALTER COLUMN [EntityTypeFullName] nvarchar(512) NOT NULL;
    CREATE INDEX [IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId] ON [AbpEntityChanges] ([TenantId], [EntityTypeFullName], [EntityId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260410032502_Update1020'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260410032502_Update1020', N'10.0.5');
END;

COMMIT;
GO

