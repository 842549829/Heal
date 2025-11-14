CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpAuditLogExcelFiles` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `FileName` varchar(256) NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpAuditLogs` (
        `Id` char(36) NOT NULL,
        `ApplicationName` varchar(96) NULL,
        `UserId` char(36) NULL,
        `UserName` varchar(256) NULL,
        `TenantId` char(36) NULL,
        `TenantName` varchar(64) NULL,
        `ImpersonatorUserId` char(36) NULL,
        `ImpersonatorUserName` varchar(256) NULL,
        `ImpersonatorTenantId` char(36) NULL,
        `ImpersonatorTenantName` varchar(64) NULL,
        `ExecutionTime` datetime(6) NOT NULL,
        `ExecutionDuration` int NOT NULL,
        `ClientIpAddress` varchar(64) NULL,
        `ClientName` varchar(128) NULL,
        `ClientId` varchar(64) NULL,
        `CorrelationId` varchar(64) NULL,
        `BrowserInfo` varchar(512) NULL,
        `HttpMethod` varchar(16) NULL,
        `Url` varchar(256) NULL,
        `Exceptions` longtext NULL,
        `Comments` varchar(256) NULL,
        `HttpStatusCode` int NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpBackgroundJobs` (
        `Id` char(36) NOT NULL,
        `ApplicationName` varchar(96) NULL,
        `JobName` varchar(128) NOT NULL,
        `JobArgs` longtext NOT NULL,
        `TryCount` smallint NOT NULL DEFAULT 0,
        `CreationTime` datetime(6) NOT NULL,
        `NextTryTime` datetime(6) NOT NULL,
        `LastTryTime` datetime(6) NULL,
        `IsAbandoned` tinyint(1) NOT NULL DEFAULT FALSE,
        `Priority` tinyint unsigned NOT NULL DEFAULT 15,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpBlobContainers` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(128) NOT NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpClaimTypes` (
        `Id` char(36) NOT NULL,
        `Name` varchar(256) NOT NULL,
        `Required` tinyint(1) NOT NULL,
        `IsStatic` tinyint(1) NOT NULL,
        `Regex` varchar(512) NULL,
        `RegexDescription` varchar(128) NULL,
        `Description` varchar(256) NULL,
        `ValueType` int NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpDoctor` (
        `Id` char(36) NOT NULL,
        `Education` varchar(16) NULL,
        `MedicalSchool` varchar(64) NULL,
        `Major` varchar(64) NULL,
        `GraduationDate` datetime(6) NULL,
        `Avatar` varchar(256) NULL,
        `PracticeLicenseNumber` varchar(32) NULL,
        `PracticeScope` varchar(128) NULL,
        `PracticeValidityDate` datetime(6) NULL,
        `PracticeExperience` varchar(512) NULL,
        `WorkAgeLimit` varchar(16) NULL,
        `Specialization` varchar(128) NULL,
        `ResearchResult` varchar(512) NULL,
        `ProfessionalClassify` varchar(64) NULL,
        `EvaluateClassify` varchar(64) NULL,
        `WorkClassify` varchar(64) NULL,
        `PracticeClassify` varchar(64) NULL,
        `PeculiarityClassify` varchar(64) NULL,
        `ScopeClassify` varchar(64) NULL,
        `OccupationClassify` varchar(64) NULL,
        `IsOpenLogin` tinyint(1) NOT NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(32) NOT NULL,
        `Code` varchar(95) NOT NULL,
        `Pinyin` varchar(512) NOT NULL,
        `PinyinFirstLetters` varchar(64) NOT NULL,
        `Status` int NOT NULL,
        `Sort` int NOT NULL,
        `CreatorName` varchar(64) NULL,
        `LastModificationName` varchar(64) NULL,
        `DeletionName` varchar(64) NULL,
        `Describe` varchar(512) NULL,
        `OrganizationId` char(36) NOT NULL,
        `OrganizationCode` varchar(95) NOT NULL,
        `NationCode` varchar(16) NULL,
        `ProvinceCode` varchar(16) NULL,
        `CityCode` varchar(16) NULL,
        `DistrictCode` varchar(16) NULL,
        `Street` varchar(64) NULL,
        `AddressLine` varchar(128) NULL,
        `Year` int NOT NULL,
        `Month` int NOT NULL,
        `Day` int NOT NULL,
        `IdCardType` varchar(16) NOT NULL,
        `IdCardNo` varchar(32) NOT NULL,
        `Gender` varchar(16) NULL,
        `Birthday` datetime(6) NOT NULL,
        `Phone` varchar(32) NOT NULL,
        `Email` varchar(64) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpFeatureGroups` (
        `Id` char(36) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `DisplayName` varchar(256) NOT NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpFeatures` (
        `Id` char(36) NOT NULL,
        `GroupName` varchar(128) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `ParentName` varchar(128) NULL,
        `DisplayName` varchar(256) NOT NULL,
        `Description` varchar(256) NULL,
        `DefaultValue` varchar(256) NULL,
        `IsVisibleToClients` tinyint(1) NOT NULL,
        `IsAvailableToHost` tinyint(1) NOT NULL,
        `AllowedProviders` varchar(256) NULL,
        `ValueType` varchar(2048) NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpFeatureValues` (
        `Id` char(36) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `Value` varchar(128) NOT NULL,
        `ProviderName` varchar(64) NULL,
        `ProviderKey` varchar(64) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpLinkUsers` (
        `Id` char(36) NOT NULL,
        `SourceUserId` char(36) NOT NULL,
        `SourceTenantId` char(36) NULL,
        `TargetUserId` char(36) NOT NULL,
        `TargetTenantId` char(36) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpOrganizationUnits` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `ParentId` char(36) NULL,
        `Code` varchar(95) NOT NULL,
        `DisplayName` varchar(128) NOT NULL,
        `EntityVersion` int NOT NULL,
        `Address` varchar(256) NULL,
        `CoverImage` varchar(1024) NULL,
        `Describe` varchar(512) NULL,
        `Director` varchar(64) NULL,
        `Email` varchar(64) NULL,
        `EstablishmentDate` datetime(6) NULL,
        `Facilities` varchar(1024) NULL,
        `Introduction` varchar(4096) NULL,
        `IsEmergencyServices` tinyint(1) NULL,
        `IsInsuranceAccepted` tinyint(1) NULL,
        `Latitude` decimal(18,2) NULL,
        `Level` int NULL,
        `Longitude` decimal(18,2) NULL,
        `OperatingHours` datetime(6) NULL,
        `ParkingInformation` varchar(512) NULL,
        `Phone` varchar(32) NULL,
        `PostalCode` varchar(16) NULL,
        `ServiceHotline` varchar(32) NULL,
        `TrafficGuide` varchar(512) NULL,
        `WebsiteUrl` varchar(128) NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `AbpOrganizationUnits` (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpPatient` (
        `Id` char(36) NOT NULL,
        `WorkUnit` varchar(64) NULL,
        `WorkUnitAddress` varchar(128) NULL,
        `WorkUnitPhone` varchar(16) NULL,
        `EmergencyContact` varchar(32) NULL,
        `EmergencyContactPhone` varchar(16) NULL,
        `EmergencyContactRelationship` varchar(16) NULL,
        `EmergencyContactAddress` varchar(128) NULL,
        `Ethnicity` varchar(16) NULL,
        `PoliticalStatus` varchar(16) NULL,
        `Nationality` varchar(32) NULL,
        `NativePlace` varchar(64) NULL,
        `HealthStatus` varchar(16) NULL,
        `MaritalStatus` varchar(16) NULL,
        `BloodType` varchar(8) NULL,
        `CurrentAddress` varchar(128) NULL,
        `HouseholdAddress` varchar(128) NULL,
        `ResidencePermitAddress` varchar(128) NULL,
        `ResidencePermitValidity` varchar(32) NULL,
        `IdCardValidity` varchar(32) NULL,
        `IdCardAddress` varchar(128) NULL,
        `IdCardFrontPhoto` varchar(256) NULL,
        `IdCardBackPhoto` varchar(256) NULL,
        `IdCardEmblemPhoto` varchar(256) NULL,
        `IdCardNumber` varchar(18) NULL,
        `MedicalCardNumber` varchar(32) NULL,
        `Source` varchar(16) NULL,
        `GuardianId` varchar(32) NULL,
        `GuardianRelationship` varchar(16) NULL,
        `GuardianPhone` varchar(32) NULL,
        `GuardianAddress` varchar(128) NULL,
        `GuardianIdCard` varchar(32) NULL,
        `GuardianIdCardFrontPhoto` varchar(256) NULL,
        `GuardianIdCardBackPhoto` varchar(256) NULL,
        `GuardianIdCardEmblemPhoto` varchar(256) NULL,
        `GuardianName` varchar(32) NULL,
        `GuardianGender` varchar(8) NULL,
        `GuardianEthnicity` varchar(16) NULL,
        `GuardianPoliticalStatus` varchar(16) NULL,
        `GuardianNationality` varchar(32) NULL,
        `GuardianNativePlace` varchar(64) NULL,
        `GuardianHealthStatus` varchar(16) NULL,
        `GuardianMaritalStatus` varchar(16) NULL,
        `GuardianBloodType` varchar(8) NULL,
        `GuardianCurrentAddress` varchar(128) NULL,
        `GuardianHouseholdAddress` varchar(128) NULL,
        `GuardianResidencePermitAddress` varchar(128) NULL,
        `GuardianResidencePermitValidity` varchar(32) NULL,
        `GuardianIdCardValidity` varchar(32) NULL,
        `GuardianIdCardAddress` varchar(128) NULL,
        `GuardianIdCardFrontPhotoDuplicate` longtext NULL,
        `GuardianIdCardBackPhotoDuplicate` varchar(256) NULL,
        `Alias` varchar(64) NULL,
        `MedicalRecordNumber` varchar(32) NULL,
        `IsOpenLogin` tinyint(1) NOT NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(32) NOT NULL,
        `Code` varchar(95) NOT NULL,
        `Pinyin` varchar(512) NOT NULL,
        `PinyinFirstLetters` varchar(64) NOT NULL,
        `Status` int NOT NULL,
        `Sort` int NOT NULL,
        `CreatorName` varchar(64) NULL,
        `LastModificationName` varchar(64) NULL,
        `DeletionName` varchar(64) NULL,
        `Describe` varchar(512) NULL,
        `OrganizationId` char(36) NOT NULL,
        `OrganizationCode` varchar(95) NOT NULL,
        `NationCode` varchar(16) NULL,
        `ProvinceCode` varchar(16) NULL,
        `CityCode` varchar(16) NULL,
        `DistrictCode` varchar(16) NULL,
        `Street` varchar(64) NULL,
        `AddressLine` varchar(128) NULL,
        `Year` int NOT NULL,
        `Month` int NOT NULL,
        `Day` int NOT NULL,
        `IdCardType` varchar(16) NOT NULL,
        `IdCardNo` varchar(32) NOT NULL,
        `Gender` varchar(16) NULL,
        `Birthday` datetime(6) NOT NULL,
        `Phone` varchar(32) NOT NULL,
        `Email` varchar(64) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpPermissionGrants` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(128) NOT NULL,
        `ProviderName` varchar(64) NOT NULL,
        `ProviderKey` varchar(64) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpPermissionGroups` (
        `Id` char(36) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `DisplayName` varchar(256) NOT NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpPermissions` (
        `Id` char(36) NOT NULL,
        `GroupName` varchar(128) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `ParentName` varchar(128) NULL,
        `DisplayName` varchar(256) NOT NULL,
        `IsEnabled` tinyint(1) NOT NULL,
        `MultiTenancySide` tinyint unsigned NOT NULL,
        `Providers` varchar(128) NULL,
        `StateCheckers` varchar(256) NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpRoles` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(256) NOT NULL,
        `NormalizedName` varchar(256) NOT NULL,
        `IsDefault` tinyint(1) NOT NULL,
        `IsStatic` tinyint(1) NOT NULL,
        `IsPublic` tinyint(1) NOT NULL,
        `EntityVersion` int NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CustomDataPermission` varchar(4096) NOT NULL DEFAULT '',
        `DataPermission` int NOT NULL DEFAULT 0,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpSecurityLogs` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `ApplicationName` varchar(96) NULL,
        `Identity` varchar(96) NULL,
        `Action` varchar(96) NULL,
        `UserId` char(36) NULL,
        `UserName` varchar(256) NULL,
        `TenantName` varchar(64) NULL,
        `ClientId` varchar(64) NULL,
        `CorrelationId` varchar(64) NULL,
        `ClientIpAddress` varchar(64) NULL,
        `BrowserInfo` varchar(512) NULL,
        `CreationTime` datetime(6) NOT NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpSessions` (
        `Id` char(36) NOT NULL,
        `SessionId` varchar(128) NOT NULL,
        `Device` varchar(64) NOT NULL,
        `DeviceInfo` varchar(256) NULL,
        `TenantId` char(36) NULL,
        `UserId` char(36) NOT NULL,
        `ClientId` varchar(64) NULL,
        `IpAddresses` varchar(2048) NULL,
        `SignedIn` datetime(6) NOT NULL,
        `LastAccessed` datetime(6) NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpSettingDefinitions` (
        `Id` char(36) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `DisplayName` varchar(256) NOT NULL,
        `Description` varchar(512) NULL,
        `DefaultValue` varchar(2048) NULL,
        `IsVisibleToClients` tinyint(1) NOT NULL,
        `Providers` varchar(1024) NULL,
        `IsInherited` tinyint(1) NOT NULL,
        `IsEncrypted` tinyint(1) NOT NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpSettings` (
        `Id` char(36) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `Value` varchar(2048) NOT NULL,
        `ProviderName` varchar(64) NULL,
        `ProviderKey` varchar(64) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpTenants` (
        `Id` char(36) NOT NULL,
        `Name` varchar(64) NOT NULL,
        `NormalizedName` varchar(64) NOT NULL,
        `EntityVersion` int NOT NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserCampus` (
        `UserId` char(36) NOT NULL,
        `CampusId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        PRIMARY KEY (`UserId`, `CampusId`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserDelegations` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `SourceUserId` char(36) NOT NULL,
        `TargetUserId` char(36) NOT NULL,
        `StartTime` datetime(6) NOT NULL,
        `EndTime` datetime(6) NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserDepartment` (
        `UserId` char(36) NOT NULL,
        `DepartmentId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        PRIMARY KEY (`UserId`, `DepartmentId`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUsers` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `UserName` varchar(256) NOT NULL,
        `NormalizedUserName` varchar(256) NOT NULL,
        `Name` varchar(64) NULL,
        `Surname` varchar(64) NULL,
        `Email` varchar(256) NOT NULL,
        `NormalizedEmail` varchar(256) NOT NULL,
        `EmailConfirmed` tinyint(1) NOT NULL DEFAULT FALSE,
        `PasswordHash` varchar(256) NULL,
        `SecurityStamp` varchar(256) NOT NULL,
        `IsExternal` tinyint(1) NOT NULL DEFAULT FALSE,
        `PhoneNumber` varchar(16) NULL,
        `PhoneNumberConfirmed` tinyint(1) NOT NULL DEFAULT FALSE,
        `IsActive` tinyint(1) NOT NULL,
        `TwoFactorEnabled` tinyint(1) NOT NULL DEFAULT FALSE,
        `LockoutEnd` datetime NULL,
        `LockoutEnabled` tinyint(1) NOT NULL DEFAULT FALSE,
        `AccessFailedCount` int NOT NULL DEFAULT 0,
        `ShouldChangePasswordOnNextLogin` tinyint(1) NOT NULL,
        `EntityVersion` int NOT NULL,
        `LastPasswordChangeTime` datetime NULL,
        `Avatar` varchar(512) NOT NULL DEFAULT '',
        `Identity` int NOT NULL DEFAULT 1,
        `OpenId` varchar(256) NOT NULL DEFAULT '',
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `OpenIddictApplications` (
        `Id` char(36) NOT NULL,
        `ApplicationType` varchar(50) NULL,
        `ClientId` varchar(100) NULL,
        `ClientSecret` longtext NULL,
        `ClientType` varchar(50) NULL,
        `ConsentType` varchar(50) NULL,
        `DisplayName` longtext NULL,
        `DisplayNames` longtext NULL,
        `JsonWebKeySet` longtext NULL,
        `Permissions` longtext NULL,
        `PostLogoutRedirectUris` longtext NULL,
        `Properties` longtext NULL,
        `RedirectUris` longtext NULL,
        `Requirements` longtext NULL,
        `Settings` longtext NULL,
        `FrontChannelLogoutUri` longtext NULL,
        `ClientUri` longtext NULL,
        `LogoUri` longtext NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `OpenIddictScopes` (
        `Id` char(36) NOT NULL,
        `Description` longtext NULL,
        `Descriptions` longtext NULL,
        `DisplayName` longtext NULL,
        `DisplayNames` longtext NULL,
        `Name` varchar(200) NULL,
        `Properties` longtext NULL,
        `Resources` longtext NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpAuditLogActions` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `AuditLogId` char(36) NOT NULL,
        `ServiceName` varchar(256) NULL,
        `MethodName` varchar(128) NULL,
        `Parameters` varchar(2000) NULL,
        `ExecutionTime` datetime(6) NOT NULL,
        `ExecutionDuration` int NOT NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId` FOREIGN KEY (`AuditLogId`) REFERENCES `AbpAuditLogs` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpEntityChanges` (
        `Id` char(36) NOT NULL,
        `AuditLogId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `ChangeTime` datetime(6) NOT NULL,
        `ChangeType` tinyint unsigned NOT NULL,
        `EntityTenantId` char(36) NULL,
        `EntityId` varchar(128) NULL,
        `EntityTypeFullName` varchar(128) NOT NULL,
        `ExtraProperties` longtext NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpEntityChanges_AbpAuditLogs_AuditLogId` FOREIGN KEY (`AuditLogId`) REFERENCES `AbpAuditLogs` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpBlobs` (
        `Id` char(36) NOT NULL,
        `ContainerId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(256) NOT NULL,
        `Content` longblob NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpBlobs_AbpBlobContainers_ContainerId` FOREIGN KEY (`ContainerId`) REFERENCES `AbpBlobContainers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpCampus` (
        `Id` char(36) NOT NULL,
        `ShortName` varchar(32) NULL,
        `Building` varchar(64) NULL,
        `Floor` varchar(16) NULL,
        `RoomNumber` varchar(16) NULL,
        `Address` varchar(256) NULL,
        `Capacity` int NOT NULL,
        `Phone` varchar(32) NULL,
        `Email` varchar(128) NULL,
        `HeadOfCampus` varchar(64) NULL,
        `HeadOfCampusPhone` varchar(32) NULL,
        `HeadOfCampusEmail` varchar(128) NULL,
        `Website` varchar(256) NULL,
        `ServicesOffered` varchar(512) NULL,
        `EmergencyContact` varchar(64) NULL,
        `EmergencyPhone` varchar(32) NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(64) NOT NULL,
        `Code` varchar(95) NOT NULL,
        `Pinyin` varchar(512) NOT NULL,
        `PinyinFirstLetters` varchar(64) NOT NULL,
        `Status` int NOT NULL,
        `Sort` int NOT NULL,
        `CreatorName` varchar(64) NULL,
        `LastModificationName` varchar(64) NULL,
        `DeletionName` varchar(64) NULL,
        `Describe` varchar(512) NULL,
        `OrganizationId` char(36) NOT NULL,
        `OrganizationCode` varchar(95) NOT NULL,
        `ParentId` char(36) NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpCampus_AbpOrganizationUnits_OrganizationId` FOREIGN KEY (`OrganizationId`) REFERENCES `AbpOrganizationUnits` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpOrganizationUnitRoles` (
        `RoleId` char(36) NOT NULL,
        `OrganizationUnitId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        PRIMARY KEY (`OrganizationUnitId`, `RoleId`),
        CONSTRAINT `FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUn~` FOREIGN KEY (`OrganizationUnitId`) REFERENCES `AbpOrganizationUnits` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AbpOrganizationUnitRoles_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AbpRoles` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpRoleClaims` (
        `Id` char(36) NOT NULL,
        `RoleId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `ClaimType` varchar(256) NOT NULL,
        `ClaimValue` varchar(1024) NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpRoleClaims_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AbpRoles` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpTenantConnectionStrings` (
        `TenantId` char(36) NOT NULL,
        `Name` varchar(64) NOT NULL,
        `Value` varchar(1024) NOT NULL,
        PRIMARY KEY (`TenantId`, `Name`),
        CONSTRAINT `FK_AbpTenantConnectionStrings_AbpTenants_TenantId` FOREIGN KEY (`TenantId`) REFERENCES `AbpTenants` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserClaims` (
        `Id` char(36) NOT NULL,
        `UserId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `ClaimType` varchar(256) NOT NULL,
        `ClaimValue` varchar(1024) NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpUserClaims_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserLogins` (
        `UserId` char(36) NOT NULL,
        `LoginProvider` varchar(64) NOT NULL,
        `TenantId` char(36) NULL,
        `ProviderKey` varchar(196) NOT NULL,
        `ProviderDisplayName` varchar(128) NULL,
        PRIMARY KEY (`UserId`, `LoginProvider`),
        CONSTRAINT `FK_AbpUserLogins_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserOrganizationUnits` (
        `UserId` char(36) NOT NULL,
        `OrganizationUnitId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        PRIMARY KEY (`OrganizationUnitId`, `UserId`),
        CONSTRAINT `FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUn~` FOREIGN KEY (`OrganizationUnitId`) REFERENCES `AbpOrganizationUnits` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AbpUserOrganizationUnits_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserRoles` (
        `UserId` char(36) NOT NULL,
        `RoleId` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        PRIMARY KEY (`UserId`, `RoleId`),
        CONSTRAINT `FK_AbpUserRoles_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AbpRoles` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AbpUserRoles_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpUserTokens` (
        `UserId` char(36) NOT NULL,
        `LoginProvider` varchar(64) NOT NULL,
        `Name` varchar(128) NOT NULL,
        `TenantId` char(36) NULL,
        `Value` longtext NULL,
        PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
        CONSTRAINT `FK_AbpUserTokens_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `OpenIddictAuthorizations` (
        `Id` char(36) NOT NULL,
        `ApplicationId` char(36) NULL,
        `CreationDate` datetime(6) NULL,
        `Properties` longtext NULL,
        `Scopes` longtext NULL,
        `Status` varchar(50) NULL,
        `Subject` varchar(400) NULL,
        `Type` varchar(50) NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `OpenIddictApplications` (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpEntityPropertyChanges` (
        `Id` char(36) NOT NULL,
        `TenantId` char(36) NULL,
        `EntityChangeId` char(36) NOT NULL,
        `NewValue` varchar(512) NULL,
        `OriginalValue` varchar(512) NULL,
        `PropertyName` varchar(128) NOT NULL,
        `PropertyTypeFullName` varchar(64) NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId` FOREIGN KEY (`EntityChangeId`) REFERENCES `AbpEntityChanges` (`Id`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `AbpDepartment` (
        `Id` char(36) NOT NULL,
        `CampusId` char(36) NULL,
        `ShortName` varchar(32) NULL,
        `DepartmentTypeId` char(36) NOT NULL,
        `Campuses` longtext NULL,
        `Building` varchar(64) NULL,
        `Floor` varchar(16) NULL,
        `RoomNumber` varchar(16) NULL,
        `Address` varchar(256) NULL,
        `Capacity` int NOT NULL,
        `Phone` varchar(32) NULL,
        `Email` varchar(128) NULL,
        `HeadOfDepartment` varchar(64) NULL,
        `HeadOfDepartmentPhone` varchar(32) NULL,
        `HeadOfDepartmentEmail` varchar(128) NULL,
        `Website` varchar(256) NULL,
        `ServicesOffered` varchar(512) NULL,
        `EmergencyContact` varchar(64) NULL,
        `EmergencyPhone` varchar(32) NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        `CreationTime` datetime(6) NOT NULL,
        `CreatorId` char(36) NULL,
        `LastModificationTime` datetime(6) NULL,
        `LastModifierId` char(36) NULL,
        `IsDeleted` tinyint(1) NOT NULL DEFAULT FALSE,
        `DeleterId` char(36) NULL,
        `DeletionTime` datetime(6) NULL,
        `TenantId` char(36) NULL,
        `Name` varchar(64) NOT NULL,
        `Code` varchar(95) NOT NULL,
        `Pinyin` varchar(512) NOT NULL,
        `PinyinFirstLetters` varchar(64) NOT NULL,
        `Status` int NOT NULL,
        `Sort` int NOT NULL,
        `CreatorName` varchar(64) NULL,
        `LastModificationName` varchar(64) NULL,
        `DeletionName` varchar(64) NULL,
        `Describe` varchar(512) NULL,
        `OrganizationId` char(36) NOT NULL,
        `OrganizationCode` varchar(95) NOT NULL,
        `ParentId` char(36) NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AbpDepartment_AbpCampus_CampusId` FOREIGN KEY (`CampusId`) REFERENCES `AbpCampus` (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE TABLE `OpenIddictTokens` (
        `Id` char(36) NOT NULL,
        `ApplicationId` char(36) NULL,
        `AuthorizationId` char(36) NULL,
        `CreationDate` datetime(6) NULL,
        `ExpirationDate` datetime(6) NULL,
        `Payload` longtext NULL,
        `Properties` longtext NULL,
        `RedemptionDate` datetime(6) NULL,
        `ReferenceId` varchar(100) NULL,
        `Status` varchar(50) NULL,
        `Subject` varchar(400) NULL,
        `Type` varchar(150) NULL,
        `ExtraProperties` longtext NOT NULL,
        `ConcurrencyStamp` varchar(40) NOT NULL,
        PRIMARY KEY (`Id`),
        CONSTRAINT `FK_OpenIddictTokens_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `OpenIddictApplications` (`Id`),
        CONSTRAINT `FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId` FOREIGN KEY (`AuthorizationId`) REFERENCES `OpenIddictAuthorizations` (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpAuditLogActions_AuditLogId` ON `AbpAuditLogActions` (`AuditLogId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_Execution~` ON `AbpAuditLogActions` (`TenantId`, `ServiceName`, `MethodName`, `ExecutionTime`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpAuditLogs_TenantId_ExecutionTime` ON `AbpAuditLogs` (`TenantId`, `ExecutionTime`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpAuditLogs_TenantId_UserId_ExecutionTime` ON `AbpAuditLogs` (`TenantId`, `UserId`, `ExecutionTime`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpBackgroundJobs_IsAbandoned_NextTryTime` ON `AbpBackgroundJobs` (`IsAbandoned`, `NextTryTime`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpBlobContainers_TenantId_Name` ON `AbpBlobContainers` (`TenantId`, `Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpBlobs_ContainerId` ON `AbpBlobs` (`ContainerId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpBlobs_TenantId_ContainerId_Name` ON `AbpBlobs` (`TenantId`, `ContainerId`, `Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpCampus_OrganizationId` ON `AbpCampus` (`OrganizationId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpDepartment_CampusId` ON `AbpDepartment` (`CampusId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpDoctor_Code` ON `AbpDoctor` (`Code`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpDoctor_IdCardNo` ON `AbpDoctor` (`IdCardNo`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpDoctor_Name` ON `AbpDoctor` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpDoctor_Phone` ON `AbpDoctor` (`Phone`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpEntityChanges_AuditLogId` ON `AbpEntityChanges` (`AuditLogId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId` ON `AbpEntityChanges` (`TenantId`, `EntityTypeFullName`, `EntityId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpEntityPropertyChanges_EntityChangeId` ON `AbpEntityPropertyChanges` (`EntityChangeId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpFeatureGroups_Name` ON `AbpFeatureGroups` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpFeatures_GroupName` ON `AbpFeatures` (`GroupName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpFeatures_Name` ON `AbpFeatures` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpFeatureValues_Name_ProviderName_ProviderKey` ON `AbpFeatureValues` (`Name`, `ProviderName`, `ProviderKey`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpLinkUsers_SourceUserId_SourceTenantId_TargetUserId_Target~` ON `AbpLinkUsers` (`SourceUserId`, `SourceTenantId`, `TargetUserId`, `TargetTenantId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId` ON `AbpOrganizationUnitRoles` (`RoleId`, `OrganizationUnitId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpOrganizationUnits_Code` ON `AbpOrganizationUnits` (`Code`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpOrganizationUnits_ParentId` ON `AbpOrganizationUnits` (`ParentId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpPatient_Code` ON `AbpPatient` (`Code`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpPatient_IdCardNo` ON `AbpPatient` (`IdCardNo`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpPatient_Name` ON `AbpPatient` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpPatient_Phone` ON `AbpPatient` (`Phone`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpPermissionGrants_TenantId_Name_ProviderName_ProviderKey` ON `AbpPermissionGrants` (`TenantId`, `Name`, `ProviderName`, `ProviderKey`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpPermissionGroups_Name` ON `AbpPermissionGroups` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpPermissions_GroupName` ON `AbpPermissions` (`GroupName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpPermissions_Name` ON `AbpPermissions` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpRoleClaims_RoleId` ON `AbpRoleClaims` (`RoleId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpRoles_NormalizedName` ON `AbpRoles` (`NormalizedName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpSecurityLogs_TenantId_Action` ON `AbpSecurityLogs` (`TenantId`, `Action`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpSecurityLogs_TenantId_ApplicationName` ON `AbpSecurityLogs` (`TenantId`, `ApplicationName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpSecurityLogs_TenantId_Identity` ON `AbpSecurityLogs` (`TenantId`, `Identity`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpSecurityLogs_TenantId_UserId` ON `AbpSecurityLogs` (`TenantId`, `UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpSessions_Device` ON `AbpSessions` (`Device`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpSessions_SessionId` ON `AbpSessions` (`SessionId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpSessions_TenantId_UserId` ON `AbpSessions` (`TenantId`, `UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpSettingDefinitions_Name` ON `AbpSettingDefinitions` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE UNIQUE INDEX `IX_AbpSettings_Name_ProviderName_ProviderKey` ON `AbpSettings` (`Name`, `ProviderName`, `ProviderKey`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpTenants_Name` ON `AbpTenants` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpTenants_NormalizedName` ON `AbpTenants` (`NormalizedName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUserClaims_UserId` ON `AbpUserClaims` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUserLogins_LoginProvider_ProviderKey` ON `AbpUserLogins` (`LoginProvider`, `ProviderKey`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId` ON `AbpUserOrganizationUnits` (`UserId`, `OrganizationUnitId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUserRoles_RoleId_UserId` ON `AbpUserRoles` (`RoleId`, `UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUsers_Email` ON `AbpUsers` (`Email`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUsers_NormalizedEmail` ON `AbpUsers` (`NormalizedEmail`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUsers_NormalizedUserName` ON `AbpUsers` (`NormalizedUserName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_AbpUsers_UserName` ON `AbpUsers` (`UserName`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_OpenIddictApplications_ClientId` ON `OpenIddictApplications` (`ClientId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type` ON `OpenIddictAuthorizations` (`ApplicationId`, `Status`, `Subject`, `Type`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_OpenIddictScopes_Name` ON `OpenIddictScopes` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_OpenIddictTokens_ApplicationId_Status_Subject_Type` ON `OpenIddictTokens` (`ApplicationId`, `Status`, `Subject`, `Type`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_OpenIddictTokens_AuthorizationId` ON `OpenIddictTokens` (`AuthorizationId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    CREATE INDEX `IX_OpenIddictTokens_ReferenceId` ON `OpenIddictTokens` (`ReferenceId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20251114082525_Init1')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20251114082525_Init1', '10.0.0');
END;

COMMIT;

