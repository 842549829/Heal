CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;
DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250506053754_init') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250506053754_init') THEN

    CREATE TABLE `AbpDictType` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
        `ParentId` char(36) COLLATE ascii_general_ci NULL COMMENT '父级Id',
        `ExtraProperties` longtext CHARACTER SET utf8mb4 NOT NULL COMMENT '扩展字段',
        `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 NOT NULL COMMENT '迸发标记',
        `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
        `CreatorId` char(36) COLLATE ascii_general_ci NULL COMMENT '创建人Id',
        `LastModificationTime` datetime(6) NULL COMMENT '最后更新时间',
        `LastModifierId` char(36) COLLATE ascii_general_ci NULL COMMENT '最后更新人',
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE COMMENT '删除标记',
        `DeleterId` char(36) COLLATE ascii_general_ci NULL COMMENT '删除人Id',
        `DeletionTime` datetime(6) NULL COMMENT '删除时间',
        `TenantId` char(36) COLLATE ascii_general_ci NULL COMMENT '租户Id',
        `Name` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '名称',
        `Code` varchar(95) CHARACTER SET utf8mb4 NOT NULL COMMENT '编码',
        `Pinyin` varchar(512) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音',
        `PinyinFirstLetters` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音首字母',
        `Status` int NOT NULL COMMENT '启用状态',
        `Sort` int NOT NULL COMMENT '排序字段',
        `CreatorName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '创建人名称',
        `LastModificationName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '最后修改人名称',
        `DeletionName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '删除人名称',
        `Describe` varchar(512) CHARACTER SET utf8mb4 NULL COMMENT '描述',
        CONSTRAINT `PK_AbpDictType` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4 COMMENT='字典类型';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250506053754_init') THEN

    CREATE TABLE `AbpDictItem` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
        `Style` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '样式',
        `DictTypeId` char(36) COLLATE ascii_general_ci NOT NULL COMMENT '所属类型Id',
        `Key` varchar(95) CHARACTER SET utf8mb4 NOT NULL COMMENT '键',
        `ParentId` char(36) COLLATE ascii_general_ci NULL COMMENT '父级Id',
        `Alias` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '别名',
        `ExtraProperties` longtext CHARACTER SET utf8mb4 NOT NULL COMMENT '扩展字段',
        `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 NOT NULL COMMENT '迸发标记',
        `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
        `CreatorId` char(36) COLLATE ascii_general_ci NULL COMMENT '创建人Id',
        `LastModificationTime` datetime(6) NULL COMMENT '最后更新时间',
        `LastModifierId` char(36) COLLATE ascii_general_ci NULL COMMENT '最后更新人',
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE COMMENT '删除标记',
        `DeleterId` char(36) COLLATE ascii_general_ci NULL COMMENT '删除人Id',
        `DeletionTime` datetime(6) NULL COMMENT '删除时间',
        `TenantId` char(36) COLLATE ascii_general_ci NULL COMMENT '租户Id',
        `Name` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '名称',
        `Code` varchar(95) CHARACTER SET utf8mb4 NOT NULL COMMENT '编码',
        `Pinyin` varchar(512) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音',
        `PinyinFirstLetters` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音首字母',
        `Status` int NOT NULL COMMENT '启用状态',
        `Sort` int NOT NULL COMMENT '排序字段',
        `CreatorName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '创建人名称',
        `LastModificationName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '最后修改人名称',
        `DeletionName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '删除人名称',
        `Describe` varchar(512) CHARACTER SET utf8mb4 NULL COMMENT '描述',
        CONSTRAINT `PK_AbpDictItem` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpDictItem_AbpDictType_DictTypeId` FOREIGN KEY (`DictTypeId`) REFERENCES `AbpDictType` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4 COMMENT='字典项';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250506053754_init') THEN

    CREATE INDEX `IX_AbpDictItem_DictTypeId` ON `AbpDictItem` (`DictTypeId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250506053754_init') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250506053754_init', '9.0.4');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

