START TRANSACTION;
DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE TABLE `AbpDoctor` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
        `Education` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '学历',
        `MedicalSchool` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '毕业院校',
        `Major` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '专业',
        `GraduationDate` datetime(6) NULL COMMENT '毕业时间',
        `Avatar` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '头像',
        `PracticeLicenseNumber` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '执业许可证编号',
        `PracticeScope` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '执业范围',
        `PracticeValidityDate` datetime(6) NULL COMMENT '执业有效期',
        `PracticeExperience` varchar(512) CHARACTER SET utf8mb4 NULL COMMENT '执业经历',
        `WorkAgeLimit` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '工作年限',
        `Specialization` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '专长',
        `ResearchResult` varchar(512) CHARACTER SET utf8mb4 NULL COMMENT '科研成果',
        `ProfessionalClassify` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '专业分类',
        `EvaluateClassify` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '评价分类',
        `WorkClassify` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '工作分类',
        `PracticeClassify` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '执业分类',
        `PeculiarityClassify` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '类型(按特质类型分类)',
        `ScopeClassify` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '类型(按范围分类)',
        `OccupationClassify` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '类型(按职业分类)',
        `IsOpenLogin` tinyint(1) NOT NULL COMMENT '是否开放登录',
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
        `Name` varchar(32) CHARACTER SET utf8mb4 NOT NULL COMMENT '名称',
        `Code` varchar(95) CHARACTER SET utf8mb4 NOT NULL COMMENT '编码',
        `Pinyin` varchar(512) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音',
        `PinyinFirstLetters` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音首字母',
        `Status` int NOT NULL COMMENT '启用状态',
        `Sort` int NOT NULL COMMENT '排序字段',
        `CreatorName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '创建人名称',
        `LastModificationName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '最后修改人名称',
        `DeletionName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '删除人名称',
        `Describe` varchar(512) CHARACTER SET utf8mb4 NULL COMMENT '描述',
        `OrganizationId` char(36) COLLATE ascii_general_ci NOT NULL COMMENT '组织Id',
        `OrganizationCode` varchar(95) CHARACTER SET utf8mb4 NOT NULL COMMENT '组织Code',
        `NationCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '国家代码',
        `ProvinceCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '省份代码',
        `CityCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '城市代码',
        `DistrictCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '区县代码',
        `Street` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '街道',
        `AddressLine` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '详细地址',
        `Year` int NOT NULL COMMENT '岁',
        `Month` int NOT NULL COMMENT '月',
        `Day` int NOT NULL COMMENT '天',
        `IdCardType` varchar(16) CHARACTER SET utf8mb4 NOT NULL COMMENT '证件类型',
        `IdCardNo` varchar(32) CHARACTER SET utf8mb4 NOT NULL COMMENT '证件号',
        `Gender` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '性别',
        `Birthday` datetime(6) NOT NULL COMMENT '生日',
        `Phone` varchar(32) CHARACTER SET utf8mb4 NOT NULL COMMENT '手机',
        `Email` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '邮箱',
        CONSTRAINT `PK_AbpDoctor` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4 COMMENT='医生';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE TABLE `AbpPatient` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
        `WorkUnit` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '工作单位',
        `WorkUnitAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '工作单位地址',
        `WorkUnitPhone` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '工作单位电话',
        `EmergencyContact` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '紧急联系人',
        `EmergencyContactPhone` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '紧急联系人电话',
        `EmergencyContactRelationship` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '紧急联系人关系',
        `EmergencyContactAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '紧急联系人地址',
        `Ethnicity` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '民族',
        `PoliticalStatus` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '政治面貌',
        `Nationality` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '国籍',
        `NativePlace` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '籍贯',
        `HealthStatus` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '健康状况',
        `MaritalStatus` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '婚姻状况',
        `BloodType` varchar(8) CHARACTER SET utf8mb4 NULL COMMENT '血型',
        `CurrentAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '现居住地址',
        `HouseholdAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '户籍地址',
        `ResidencePermitAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '居住证地址',
        `ResidencePermitValidity` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '居住证有效期',
        `IdCardValidity` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '身份证有效期',
        `IdCardAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '身份证地址',
        `IdCardFrontPhoto` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '身份证正面照',
        `IdCardBackPhoto` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '身份证反面照',
        `IdCardEmblemPhoto` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '身份证国徽照',
        `IdCardNumber` varchar(18) CHARACTER SET utf8mb4 NULL COMMENT '身份证编号',
        `MedicalCardNumber` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '医保卡号',
        `Source` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '来源',
        `GuardianId` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '监护人ID',
        `GuardianRelationship` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '监护人关系',
        `GuardianPhone` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '监护人电话',
        `GuardianAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '监护人地址',
        `GuardianIdCard` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '监护人身份证号',
        `GuardianIdCardFrontPhoto` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '监护人身份证正面照',
        `GuardianIdCardBackPhoto` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '监护人身份证反面照',
        `GuardianIdCardEmblemPhoto` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '监护人身份证国徽照',
        `GuardianName` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '监护人姓名',
        `GuardianGender` varchar(8) CHARACTER SET utf8mb4 NULL COMMENT '监护人性别',
        `GuardianEthnicity` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '监护人民族',
        `GuardianPoliticalStatus` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '监护人政治面貌',
        `GuardianNationality` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '监护人国籍',
        `GuardianNativePlace` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '监护人籍贯',
        `GuardianHealthStatus` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '监护人健康状况',
        `GuardianMaritalStatus` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '监护人婚姻状况',
        `GuardianBloodType` varchar(8) CHARACTER SET utf8mb4 NULL COMMENT '监护人血型',
        `GuardianCurrentAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '监护人现居住地',
        `GuardianHouseholdAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '监护人户籍地',
        `GuardianResidencePermitAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '监护人居住证地址',
        `GuardianResidencePermitValidity` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '监护人居住证有效期',
        `GuardianIdCardValidity` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '监护人身份证有效期',
        `GuardianIdCardAddress` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '监护人身份证地址',
        `GuardianIdCardFrontPhotoDuplicate` longtext CHARACTER SET utf8mb4 NULL,
        `GuardianIdCardBackPhotoDuplicate` varchar(256) CHARACTER SET utf8mb4 NULL COMMENT '监护人身份证反面照',
        `Alias` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '别名',
        `MedicalRecordNumber` varchar(32) CHARACTER SET utf8mb4 NULL COMMENT '病案号',
        `IsOpenLogin` tinyint(1) NOT NULL COMMENT '是否开通登录功能',
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
        `Name` varchar(32) CHARACTER SET utf8mb4 NOT NULL COMMENT '名称',
        `Code` varchar(95) CHARACTER SET utf8mb4 NOT NULL COMMENT '编码',
        `Pinyin` varchar(512) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音',
        `PinyinFirstLetters` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '拼音首字母',
        `Status` int NOT NULL COMMENT '启用状态',
        `Sort` int NOT NULL COMMENT '排序字段',
        `CreatorName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '创建人名称',
        `LastModificationName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '最后修改人名称',
        `DeletionName` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '删除人名称',
        `Describe` varchar(512) CHARACTER SET utf8mb4 NULL COMMENT '描述',
        `OrganizationId` char(36) COLLATE ascii_general_ci NOT NULL COMMENT '组织Id',
        `OrganizationCode` varchar(95) CHARACTER SET utf8mb4 NOT NULL COMMENT '组织Code',
        `NationCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '国家代码',
        `ProvinceCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '省份代码',
        `CityCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '城市代码',
        `DistrictCode` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '区县代码',
        `Street` varchar(64) CHARACTER SET utf8mb4 NULL COMMENT '街道',
        `AddressLine` varchar(128) CHARACTER SET utf8mb4 NULL COMMENT '详细地址',
        `Year` int NOT NULL COMMENT '岁',
        `Month` int NOT NULL COMMENT '月',
        `Day` int NOT NULL COMMENT '天',
        `IdCardType` varchar(16) CHARACTER SET utf8mb4 NOT NULL COMMENT '证件类型',
        `IdCardNo` varchar(32) CHARACTER SET utf8mb4 NOT NULL COMMENT '证件号',
        `Gender` varchar(16) CHARACTER SET utf8mb4 NULL COMMENT '性别',
        `Birthday` datetime(6) NOT NULL COMMENT '生日',
        `Phone` varchar(32) CHARACTER SET utf8mb4 NOT NULL COMMENT '手机',
        `Email` varchar(64) CHARACTER SET utf8mb4 NOT NULL COMMENT '邮箱',
        CONSTRAINT `PK_AbpPatient` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4 COMMENT='患者';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpDoctor_Code` ON `AbpDoctor` (`Code`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpDoctor_IdCardNo` ON `AbpDoctor` (`IdCardNo`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpDoctor_Name` ON `AbpDoctor` (`Name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpDoctor_Phone` ON `AbpDoctor` (`Phone`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpPatient_Code` ON `AbpPatient` (`Code`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpPatient_IdCardNo` ON `AbpPatient` (`IdCardNo`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpPatient_Name` ON `AbpPatient` (`Name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    CREATE INDEX `IX_AbpPatient_Phone` ON `AbpPatient` (`Phone`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250418013255_init1') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250418013255_init1', '9.0.0');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

