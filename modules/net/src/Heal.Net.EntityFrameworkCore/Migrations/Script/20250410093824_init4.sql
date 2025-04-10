START TRANSACTION;
DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250410093824_init4') THEN

    CREATE TABLE `AbpCampus` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ShortName` varchar(32) CHARACTER SET utf8mb4 NULL,
        `Building` varchar(64) CHARACTER SET utf8mb4 NULL,
        `Floor` varchar(16) CHARACTER SET utf8mb4 NULL,
        `RoomNumber` varchar(16) CHARACTER SET utf8mb4 NULL,
        `Address` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Capacity` int NOT NULL,
        `Phone` varchar(32) CHARACTER SET utf8mb4 NULL,
        `Email` varchar(128) CHARACTER SET utf8mb4 NULL,
        `HeadOfCampus` varchar(64) CHARACTER SET utf8mb4 NULL,
        `HeadOfCampusPhone` varchar(32) CHARACTER SET utf8mb4 NULL,
        `HeadOfCampusEmail` varchar(128) CHARACTER SET utf8mb4 NULL,
        `Website` varchar(256) CHARACTER SET utf8mb4 NULL,
        `ServicesOffered` varchar(512) CHARACTER SET utf8mb4 NULL,
        `EmergencyContact` varchar(64) CHARACTER SET utf8mb4 NULL,
        `EmergencyPhone` varchar(32) CHARACTER SET utf8mb4 NULL,
        `ExtraProperties` longtext CHARACTER SET utf8mb4 NOT NULL,
        `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) COLLATE ascii_general_ci NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) COLLATE ascii_general_ci NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) COLLATE ascii_general_ci NULL,
        `DeletionTime` datetime(6) NULL,
        `TenantId` char(36) COLLATE ascii_general_ci NULL,
        `Name` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
        `Code` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Pinyin` varchar(512) CHARACTER SET utf8mb4 NOT NULL,
        `PinyinFirstLetters` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
        `Status` int NOT NULL,
        `Sort` int NOT NULL,
        `CreatorName` varchar(64) CHARACTER SET utf8mb4 NULL,
        `LastModificationName` varchar(64) CHARACTER SET utf8mb4 NULL,
        `DeletionName` varchar(64) CHARACTER SET utf8mb4 NULL,
        `Describe` varchar(512) CHARACTER SET utf8mb4 NULL,
        `OrganizationId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_AbpCampus` PRIMARY KEY (`Id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250410093824_init4') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250410093824_init4', '9.0.0');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

