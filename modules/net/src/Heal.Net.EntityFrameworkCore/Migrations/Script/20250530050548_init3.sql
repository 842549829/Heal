START TRANSACTION;
DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250530050548_init3') THEN

    CREATE TABLE `AbpUserCampus` (
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
        `CampusId` char(36) COLLATE ascii_general_ci NOT NULL COMMENT '院区Id',
        `TenantId` char(36) COLLATE ascii_general_ci NULL COMMENT '租户Id',
        `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
        `CreatorId` char(36) COLLATE ascii_general_ci NULL COMMENT '创建人Id',
        CONSTRAINT `PK_AbpUserCampus` PRIMARY KEY (`UserId`, `CampusId`)
    ) CHARACTER SET=utf8mb4 COMMENT='用户院区';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250530050548_init3') THEN

    CREATE TABLE `AbpUserDepartment` (
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
        `DepartmentId` char(36) COLLATE ascii_general_ci NOT NULL COMMENT '科室Id',
        `TenantId` char(36) COLLATE ascii_general_ci NULL COMMENT '租户Id',
        `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
        `CreatorId` char(36) COLLATE ascii_general_ci NULL COMMENT '创建人Id',
        CONSTRAINT `PK_AbpUserDepartment` PRIMARY KEY (`UserId`, `DepartmentId`)
    ) CHARACTER SET=utf8mb4 COMMENT='用户科室';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250530050548_init3') THEN

    CREATE INDEX `IX_AbpDepartment_CampusId` ON `AbpDepartment` (`CampusId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250530050548_init3') THEN

    CREATE INDEX `IX_AbpCampus_OrganizationId` ON `AbpCampus` (`OrganizationId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250530050548_init3') THEN

    ALTER TABLE `AbpCampus` ADD CONSTRAINT `FK_AbpCampus_AbpOrganizationUnits_OrganizationId` FOREIGN KEY (`OrganizationId`) REFERENCES `AbpOrganizationUnits` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250530050548_init3') THEN

    ALTER TABLE `AbpDepartment` ADD CONSTRAINT `FK_AbpDepartment_AbpCampus_CampusId` FOREIGN KEY (`CampusId`) REFERENCES `AbpCampus` (`Id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250530050548_init3') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250530050548_init3', '9.0.4');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

