/*
 Navicat Premium Dump SQL

 Source Server         : 192.168.5.245
 Source Server Type    : MySQL
 Source Server Version : 80039 (8.0.39)
 Source Host           : 192.168.5.245:3306
 Source Schema         : heal

 Target Server Type    : MySQL
 Target Server Version : 80039 (8.0.39)
 File Encoding         : 65001

 Date: 16/04/2025 14:58:04
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20250416064948_init', '9.0.0');

-- ----------------------------
-- Table structure for abpauditlogactions
-- ----------------------------
DROP TABLE IF EXISTS `abpauditlogactions`;
CREATE TABLE `abpauditlogactions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `AuditLogId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'AuditLogId',
  `ServiceName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '服务名称',
  `MethodName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '方法名称',
  `Parameters` varchar(2000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '参数',
  `ExecutionTime` datetime(6) NOT NULL COMMENT '执行时间',
  `ExecutionDuration` int NOT NULL COMMENT '执行耗时',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpAuditLogActions_AuditLogId`(`AuditLogId` ASC) USING BTREE,
  INDEX `IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_Execution~`(`TenantId` ASC, `ServiceName` ASC, `MethodName` ASC, `ExecutionTime` ASC) USING BTREE,
  CONSTRAINT `FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId` FOREIGN KEY (`AuditLogId`) REFERENCES `abpauditlogs` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '审计日志-Action' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpauditlogactions
-- ----------------------------
INSERT INTO `abpauditlogactions` VALUES ('3a194f8e-fa29-e681-3ae0-cc1aa283bac9', NULL, '3a194f8e-fa28-41cf-fa03-ab574d0c01ce', 'Volo.Abp.Account.Web.Pages.Account.LoginModel', 'OnPostAsync', '{\"action\":\"Login\"}', '2025-04-16 14:56:02.577945', 1037, '{}');

-- ----------------------------
-- Table structure for abpauditlogs
-- ----------------------------
DROP TABLE IF EXISTS `abpauditlogs`;
CREATE TABLE `abpauditlogs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `ApplicationName` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '应用程序名称',
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '用户Id',
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '用户名',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `TenantName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '租户名称',
  `ImpersonatorUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '模拟用户Id',
  `ImpersonatorUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '模拟用户名',
  `ImpersonatorTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '模拟租户Id',
  `ImpersonatorTenantName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '模拟租户名称',
  `ExecutionTime` datetime(6) NOT NULL COMMENT '执行时间',
  `ExecutionDuration` int NOT NULL COMMENT '执行耗时',
  `ClientIpAddress` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '客户端IP',
  `ClientName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '客户端名称',
  `ClientId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '客户端Id',
  `CorrelationId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '相关联Id',
  `BrowserInfo` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '浏览器信息',
  `HttpMethod` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '请求方式',
  `Url` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '请求Url',
  `Exceptions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Comments` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '评论',
  `HttpStatusCode` int NULL DEFAULT NULL COMMENT '请求响应状态码',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpAuditLogs_TenantId_ExecutionTime`(`TenantId` ASC, `ExecutionTime` ASC) USING BTREE,
  INDEX `IX_AbpAuditLogs_TenantId_UserId_ExecutionTime`(`TenantId` ASC, `UserId` ASC, `ExecutionTime` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '审计日志' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpauditlogs
-- ----------------------------
INSERT INTO `abpauditlogs` VALUES ('3a194f8e-fa28-41cf-fa03-ab574d0c01ce', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-04-16 14:56:02.557362', 1061, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/135.0.0.0 Safari/537.36', 'POST', '/Account/Login', NULL, '', 302, '{}', '88d9b239afb44fc99998eaa98b95274c');

-- ----------------------------
-- Table structure for abpbackgroundjobs
-- ----------------------------
DROP TABLE IF EXISTS `abpbackgroundjobs`;
CREATE TABLE `abpbackgroundjobs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `JobName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '任务名称',
  `JobArgs` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '任务参数',
  `TryCount` smallint NOT NULL DEFAULT 0 COMMENT '重试次数',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `NextTryTime` datetime(6) NOT NULL COMMENT '下次运行时间',
  `LastTryTime` datetime(6) NULL DEFAULT NULL COMMENT '最后一次运行时间',
  `IsAbandoned` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否放弃了',
  `Priority` tinyint UNSIGNED NOT NULL DEFAULT 15 COMMENT '优先级',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpBackgroundJobs_IsAbandoned_NextTryTime`(`IsAbandoned` ASC, `NextTryTime` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '后台任务' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpbackgroundjobs
-- ----------------------------

-- ----------------------------
-- Table structure for abpblobcontainers
-- ----------------------------
DROP TABLE IF EXISTS `abpblobcontainers`;
CREATE TABLE `abpblobcontainers`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpBlobContainers_TenantId_Name`(`TenantId` ASC, `Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'Blob容器' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpblobcontainers
-- ----------------------------

-- ----------------------------
-- Table structure for abpblobs
-- ----------------------------
DROP TABLE IF EXISTS `abpblobs`;
CREATE TABLE `abpblobs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `ContainerId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '容器ID',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Content` longblob NULL COMMENT '数据',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpBlobs_ContainerId`(`ContainerId` ASC) USING BTREE,
  INDEX `IX_AbpBlobs_TenantId_ContainerId_Name`(`TenantId` ASC, `ContainerId` ASC, `Name` ASC) USING BTREE,
  CONSTRAINT `FK_AbpBlobs_AbpBlobContainers_ContainerId` FOREIGN KEY (`ContainerId`) REFERENCES `abpblobcontainers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'Blob' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpblobs
-- ----------------------------

-- ----------------------------
-- Table structure for abpcampus
-- ----------------------------
DROP TABLE IF EXISTS `abpcampus`;
CREATE TABLE `abpcampus`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `ShortName` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '简称',
  `Building` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在大楼',
  `Floor` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在楼层',
  `RoomNumber` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在房间',
  `Address` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在详细地址',
  `Capacity` int NOT NULL COMMENT '院区容量',
  `Phone` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系电话',
  `Email` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系邮箱',
  `HeadOfCampus` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '院区负责人',
  `HeadOfCampusPhone` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '院区负责人电话',
  `HeadOfCampusEmail` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '院区负责人邮箱',
  `Website` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '院区网站',
  `ServicesOffered` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '院区提供的服务',
  `EmergencyContact` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '紧急联系人名称',
  `EmergencyPhone` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '紧急联系人电话',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '最后更新时间',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '最后更新人',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '删除标记',
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '删除人Id',
  `DeletionTime` datetime(6) NULL DEFAULT NULL COMMENT '删除时间',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Code` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
  `Pinyin` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '拼音',
  `PinyinFirstLetters` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '拼音首字母',
  `Status` int NOT NULL COMMENT '启用状态',
  `Sort` int NOT NULL COMMENT '排序字段',
  `CreatorName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '创建人名称',
  `LastModificationName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '最后修改人名称',
  `DeletionName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '删除人名称',
  `Describe` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `OrganizationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '组织Id',
  `OrganizationCode` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '组织Code',
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '父级Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '院区' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpcampus
-- ----------------------------

-- ----------------------------
-- Table structure for abpclaimtypes
-- ----------------------------
DROP TABLE IF EXISTS `abpclaimtypes`;
CREATE TABLE `abpclaimtypes`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Required` tinyint(1) NOT NULL COMMENT '是否必填',
  `IsStatic` tinyint(1) NOT NULL COMMENT '是否静态',
  `Regex` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '正则表达式',
  `RegexDescription` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '正则表达式描述',
  `Description` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `ValueType` int NOT NULL COMMENT '值类型',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '声明类型表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpclaimtypes
-- ----------------------------

-- ----------------------------
-- Table structure for abpdepartment
-- ----------------------------
DROP TABLE IF EXISTS `abpdepartment`;
CREATE TABLE `abpdepartment`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `CampusId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '所在院区Id',
  `ShortName` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '简称',
  `DepartmentTypeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '科室类型Id',
  `Campuses` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Building` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在大楼',
  `Floor` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在楼层',
  `RoomNumber` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在房间',
  `Address` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '所在详细地址',
  `Capacity` int NOT NULL COMMENT '科室容量',
  `Phone` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系电话',
  `Email` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系邮箱',
  `HeadOfDepartment` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '科室负责人',
  `HeadOfDepartmentPhone` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '科室负责人电话',
  `HeadOfDepartmentEmail` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '科室负责人邮箱',
  `Website` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '科室网站',
  `ServicesOffered` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '科室提供的服务',
  `EmergencyContact` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '紧急联系人名称',
  `EmergencyPhone` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '紧急联系人电话',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '最后更新时间',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '最后更新人',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '删除标记',
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '删除人Id',
  `DeletionTime` datetime(6) NULL DEFAULT NULL COMMENT '删除时间',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Code` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
  `Pinyin` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '拼音',
  `PinyinFirstLetters` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '拼音首字母',
  `Status` int NOT NULL COMMENT '启用状态',
  `Sort` int NOT NULL COMMENT '排序字段',
  `CreatorName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '创建人名称',
  `LastModificationName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '最后修改人名称',
  `DeletionName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '删除人名称',
  `Describe` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `OrganizationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '组织Id',
  `OrganizationCode` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '组织Code',
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '父级Id',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '科室' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpdepartment
-- ----------------------------

-- ----------------------------
-- Table structure for abpentitychanges
-- ----------------------------
DROP TABLE IF EXISTS `abpentitychanges`;
CREATE TABLE `abpentitychanges`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `AuditLogId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'AuditLogId',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `ChangeTime` datetime(6) NOT NULL COMMENT '变更时间',
  `ChangeType` tinyint UNSIGNED NOT NULL COMMENT '变更类型',
  `EntityTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '审计实体租户Id',
  `EntityId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '审计实体Id',
  `EntityTypeFullName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '审计实体全称',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpEntityChanges_AuditLogId`(`AuditLogId` ASC) USING BTREE,
  INDEX `IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId`(`TenantId` ASC, `EntityTypeFullName` ASC, `EntityId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpEntityChanges_AbpAuditLogs_AuditLogId` FOREIGN KEY (`AuditLogId`) REFERENCES `abpauditlogs` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '审计日志-Entity' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpentitychanges
-- ----------------------------

-- ----------------------------
-- Table structure for abpentitypropertychanges
-- ----------------------------
DROP TABLE IF EXISTS `abpentitypropertychanges`;
CREATE TABLE `abpentitypropertychanges`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `EntityChangeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `NewValue` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '新值',
  `OriginalValue` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '旧值',
  `PropertyName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '属性名称',
  `PropertyTypeFullName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '属性全称',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpEntityPropertyChanges_EntityChangeId`(`EntityChangeId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId` FOREIGN KEY (`EntityChangeId`) REFERENCES `abpentitychanges` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '审计日志-Entity-Property' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpentitypropertychanges
-- ----------------------------

-- ----------------------------
-- Table structure for abpfeaturegroups
-- ----------------------------
DROP TABLE IF EXISTS `abpfeaturegroups`;
CREATE TABLE `abpfeaturegroups`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '显示名称',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpFeatureGroups_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '功能分组定义记录' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpfeaturegroups
-- ----------------------------
INSERT INTO `abpfeaturegroups` VALUES ('3a194f8e-568c-9d50-981c-782ea560351c', 'SettingManagement', 'L:AbpSettingManagement,Feature:SettingManagementGroup', '{}');

-- ----------------------------
-- Table structure for abpfeatures
-- ----------------------------
DROP TABLE IF EXISTS `abpfeatures`;
CREATE TABLE `abpfeatures`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `GroupName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '所属分组',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `ParentName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '父级名称',
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '显示名称',
  `Description` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `DefaultValue` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '默认值',
  `IsVisibleToClients` tinyint(1) NOT NULL COMMENT '对客户端可见',
  `IsAvailableToHost` tinyint(1) NOT NULL COMMENT '主机是否可用',
  `AllowedProviders` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '允许供应商',
  `ValueType` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '值类型',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpFeatures_Name`(`Name` ASC) USING BTREE,
  INDEX `IX_AbpFeatures_GroupName`(`GroupName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '功能定义' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpfeatures
-- ----------------------------
INSERT INTO `abpfeatures` VALUES ('3a194f8e-5698-82eb-438d-574a8c9bc669', 'SettingManagement', 'SettingManagement.Enable', NULL, 'L:AbpSettingManagement,Feature:SettingManagementEnable', 'L:AbpSettingManagement,Feature:SettingManagementEnableDescription', 'true', 1, 0, NULL, '{\r\n  \"name\": \"ToggleStringValueType\",\r\n  \"properties\": {},\r\n  \"validator\": {\r\n    \"name\": \"BOOLEAN\",\r\n    \"properties\": {}\r\n  }\r\n}', '{}');
INSERT INTO `abpfeatures` VALUES ('3a194f8e-56cb-f7fe-4e56-7322f1a0fe9a', 'SettingManagement', 'SettingManagement.AllowChangingEmailSettings', 'SettingManagement.Enable', 'L:AbpSettingManagement,Feature:AllowChangingEmailSettings', NULL, 'false', 1, 0, NULL, '{\r\n  \"name\": \"ToggleStringValueType\",\r\n  \"properties\": {},\r\n  \"validator\": {\r\n    \"name\": \"BOOLEAN\",\r\n    \"properties\": {}\r\n  }\r\n}', '{}');

-- ----------------------------
-- Table structure for abpfeaturevalues
-- ----------------------------
DROP TABLE IF EXISTS `abpfeaturevalues`;
CREATE TABLE `abpfeaturevalues`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Value` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '值',
  `ProviderName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '提供者名称',
  `ProviderKey` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '提供者Key',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpFeatureValues_Name_ProviderName_ProviderKey`(`Name` ASC, `ProviderName` ASC, `ProviderKey` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '功能配置表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpfeaturevalues
-- ----------------------------

-- ----------------------------
-- Table structure for abplinkusers
-- ----------------------------
DROP TABLE IF EXISTS `abplinkusers`;
CREATE TABLE `abplinkusers`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `SourceUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '源用户Id',
  `SourceTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '源租户',
  `TargetUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '目标用户Id',
  `TargetTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '目标租户',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpLinkUsers_SourceUserId_SourceTenantId_TargetUserId_Target~`(`SourceUserId` ASC, `SourceTenantId` ASC, `TargetUserId` ASC, `TargetTenantId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '管理用户之间的关联关系' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abplinkusers
-- ----------------------------

-- ----------------------------
-- Table structure for abporganizationunitroles
-- ----------------------------
DROP TABLE IF EXISTS `abporganizationunitroles`;
CREATE TABLE `abporganizationunitroles`  (
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '角色Id',
  `OrganizationUnitId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '组织机构Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  PRIMARY KEY (`OrganizationUnitId`, `RoleId`) USING BTREE,
  INDEX `IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId`(`RoleId` ASC, `OrganizationUnitId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUn~` FOREIGN KEY (`OrganizationUnitId`) REFERENCES `abporganizationunits` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AbpOrganizationUnitRoles_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '组织机构角色' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abporganizationunitroles
-- ----------------------------

-- ----------------------------
-- Table structure for abporganizationunits
-- ----------------------------
DROP TABLE IF EXISTS `abporganizationunits`;
CREATE TABLE `abporganizationunits`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '父级Id',
  `Code` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '编码',
  `DisplayName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '显示名称',
  `EntityVersion` int NOT NULL COMMENT '版本',
  `Address` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '地址',
  `CoverImage` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '封面图片',
  `Describe` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注描述',
  `Director` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '院长',
  `Email` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮箱',
  `EstablishmentDate` datetime(6) NULL DEFAULT NULL COMMENT '成立时间',
  `Facilities` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '医院设施',
  `Introduction` varchar(4096) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '医院简介',
  `IsEmergencyServices` tinyint(1) NULL DEFAULT NULL COMMENT '是否提供急诊服务',
  `IsInsuranceAccepted` tinyint(1) NULL DEFAULT NULL COMMENT '是否接受医保',
  `Latitude` decimal(65, 30) NULL DEFAULT NULL COMMENT '纬度',
  `Level` int NULL DEFAULT NULL COMMENT '医院等级',
  `Longitude` decimal(65, 30) NULL DEFAULT NULL COMMENT '经度',
  `OperatingHours` datetime(6) NULL DEFAULT NULL COMMENT '营业时间',
  `ParkingInformation` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '停车信息',
  `Phone` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系电话',
  `PostalCode` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮政编码',
  `ServiceHotline` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '服务热线',
  `TrafficGuide` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '交通指南',
  `WebsiteUrl` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '官方网站',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '最后更新时间',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '最后更新人',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '删除标记',
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '删除人Id',
  `DeletionTime` datetime(6) NULL DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpOrganizationUnits_Code`(`Code` ASC) USING BTREE,
  INDEX `IX_AbpOrganizationUnits_ParentId`(`ParentId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `abporganizationunits` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '组织机构' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abporganizationunits
-- ----------------------------

-- ----------------------------
-- Table structure for abppermissiongrants
-- ----------------------------
DROP TABLE IF EXISTS `abppermissiongrants`;
CREATE TABLE `abppermissiongrants`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限名称',
  `ProviderName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限提供者名称(如:角色R)',
  `ProviderKey` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限提供者Key(如:角色key admin)',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpPermissionGrants_TenantId_Name_ProviderName_ProviderKey`(`TenantId` ASC, `Name` ASC, `ProviderName` ASC, `ProviderKey` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '权限管理' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abppermissiongrants
-- ----------------------------
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cc-99ea-64ae-3e5fed6380b6', NULL, 'AbpIdentity.Roles', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-6ff9-2427-aaf11e4ff0a3', NULL, 'AbpIdentity.Roles.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-23ad-dd99-acf8c4e7f9d3', NULL, 'AbpIdentity.Roles.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-1205-7154-90d8820646a1', NULL, 'AbpIdentity.Roles.ManagePermissions', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-9e4f-f412-6c127fcb3a87', NULL, 'AbpIdentity.Roles.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-9c22-05d7-89642476e62a', NULL, 'AbpIdentity.Users', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-ab7d-1880-4b419a7a6efd', NULL, 'AbpIdentity.Users.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-f796-939a-7d646d7eb6cc', NULL, 'AbpIdentity.Users.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-ec29-5efb-a26c849d92a9', NULL, 'AbpIdentity.Users.ManagePermissions', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-6bcf-35a7-7f35f35e372d', NULL, 'AbpIdentity.Users.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-587e-09e6-ef3b700315f4', NULL, 'AbpIdentity.Users.Update.ManageRoles', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-8d90-1d02-284f0ffa2722', NULL, 'AbpTenantManagement.Tenants', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-ca04-087f-64d9a9e23966', NULL, 'AbpTenantManagement.Tenants.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-504d-a10d-48a3de8039ed', NULL, 'AbpTenantManagement.Tenants.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-5bc9-8d35-221a9b8a1db8', NULL, 'AbpTenantManagement.Tenants.ManageConnectionStrings', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-7239-f815-5eb553d627c6', NULL, 'AbpTenantManagement.Tenants.ManageFeatures', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-4d1f-7a5b-b6bbbc0a2183', NULL, 'AbpTenantManagement.Tenants.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-d4ae-f160-bbca85d610c7', NULL, 'FeatureManagement.ManageHostFeatures', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-52dd-4721-27eef90137f2', NULL, 'SettingManagement.Emailing', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-2250-6b99-dacee9802b44', NULL, 'SettingManagement.Emailing.Test', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-faa6-3d23-ca104cbfe1cc', NULL, 'SettingManagement.TimeZone', 'R', 'admin');

-- ----------------------------
-- Table structure for abppermissiongroups
-- ----------------------------
DROP TABLE IF EXISTS `abppermissiongroups`;
CREATE TABLE `abppermissiongroups`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限组名称',
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限组显示名称',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpPermissionGroups_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '权限分组' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abppermissiongroups
-- ----------------------------
INSERT INTO `abppermissiongroups` VALUES ('3a194f8d-51bc-3b50-199c-28fabb5dab22', 'SettingManagement', 'L:AbpSettingManagement,Permission:SettingManagement', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a194f8d-51bc-3c4b-bbbc-b43263c9bd28', 'FeatureManagement', 'L:AbpFeatureManagement,Permission:FeatureManagement', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a194f8d-51bc-54b5-c9f9-24467e86a3b4', 'Heal', 'F:Heal', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a194f8d-51bc-95ef-a68e-7e3a1a258dd0', 'AbpIdentity', 'L:AbpIdentity,Permission:IdentityManagement', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a194f8d-51bc-b8e7-06aa-9f67eca2e265', 'AbpTenantManagement', 'L:AbpTenantManagement,Permission:TenantManagement', '{}');

-- ----------------------------
-- Table structure for abppermissions
-- ----------------------------
DROP TABLE IF EXISTS `abppermissions`;
CREATE TABLE `abppermissions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `GroupName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限组名称',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限名称',
  `ParentName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '权限父级名称',
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限显示名称',
  `IsEnabled` tinyint(1) NOT NULL COMMENT '是否启用',
  `MultiTenancySide` tinyint UNSIGNED NOT NULL COMMENT '供应商多个,隔开',
  `Providers` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '权限供应者',
  `StateCheckers` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '权限额外属性',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpPermissions_Name`(`Name` ASC) USING BTREE,
  INDEX `IX_AbpPermissions_GroupName`(`GroupName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '权限定义' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abppermissions
-- ----------------------------
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-0188-c0f2-ff076af7fe9b', 'AbpIdentity', 'AbpIdentity.Users.Create', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:Create', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-2b71-3ed0-252dd7c7bdd5', 'AbpIdentity', 'AbpIdentity.UserLookup', NULL, 'L:AbpIdentity,Permission:UserLookup', 1, 3, 'C', NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-37d6-2a50-99f164d35ca7', 'SettingManagement', 'SettingManagement.Emailing.Test', 'SettingManagement.Emailing', 'L:AbpSettingManagement,Permission:EmailingTest', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-3e91-99b9-b41229e00393', 'AbpIdentity', 'AbpIdentity.Users.Update', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:Edit', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-4322-38d8-2b9b7a102133', 'AbpIdentity', 'AbpIdentity.Roles.ManagePermissions', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:ChangePermissions', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-4687-7d91-d582bdfc4c93', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.ManageConnectionStrings', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:ManageConnectionStrings', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-4caa-3c44-e94d33fad50d', 'AbpIdentity', 'AbpIdentity.Users.Delete', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:Delete', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-5194-9a03-3a574d6530a6', 'SettingManagement', 'SettingManagement.TimeZone', NULL, 'L:AbpSettingManagement,Permission:TimeZone', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-6bdf-4632-3a55fa1747ab', 'AbpIdentity', 'AbpIdentity.Users.ManagePermissions', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:ChangePermissions', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-773f-efd7-aac8bbcb1c7d', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.Create', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:Create', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-7964-e156-99421017cea9', 'AbpIdentity', 'AbpIdentity.Roles.Delete', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:Delete', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-85c9-665d-e22723fd7220', 'FeatureManagement', 'FeatureManagement.ManageHostFeatures', NULL, 'L:AbpFeatureManagement,Permission:FeatureManagement.ManageHostFeatures', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-88a6-6d5c-14ee7b418c20', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.Delete', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:Delete', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-8ca9-c14a-fcfaceccf761', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.ManageFeatures', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:ManageFeatures', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-a30a-5f47-72f69ee4ad26', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.Update', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:Edit', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-ad97-7c38-547f0c38d81e', 'AbpIdentity', 'AbpIdentity.Users.Update.ManageRoles', 'AbpIdentity.Users.Update', 'L:AbpIdentity,Permission:ManageRoles', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-c03b-e0b6-d3cf924e2b8e', 'AbpIdentity', 'AbpIdentity.Roles', NULL, 'L:AbpIdentity,Permission:RoleManagement', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-dbed-f062-ec683ecccf23', 'AbpIdentity', 'AbpIdentity.Roles.Create', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:Create', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-de43-de1e-f205e0abd32a', 'SettingManagement', 'SettingManagement.Emailing', NULL, 'L:AbpSettingManagement,Permission:Emailing', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-ecaa-ef98-96da30d21d2a', 'AbpIdentity', 'AbpIdentity.Roles.Update', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:Edit', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-f0f6-f150-a81c0c413acb', 'AbpTenantManagement', 'AbpTenantManagement.Tenants', NULL, 'L:AbpTenantManagement,Permission:TenantManagement', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a194f8d-51bc-fd9a-84e4-d2c76ffd61d3', 'AbpIdentity', 'AbpIdentity.Users', NULL, 'L:AbpIdentity,Permission:UserManagement', 1, 3, NULL, NULL, '{}');

-- ----------------------------
-- Table structure for abproleclaims
-- ----------------------------
DROP TABLE IF EXISTS `abproleclaims`;
CREATE TABLE `abproleclaims`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '角色Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `ClaimType` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '声明类型',
  `ClaimValue` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '声明值',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpRoleClaims_RoleId`(`RoleId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpRoleClaims_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '角色声明表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abproleclaims
-- ----------------------------

-- ----------------------------
-- Table structure for abproles
-- ----------------------------
DROP TABLE IF EXISTS `abproles`;
CREATE TABLE `abproles`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '标准名称',
  `IsDefault` tinyint(1) NOT NULL COMMENT '是否默认',
  `IsStatic` tinyint(1) NOT NULL COMMENT '是否静态',
  `IsPublic` tinyint(1) NOT NULL COMMENT '是否公共',
  `EntityVersion` int NOT NULL COMMENT '版本',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CustomDataPermission` varchar(4096) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '' COMMENT '自定义数据权限',
  `DataPermission` int NOT NULL DEFAULT 0 COMMENT '数据权限',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpRoles_NormalizedName`(`NormalizedName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '角色表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abproles
-- ----------------------------
INSERT INTO `abproles` VALUES ('3a194f8d-da86-22dd-13fe-d1ab928a2b51', NULL, 'admin', 'ADMIN', 0, 1, 1, 2, '2025-04-16 14:54:50.039694', '', 0, '{}', 'b4cd2b363af748bfbb569bc23c6ca499');

-- ----------------------------
-- Table structure for abpsecuritylogs
-- ----------------------------
DROP TABLE IF EXISTS `abpsecuritylogs`;
CREATE TABLE `abpsecuritylogs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `ApplicationName` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '应用模块名称',
  `Identity` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '身份信息',
  `Action` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '操作Action',
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '用户Id',
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '用户名',
  `TenantName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '租户名称',
  `ClientId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '客户端Id',
  `CorrelationId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '相关Id',
  `ClientIpAddress` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '客户端IP地址',
  `BrowserInfo` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '浏览器信息',
  `CreationTime` datetime(6) NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_Action`(`TenantId` ASC, `Action` ASC) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_ApplicationName`(`TenantId` ASC, `ApplicationName` ASC) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_Identity`(`TenantId` ASC, `Identity` ASC) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_UserId`(`TenantId` ASC, `UserId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '身份安全日志' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsecuritylogs
-- ----------------------------
INSERT INTO `abpsecuritylogs` VALUES ('3a194f8e-f999-358a-7afe-7c5ac39a4d0b', NULL, 'Heal.Net.AuthServer', 'Identity', 'LoginSucceeded', '3a194f8d-d797-004e-d3b2-89c6a9684089', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/135.0.0.0 Safari/537.36', '2025-04-16 14:56:03.476663', '{}', '652c5bb12fbd45c3af3613f7291901ef');
INSERT INTO `abpsecuritylogs` VALUES ('3a194f8f-045e-813a-8585-547a50aec6f1', NULL, 'Heal.Net.AuthServer', 'Identity', 'Logout', '3a194f8d-d797-004e-d3b2-89c6a9684089', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/135.0.0.0 Safari/537.36', '2025-04-16 14:56:06.237989', '{}', '95049278dbde4836934e3a1663f9f976');

-- ----------------------------
-- Table structure for abpsessions
-- ----------------------------
DROP TABLE IF EXISTS `abpsessions`;
CREATE TABLE `abpsessions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `SessionId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '会话Id',
  `Device` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '设备',
  `DeviceInfo` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '设备信息',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
  `ClientId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '客户端Id',
  `IpAddresses` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT 'Ip地址',
  `SignedIn` datetime(6) NOT NULL COMMENT '用户登录的时间',
  `LastAccessed` datetime(6) NULL DEFAULT NULL COMMENT '用户最近一次访问系统的时间',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpSessions_Device`(`Device` ASC) USING BTREE,
  INDEX `IX_AbpSessions_SessionId`(`SessionId` ASC) USING BTREE,
  INDEX `IX_AbpSessions_TenantId_UserId`(`TenantId` ASC, `UserId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '会话信息' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsessions
-- ----------------------------

-- ----------------------------
-- Table structure for abpsettingdefinitions
-- ----------------------------
DROP TABLE IF EXISTS `abpsettingdefinitions`;
CREATE TABLE `abpsettingdefinitions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '显示名称',
  `Description` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `DefaultValue` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '默认值',
  `IsVisibleToClients` tinyint(1) NOT NULL,
  `Providers` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '提供者多个,隔开',
  `IsInherited` tinyint(1) NOT NULL COMMENT '此设置是从父作用域继承的吗',
  `IsEncrypted` tinyint(1) NOT NULL COMMENT '此设置是否以加密方式存储在数据源中',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '扩展字段',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpSettingDefinitions_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '配置定义' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsettingdefinitions
-- ----------------------------
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56b7-5440-6f45-f58a70a69367', 'Abp.Localization.DefaultLanguage', 'L:AbpLocalization,DisplayName:Abp.Localization.DefaultLanguage', 'L:AbpLocalization,Description:Abp.Localization.DefaultLanguage', 'en', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-075c-4212-94a4eb74c6e6', 'Abp.Identity.Password.PasswordChangePeriodDays', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.PasswordChangePeriodDays', 'L:AbpIdentity,Description:Abp.Identity.Password.PasswordChangePeriodDays', '0', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-0822-d023-c053e2d2ef21', 'Abp.Mailing.Smtp.Host', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Host', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Host', '127.0.0.1', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-0953-082e-8e2c9e1bfc79', 'Abp.Identity.Lockout.LockoutDuration', 'L:AbpIdentity,DisplayName:Abp.Identity.Lockout.LockoutDuration', 'L:AbpIdentity,Description:Abp.Identity.Lockout.LockoutDuration', '300', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-0c4e-6096-37e19b4acabe', 'Abp.Identity.Password.RequiredUniqueChars', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequiredUniqueChars', 'L:AbpIdentity,Description:Abp.Identity.Password.RequiredUniqueChars', '1', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-0ffc-a8ce-f1f630d6e9b0', 'Abp.Identity.Password.RequireDigit', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireDigit', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireDigit', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-128d-2199-359b0ebb4101', 'Abp.Identity.SignIn.EnablePhoneNumberConfirmation', 'L:AbpIdentity,DisplayName:Abp.Identity.SignIn.EnablePhoneNumberConfirmation', 'L:AbpIdentity,Description:Abp.Identity.SignIn.EnablePhoneNumberConfirmation', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-1d32-6612-eee66b47c39a', 'Abp.Identity.Password.RequiredLength', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequiredLength', 'L:AbpIdentity,Description:Abp.Identity.Password.RequiredLength', '6', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-2494-b8dd-e57d1a574040', 'Abp.Mailing.DefaultFromDisplayName', 'L:AbpEmailing,DisplayName:Abp.Mailing.DefaultFromDisplayName', 'L:AbpEmailing,Description:Abp.Mailing.DefaultFromDisplayName', 'ABP application', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-266f-11a5-dfa2a8c6e738', 'Abp.Identity.Lockout.MaxFailedAccessAttempts', 'L:AbpIdentity,DisplayName:Abp.Identity.Lockout.MaxFailedAccessAttempts', 'L:AbpIdentity,Description:Abp.Identity.Lockout.MaxFailedAccessAttempts', '5', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-2aa4-eca7-b313947eb653', 'Abp.Identity.OrganizationUnit.MaxUserMembershipCount', 'L:AbpIdentity,Identity.OrganizationUnit.MaxUserMembershipCount', 'L:AbpIdentity,Identity.OrganizationUnit.MaxUserMembershipCount', '2147483647', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-34dd-5f38-4f63688995bf', 'Abp.Identity.Password.ForceUsersToPeriodicallyChangePassword', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.ForceUsersToPeriodicallyChangePassword', 'L:AbpIdentity,Description:Abp.Identity.Password.ForceUsersToPeriodicallyChangePassword', 'False', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-3d3c-cae5-f5ff5b94ec77', 'Abp.Mailing.Smtp.EnableSsl', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.EnableSsl', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.EnableSsl', 'false', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-4a8a-cd70-7fb25a9f090d', 'Abp.Account.IsSelfRegistrationEnabled', 'L:AbpAccount,DisplayName:Abp.Account.IsSelfRegistrationEnabled', 'L:AbpAccount,Description:Abp.Account.IsSelfRegistrationEnabled', 'true', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-5e50-7dda-3c606b4105e5', 'Abp.Identity.Lockout.AllowedForNewUsers', 'L:AbpIdentity,DisplayName:Abp.Identity.Lockout.AllowedForNewUsers', 'L:AbpIdentity,Description:Abp.Identity.Lockout.AllowedForNewUsers', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-6685-fe04-0d847ed801d9', 'Abp.Timing.TimeZone', 'L:AbpTiming,DisplayName:Abp.Timing.Timezone', 'L:AbpTiming,Description:Abp.Timing.Timezone', 'UTC', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-67e5-5d1d-0ba864989205', 'Abp.Identity.SignIn.RequireConfirmedEmail', 'L:AbpIdentity,DisplayName:Abp.Identity.SignIn.RequireConfirmedEmail', 'L:AbpIdentity,Description:Abp.Identity.SignIn.RequireConfirmedEmail', 'False', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-764f-e52d-ded54d304808', 'Abp.Identity.Password.RequireLowercase', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireLowercase', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireLowercase', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-80af-4e55-52b49303edce', 'Abp.Identity.User.IsEmailUpdateEnabled', 'L:AbpIdentity,DisplayName:Abp.Identity.User.IsEmailUpdateEnabled', 'L:AbpIdentity,Description:Abp.Identity.User.IsEmailUpdateEnabled', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-88fe-4d5d-c21425e0250d', 'Abp.Mailing.DefaultFromAddress', 'L:AbpEmailing,DisplayName:Abp.Mailing.DefaultFromAddress', 'L:AbpEmailing,Description:Abp.Mailing.DefaultFromAddress', 'noreply@abp.io', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-91f9-bef0-c0228bf52b6e', 'Abp.Identity.SignIn.RequireConfirmedPhoneNumber', 'L:AbpIdentity,DisplayName:Abp.Identity.SignIn.RequireConfirmedPhoneNumber', 'L:AbpIdentity,Description:Abp.Identity.SignIn.RequireConfirmedPhoneNumber', 'False', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-9ab3-5130-ad758195f9f9', 'Abp.Mailing.Smtp.Port', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Port', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Port', '25', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-9da0-1903-b066bbe97840', 'Abp.Identity.Password.RequireUppercase', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireUppercase', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireUppercase', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-a20f-76e9-7a34eeaf855e', 'Abp.Mailing.Smtp.Password', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Password', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Password', NULL, 0, NULL, 1, 1, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-a4fd-71af-4602d38d6a76', 'Abp.Mailing.Smtp.UserName', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.UserName', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.UserName', NULL, 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-b2e6-57b6-c606bdbfbb87', 'Abp.Identity.User.IsUserNameUpdateEnabled', 'L:AbpIdentity,DisplayName:Abp.Identity.User.IsUserNameUpdateEnabled', 'L:AbpIdentity,Description:Abp.Identity.User.IsUserNameUpdateEnabled', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-c5fb-dcfd-33fdba98d429', 'Abp.Mailing.Smtp.UseDefaultCredentials', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.UseDefaultCredentials', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.UseDefaultCredentials', 'true', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-c7ba-5510-2bd317cff62a', 'Abp.Mailing.Smtp.Domain', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Domain', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Domain', NULL, 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-ea0e-0ab6-44025f9af2d7', 'Abp.Identity.Password.RequireNonAlphanumeric', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireNonAlphanumeric', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireNonAlphanumeric', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a194f8e-56bb-f0a2-b818-4ae3b72ffbef', 'Abp.Account.EnableLocalLogin', 'L:AbpAccount,DisplayName:Abp.Account.EnableLocalLogin', 'L:AbpAccount,Description:Abp.Account.EnableLocalLogin', 'true', 1, NULL, 1, 0, '{}');

-- ----------------------------
-- Table structure for abpsettings
-- ----------------------------
DROP TABLE IF EXISTS `abpsettings`;
CREATE TABLE `abpsettings`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '配置名称',
  `Value` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '配置值',
  `ProviderName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '提供者名称',
  `ProviderKey` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '提供者Key',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpSettings_Name_ProviderName_ProviderKey`(`Name` ASC, `ProviderName` ASC, `ProviderKey` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '配置表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsettings
-- ----------------------------

-- ----------------------------
-- Table structure for abptenantconnectionstrings
-- ----------------------------
DROP TABLE IF EXISTS `abptenantconnectionstrings`;
CREATE TABLE `abptenantconnectionstrings`  (
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `Value` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '值',
  PRIMARY KEY (`TenantId`, `Name`) USING BTREE,
  CONSTRAINT `FK_AbpTenantConnectionStrings_AbpTenants_TenantId` FOREIGN KEY (`TenantId`) REFERENCES `abptenants` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '租户配置' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abptenantconnectionstrings
-- ----------------------------

-- ----------------------------
-- Table structure for abptenants
-- ----------------------------
DROP TABLE IF EXISTS `abptenants`;
CREATE TABLE `abptenants`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `NormalizedName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '标准化的名称（通常是去除空格、转换为小写等处理后的名称）',
  `EntityVersion` int NOT NULL COMMENT '实体版本号，用于并发控制或数据版本管理',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '最后更新时间',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '最后更新人',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '删除标记',
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '删除人Id',
  `DeletionTime` datetime(6) NULL DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpTenants_Name`(`Name` ASC) USING BTREE,
  INDEX `IX_AbpTenants_NormalizedName`(`NormalizedName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '租户' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abptenants
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserclaims
-- ----------------------------
DROP TABLE IF EXISTS `abpuserclaims`;
CREATE TABLE `abpuserclaims`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `ClaimType` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '声明类型',
  `ClaimValue` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '声明值',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpUserClaims_UserId`(`UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserClaims_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '用户声明表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserclaims
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserdelegations
-- ----------------------------
DROP TABLE IF EXISTS `abpuserdelegations`;
CREATE TABLE `abpuserdelegations`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `SourceUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '源用户Id',
  `TargetUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '目标用户Id',
  `StartTime` datetime(6) NOT NULL COMMENT '开始时间',
  `EndTime` datetime(6) NOT NULL COMMENT '结束时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '管理用户之间的委托关系' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserdelegations
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserlogins
-- ----------------------------
DROP TABLE IF EXISTS `abpuserlogins`;
CREATE TABLE `abpuserlogins`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
  `LoginProvider` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '登录提供者',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `ProviderKey` varchar(196) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '登录提供者Key',
  `ProviderDisplayName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '登录提供者显示名称',
  PRIMARY KEY (`UserId`, `LoginProvider`) USING BTREE,
  INDEX `IX_AbpUserLogins_LoginProvider_ProviderKey`(`LoginProvider` ASC, `ProviderKey` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserLogins_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '外部登录' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserlogins
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserorganizationunits
-- ----------------------------
DROP TABLE IF EXISTS `abpuserorganizationunits`;
CREATE TABLE `abpuserorganizationunits`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
  `OrganizationUnitId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '组织机构Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  PRIMARY KEY (`OrganizationUnitId`, `UserId`) USING BTREE,
  INDEX `IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId`(`UserId` ASC, `OrganizationUnitId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUn~` FOREIGN KEY (`OrganizationUnitId`) REFERENCES `abporganizationunits` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AbpUserOrganizationUnits_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '用户组织机构关系表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserorganizationunits
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserroles
-- ----------------------------
DROP TABLE IF EXISTS `abpuserroles`;
CREATE TABLE `abpuserroles`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '角色Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  PRIMARY KEY (`UserId`, `RoleId`) USING BTREE,
  INDEX `IX_AbpUserRoles_RoleId_UserId`(`RoleId` ASC, `UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserRoles_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AbpUserRoles_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '用户角色关系表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserroles
-- ----------------------------
INSERT INTO `abpuserroles` VALUES ('3a194f8d-d797-004e-d3b2-89c6a9684089', '3a194f8d-da86-22dd-13fe-d1ab928a2b51', NULL);

-- ----------------------------
-- Table structure for abpusers
-- ----------------------------
DROP TABLE IF EXISTS `abpusers`;
CREATE TABLE `abpusers`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户名',
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户名标准名',
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '名',
  `Surname` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '姓',
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '邮箱',
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '邮箱标准名称',
  `EmailConfirmed` tinyint(1) NOT NULL DEFAULT 0 COMMENT '邮箱确认',
  `PasswordHash` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '密码散列',
  `SecurityStamp` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '安全票据',
  `IsExternal` tinyint(1) NOT NULL DEFAULT 0 COMMENT '是否外部',
  `PhoneNumber` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '手机号码',
  `PhoneNumberConfirmed` tinyint(1) NOT NULL DEFAULT 0 COMMENT '手机号码确认',
  `IsActive` tinyint(1) NOT NULL COMMENT '是否活跃',
  `TwoFactorEnabled` tinyint(1) NOT NULL DEFAULT 0 COMMENT '双因素认证',
  `LockoutEnd` datetime(6) NULL DEFAULT NULL COMMENT '锁定到期时间',
  `LockoutEnabled` tinyint(1) NOT NULL DEFAULT 0 COMMENT '锁定',
  `AccessFailedCount` int NOT NULL DEFAULT 0 COMMENT '错误登录次数',
  `ShouldChangePasswordOnNextLogin` tinyint(1) NOT NULL COMMENT '是否需要更改密码',
  `EntityVersion` int NOT NULL COMMENT '版本',
  `LastPasswordChangeTime` datetime(6) NULL DEFAULT NULL COMMENT '最后修改密码时间',
  `Avatar` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '' COMMENT '头像',
  `Identity` int NOT NULL DEFAULT 1 COMMENT '身份标识',
  `OpenId` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '' COMMENT '第三方登录唯一标识',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '最后更新时间',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '最后更新人',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '删除标记',
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '删除人Id',
  `DeletionTime` datetime(6) NULL DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpUsers_Email`(`Email` ASC) USING BTREE,
  INDEX `IX_AbpUsers_NormalizedEmail`(`NormalizedEmail` ASC) USING BTREE,
  INDEX `IX_AbpUsers_NormalizedUserName`(`NormalizedUserName` ASC) USING BTREE,
  INDEX `IX_AbpUsers_UserName`(`UserName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '用户表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpusers
-- ----------------------------
INSERT INTO `abpusers` VALUES ('3a194f8d-d797-004e-d3b2-89c6a9684089', NULL, 'admin', 'ADMIN', 'admin', NULL, 'admin@abp.io', 'ADMIN@ABP.IO', 0, 'AQAAAAIAAYagAAAAEFn1ImjIpUU+8yckCgWoAbHYhlJcW+qoIKvJM2db+RkM5w8u5LYYKJrOdVwEkGwUSA==', 'CY4O2Y6BMUKBGPVHXQUHXACMSU7ANB7F', 0, NULL, 0, 1, 0, NULL, 1, 0, 0, 2, '2025-04-16 06:54:49.345397', '', 1, '', '{}', 'aca835c0e0214b6d9d8554c80e6ed722', '2025-04-16 14:54:49.581666', NULL, '2025-04-16 14:54:50.296777', NULL, 0, NULL, NULL);

-- ----------------------------
-- Table structure for abpusertokens
-- ----------------------------
DROP TABLE IF EXISTS `abpusertokens`;
CREATE TABLE `abpusertokens`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '用户Id',
  `LoginProvider` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '登录提供者',
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '租户Id',
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '值',
  PRIMARY KEY (`UserId`, `LoginProvider`, `Name`) USING BTREE,
  CONSTRAINT `FK_AbpUserTokens_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '外部服务生成的令牌' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpusertokens
-- ----------------------------

-- ----------------------------
-- Table structure for openiddictapplications
-- ----------------------------
DROP TABLE IF EXISTS `openiddictapplications`;
CREATE TABLE `openiddictapplications`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `ApplicationType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与应用程序关联的应用程序类型',
  `ClientId` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与当前应用程序关联的客户端标识符',
  `ClientSecret` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前应用程序关联的客户端密钥。注意：根据创建此实例的应用程序管理器，该属性可能出于安全原因被哈希或加密',
  `ClientType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与应用程序关联的客户端类型',
  `ConsentType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与当前应用程序关联的同意类型',
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前应用程序关联的显示名称',
  `DisplayNames` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前应用程序关联的本地化显示名称，序列化为 JSON 对象',
  `JsonWebKeySet` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与应用程序关联的 JSON Web Key Set，序列化为 JSON 对象',
  `Permissions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前应用程序关联的权限，序列化为 JSON 数组',
  `PostLogoutRedirectUris` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前应用程序关联的登出回调 URL，序列化为 JSON 数组',
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '附加属性，序列化为 JSON 对象；如果未与当前应用程序关联任何属性，则为 null',
  `RedirectUris` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前应用程序关联的回调 URL，序列化为 JSON 数组',
  `Requirements` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前应用程序关联的要求，序列化为 JSON 数组',
  `Settings` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '设置，序列化为 JSON 对象',
  `ClientUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '指向客户端更多信息的 URI',
  `LogoUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '指向客户端标志的 URI',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '最后更新时间',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '最后更新人',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '删除标记',
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '删除人Id',
  `DeletionTime` datetime(6) NULL DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictApplications_ClientId`(`ClientId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OpenIddict-应用程序' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of openiddictapplications
-- ----------------------------
INSERT INTO `openiddictapplications` VALUES ('3a194f8d-dee4-a97f-cf50-50f782c66a24', 'web', 'Heal_App', NULL, 'public', 'implicit', 'Console Test / Angular Application', NULL, NULL, '[\"gt:authorization_code\",\"rst:code\",\"ept:authorization\",\"ept:token\",\"ept:revocation\",\"ept:introspection\",\"gt:password\",\"gt:client_credentials\",\"gt:refresh_token\",\"gt:LinkLogin\",\"gt:Impersonation\",\"scp:address\",\"scp:email\",\"scp:phone\",\"scp:profile\",\"scp:roles\",\"scp:Heal\",\"scp:HealNetApp\",\"scp:data_permission\",\"scp:custom_data_permission\",\"scp:organization_code\"]', NULL, NULL, NULL, NULL, NULL, NULL, '/images/clients/angular.svg', '{}', '66535fdd17ae452ab2c19d3452b853fe', '2025-04-16 14:54:51.196987', NULL, NULL, NULL, 0, NULL, NULL);
INSERT INTO `openiddictapplications` VALUES ('3a194f8d-df88-378f-2cbc-0a2c5df3e21e', 'web', 'Heal_Swagger', NULL, 'public', 'implicit', 'Swagger Application', NULL, NULL, '[\"ept:end_session\",\"gt:authorization_code\",\"rst:code\",\"ept:authorization\",\"ept:token\",\"ept:revocation\",\"ept:introspection\",\"scp:address\",\"scp:email\",\"scp:phone\",\"scp:profile\",\"scp:roles\",\"scp:Heal\",\"scp:HealNetApp\",\"scp:data_permission\",\"scp:custom_data_permission\",\"scp:organization_code\"]', NULL, NULL, '[\"https://localhost:44364/swagger/oauth2-redirect.html\"]', NULL, NULL, 'https://localhost:44364/swagger', '/images/clients/swagger.svg', '{}', '72c8d4e0385648ed858ffb72d5858927', '2025-04-16 14:54:51.276638', NULL, NULL, NULL, 0, NULL, NULL);
INSERT INTO `openiddictapplications` VALUES ('3a194f8d-df96-3374-ba87-1d6239485655', 'web', 'HealNetApp', 'AQAAAAEAACcQAAAAEHcgMyZJQaM3p8wEJmfOby84j9wMSL4vHfWqJryyAYP38xQbF2Is1tq/otO/ImP3MA==', 'confidential', 'explicit', 'HealNetApp Application', NULL, NULL, '[\"rst:code id_token\",\"ept:end_session\",\"gt:authorization_code\",\"rst:code\",\"ept:authorization\",\"ept:token\",\"ept:revocation\",\"ept:introspection\",\"gt:implicit\",\"rst:id_token\",\"gt:password\",\"gt:client_credentials\",\"gt:refresh_token\",\"gt:urn:ietf:params:oauth:grant-type:device_code\",\"ept:device_authorization\",\"gt:heal_net_password\",\"gt:heal_pat_password\",\"gt:heal_doc_password\",\"scp:address\",\"scp:email\",\"scp:phone\",\"scp:profile\",\"scp:roles\",\"scp:Heal\",\"scp:HealNetApp\",\"scp:data_permission\",\"scp:custom_data_permission\",\"scp:organization_code\"]', '[\"https://localhost:44364/signout-callback-oidc\"]', NULL, '[\"https://localhost:44364/signin-oidc\"]', NULL, NULL, NULL, NULL, '{}', 'de0af30ef8ec4fb78874b297b7adecf5', '2025-04-16 14:54:51.296868', NULL, NULL, NULL, 0, NULL, NULL);

-- ----------------------------
-- Table structure for openiddictauthorizations
-- ----------------------------
DROP TABLE IF EXISTS `openiddictauthorizations`;
CREATE TABLE `openiddictauthorizations`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `ApplicationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '与当前授权关联的应用程序的唯一标识符',
  `CreationDate` datetime(6) NULL DEFAULT NULL COMMENT '当前授权的 UTC 创建日期',
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '附加属性，序列化为 JSON 对象；如果未与当前授权关联任何属性，则为 null',
  `Scopes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前授权关联的作用域，序列化为 JSON 数组',
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '当前授权的状态',
  `Subject` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与当前授权关联的主体',
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '当前授权的类型',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type`(`ApplicationId` ASC, `Status` ASC, `Subject` ASC, `Type` ASC) USING BTREE,
  CONSTRAINT `FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `openiddictapplications` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OpenIddict-授权信息' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of openiddictauthorizations
-- ----------------------------

-- ----------------------------
-- Table structure for openiddictscopes
-- ----------------------------
DROP TABLE IF EXISTS `openiddictscopes`;
CREATE TABLE `openiddictscopes`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前作用域关联的公开描述',
  `Descriptions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前作用域关联的本地化公开描述，序列化为 JSON 对象',
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前作用域关联的显示名称',
  `DisplayNames` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前作用域关联的本地化显示名称，序列化为 JSON 对象',
  `Name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与当前作用域关联的唯一名称',
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '附加属性，序列化为 JSON 对象；如果未与当前作用域关联任何属性，则为 null',
  `Resources` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '与当前作用域关联的资源，序列化为 JSON 数组',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  `CreationTime` datetime(6) NOT NULL COMMENT '创建时间',
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '创建人Id',
  `LastModificationTime` datetime(6) NULL DEFAULT NULL COMMENT '最后更新时间',
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '最后更新人',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '删除标记',
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '删除人Id',
  `DeletionTime` datetime(6) NULL DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictScopes_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OpenIddict-授权范围' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of openiddictscopes
-- ----------------------------
INSERT INTO `openiddictscopes` VALUES ('3a194f8d-de27-b91b-73ea-e1ef02d46bd8', NULL, NULL, 'Heal API', NULL, 'Heal', NULL, '[\"Heal\"]', '{}', 'd4ed6a053e5245bb92be09900200fcdb', '2025-04-16 14:54:50.985296', NULL, NULL, NULL, 0, NULL, NULL);
INSERT INTO `openiddictscopes` VALUES ('3a194f8d-deb3-0f15-6f3e-72e62720e700', NULL, NULL, 'HealNetApp API', NULL, 'HealNetApp', NULL, '[\"HealNetApp\"]', '{}', 'f6ba6d471f054d02af24cb43fa68bb66', '2025-04-16 14:54:51.063525', NULL, NULL, NULL, 0, NULL, NULL);

-- ----------------------------
-- Table structure for openiddicttokens
-- ----------------------------
DROP TABLE IF EXISTS `openiddicttokens`;
CREATE TABLE `openiddicttokens`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `ApplicationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '与当前令牌关联的应用程序的唯一标识符',
  `AuthorizationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '与当前令牌关联的授权的唯一标识符',
  `CreationDate` datetime(6) NULL DEFAULT NULL COMMENT '当前令牌的 UTC 创建日期',
  `ExpirationDate` datetime(6) NULL DEFAULT NULL COMMENT '当前令牌的 UTC 过期日期',
  `Payload` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '当前令牌的有效载荷（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被加密',
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL COMMENT '附加属性，序列化为 JSON 对象；如果未与当前令牌关联任何属性，则为 null',
  `RedemptionDate` datetime(6) NULL DEFAULT NULL COMMENT '当前令牌的 UTC 兑换日期',
  `ReferenceId` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与当前令牌关联的引用标识符（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被哈希或加密',
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '当前令牌的状态',
  `Subject` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '与当前令牌关联的主体',
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '当前令牌的类型',
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '扩展字段',
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '迸发标记',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictTokens_ApplicationId_Status_Subject_Type`(`ApplicationId` ASC, `Status` ASC, `Subject` ASC, `Type` ASC) USING BTREE,
  INDEX `IX_OpenIddictTokens_AuthorizationId`(`AuthorizationId` ASC) USING BTREE,
  INDEX `IX_OpenIddictTokens_ReferenceId`(`ReferenceId` ASC) USING BTREE,
  CONSTRAINT `FK_OpenIddictTokens_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `openiddictapplications` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId` FOREIGN KEY (`AuthorizationId`) REFERENCES `openiddictauthorizations` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OpenIddict-颁发的Token' ROW_FORMAT = Dynamic;
