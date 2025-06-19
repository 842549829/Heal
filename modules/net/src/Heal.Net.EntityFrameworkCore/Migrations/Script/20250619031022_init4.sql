START TRANSACTION;
DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250619031022_init4') THEN

    CREATE TABLE `AbpAuditLogExcelFiles` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `TenantId` char(36) COLLATE ascii_general_ci NULL,
        `FileName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) COLLATE ascii_general_ci NULL,
        CONSTRAINT `PK_AbpAuditLogExcelFiles` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250619031022_init4') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250619031022_init4', '9.0.6');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

