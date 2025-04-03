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

 Date: 03/04/2025 09:06:47
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
INSERT INTO `__efmigrationshistory` VALUES ('20250319094805_init', '9.0.0');

-- ----------------------------
-- Table structure for abpauditlogactions
-- ----------------------------
DROP TABLE IF EXISTS `abpauditlogactions`;
CREATE TABLE `abpauditlogactions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `AuditLogId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ServiceName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `MethodName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Parameters` varchar(2000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ExecutionTime` datetime(6) NOT NULL,
  `ExecutionDuration` int NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpAuditLogActions_AuditLogId`(`AuditLogId` ASC) USING BTREE,
  INDEX `IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_Execution~`(`TenantId` ASC, `ServiceName` ASC, `MethodName` ASC, `ExecutionTime` ASC) USING BTREE,
  CONSTRAINT `FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId` FOREIGN KEY (`AuditLogId`) REFERENCES `abpauditlogs` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpauditlogactions
-- ----------------------------
INSERT INTO `abpauditlogactions` VALUES ('3a18bffc-83e2-0c32-8374-f5979e206d5f', NULL, '3a18bffc-83e2-b19f-5316-fc07b5a89c97', 'Volo.Abp.Account.Web.Pages.Account.LoginModel', 'OnPostAsync', '{\"action\":\"Login\"}', '2025-03-19 17:50:22.226360', 964, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18c883-cc18-7b3f-27d2-cdbea67e5632', NULL, '3a18c883-cc17-54cf-4226-5733970ca7bb', 'Heal.Net.AuthServer.Pages.IndexModel', 'OnGetAsync', '{}', '2025-03-21 09:34:52.798362', 13923, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18c883-e01d-3710-e1ec-5f5e536b6234', NULL, '3a18c883-e01d-db3d-f6cb-cb271ed6341d', 'Heal.Net.AuthServer.Pages.IndexModel', 'OnGetAsync', '{}', '2025-03-21 09:35:10.403656', 1288, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18c883-e01f-cc9d-8cbd-d39a425e703e', NULL, '3a18c883-e01f-de32-7d21-8ebee3273535', 'Heal.Net.AuthServer.Pages.IndexModel', 'OnGetAsync', '{}', '2025-03-21 09:35:10.401169', 912, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18c884-09f0-26d0-56fc-cc7270b5a2a9', NULL, '3a18c884-09f0-2999-b895-6253a66fa401', 'Heal.Net.AuthServer.Pages.IndexModel', 'OnGetAsync', '{}', '2025-03-21 09:35:10.406811', 12122, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18c9de-c6fb-6701-ea93-22e8179b3890', NULL, '3a18c9de-c6fa-f520-303f-a5386754505f', 'Volo.Abp.Account.Web.Pages.Account.LoginModel', 'OnPostAsync', '{\"action\":\"Login\"}', '2025-03-21 15:54:05.509650', 938, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18c9e7-141a-b0ad-f026-809c28758c00', NULL, '3a18c9e7-1419-4e5b-56c2-d7ec3cf4add0', 'Volo.Abp.Account.Web.Pages.Account.LoginModel', 'OnPostAsync', '{\"action\":\"Login\"}', '2025-03-21 16:03:09.527893', 951, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18dcfa-0518-58de-5d33-a80d69e097b2', NULL, '3a18dcfa-0517-4867-8e33-39bb61280946', 'Volo.Abp.PermissionManagement.PermissionsController', 'GetAsync', '{\"providerName\":\"4535\",\"providerKey\":\"345\"}', '2025-03-25 08:56:38.798640', 60, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18dd02-1761-7ebd-f4ac-b5b3f5199bf4', NULL, '3a18dd02-1760-36f5-b4ca-3903822816bb', 'Volo.Abp.PermissionManagement.PermissionsController', 'GetAsync', '{\"providerName\":\"34545\",\"providerKey\":\"34534\"}', '2025-03-25 09:05:27.771907', 59, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18dd02-61c4-f61a-9691-d1a2e8e92bce', NULL, '3a18dd02-61c4-6492-b12c-c924a3952bc9', 'Volo.Abp.PermissionManagement.PermissionsController', 'UpdateAsync', '{\"providerName\":\"ertert\",\"providerKey\":\"eertert\",\"input\":{\"permissions\":[{\"name\":\"string\",\"isGranted\":true}]}}', '2025-03-25 09:05:46.866767', 40, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e345-5157-1e3f-31b7-b61774bc6908', NULL, '3a18e345-5156-a04b-0f2b-70328ab8f268', 'Volo.Abp.Account.Web.Pages.Account.LoginModel', 'OnPostAsync', '{\"action\":\"Login\"}', '2025-03-26 14:16:35.997019', 941, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e380-68ee-7fab-9945-57023066b3c0', NULL, '3a18e380-68ee-a9ee-ebe6-7c8c215266bb', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:19:44.988615', 84516, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e383-d79a-9123-bfd9-a36b7fde71f8', NULL, '3a18e383-d79a-9674-32b2-ead3549eb4a9', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:24:12.455156', 41204, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e387-e3fe-9c1f-5df2-76e4c2e59734', NULL, '3a18e387-e3fe-8ccd-25ec-bba814db46ac', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:29:18.377443', 1099, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e387-e52c-f3ac-cfb0-5d0eae6333f9', NULL, '3a18e387-e52c-c560-f970-a57762c7e24a', 'Heal.Net.Application.Bases.Users.AccountAppService', 'LoginAsync', '{\"input\":{\"userName\":\"admin\",\"password\":\"1q2w3E*\",\"tenantId\":null}}', '2025-03-26 15:29:16.979723', 3153, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e387-e52e-0885-08ca-7fd535342a94', NULL, '3a18e387-e52c-c560-f970-a57762c7e24a', 'Heal.Net.HttpApi.Controllers.Bases.AccountController', 'LoginAsync', '{\"input\":{\"userName\":\"admin\",\"password\":\"1q2w3E*\",\"tenantId\":null}}', '2025-03-26 15:29:16.930711', 3205, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-2881-088e-c721-caeeac3b3672', NULL, '3a18e388-2881-7f00-0e77-29be55c7bbc4', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:29:37.193592', 136, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-2930-8ce0-2344-d10ebc3c10cc', NULL, '3a18e388-2930-a01e-c786-eb09ef82e06f', 'Heal.Net.Application.Bases.Users.AccountAppService', 'RefreshAsync', '', '2025-03-26 15:29:36.892386', 665, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-2930-a342-2d8c-2669539295c4', NULL, '3a18e388-2930-a01e-c786-eb09ef82e06f', 'Heal.Net.HttpApi.Controllers.Bases.AccountController', 'RefreshAsync', '', '2025-03-26 15:29:36.855878', 705, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-3cf5-cd8b-970c-0ac8d51e7bdc', NULL, '3a18e388-3cf5-8fe0-33b8-f00a81695d9f', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:29:42.575230', 25, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-3d9f-7189-fb01-355d588d5bde', NULL, '3a18e388-3d9f-fba3-d2b6-0ade69ff0a44', 'Heal.Net.Application.Bases.Users.AccountAppService', 'RefreshAsync', '', '2025-03-26 15:29:42.371611', 418, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-3d9f-80fb-f45a-c94988f374ea', NULL, '3a18e388-3d9f-fba3-d2b6-0ade69ff0a44', 'Heal.Net.HttpApi.Controllers.Bases.AccountController', 'RefreshAsync', '', '2025-03-26 15:29:42.328912', 464, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-4b46-19b6-64fd-95442f9f3edf', NULL, '3a18e388-4b46-5251-d4e3-245c0b0b7fc8', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:29:46.249009', 18, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-4c09-8f6c-5023-5c8299e36628', NULL, '3a18e388-4c09-7641-43c5-6bd9e8465cf5', 'Heal.Net.Application.Bases.Users.AccountAppService', 'RefreshAsync', '', '2025-03-26 15:29:46.092946', 364, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e388-4c09-9cca-d85f-04ae57d1677c', NULL, '3a18e388-4c09-7641-43c5-6bd9e8465cf5', 'Heal.Net.HttpApi.Controllers.Bases.AccountController', 'RefreshAsync', '', '2025-03-26 15:29:46.053877', 407, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e38c-68b7-e00a-140f-ae3f18c79be4', NULL, '3a18e38c-68b7-a610-dc77-153e7a321890', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:34:15.735877', 221, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e38c-f386-d42f-2790-c5f4f0f364d9', NULL, '3a18e38c-f386-e4e4-a6c9-2c4f1fac8869', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:34:51.436958', 44, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e38c-fae5-2af2-526f-c00511a08b87', NULL, '3a18e38c-fae5-a65a-7e63-d4763e27b6cf', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:34:53.355555', 21, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e38c-ffee-2e2f-7bed-4e8df6adf479', NULL, '3a18e38c-ffee-c065-1c40-b89e77687061', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:34:54.633355', 25, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e38d-05db-d5ea-3c2c-450a75bd3500', NULL, '3a18e38d-05db-fe17-ae32-6b023dfa9451', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 15:34:56.165338', 21, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e3a7-ed28-16bb-6b29-c9310d0e5262', NULL, '3a18e3a7-ed28-149e-0e72-a8a89c6fd961', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 16:04:18.313181', 1009, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e3a8-bf5d-a649-ed7d-2f2992ce1f2b', NULL, '3a18e3a8-bf5d-3aa8-936b-2fa614bdb6a3', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 16:05:13.012180', 90, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e3ab-0809-ccd7-e3bb-98b88d3ace14', NULL, '3a18e3ab-0809-bf0b-479a-2eaed548d197', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 16:07:42.635420', 187, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e3ab-302e-625c-6cf9-4607aecb85c2', NULL, '3a18e3ab-302e-5a62-1448-a1eeed0057a4', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 16:07:53.007020', 63, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e3ab-5a67-4e97-f60a-2b23ff2dfa3c', NULL, '3a18e3ab-5a67-f62a-7eac-c78e99411646', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 16:08:03.875892', 31, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e3ab-65b7-4db1-1dae-4a2f4822f00c', NULL, '3a18e3ab-65b7-ac46-da68-badd0c22fc8d', 'Volo.Abp.OpenIddict.Controllers.TokenController', 'HandleAsync', '{}', '2025-03-26 16:08:06.801520', 13, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e75e-9ea7-380a-aa4b-ce42bfeec083', NULL, '3a18e75e-9ea7-6a71-2368-aa4af26c72c9', 'Heal.Net.Application.Bases.Users.AccountAppService', 'LoginAsync', '{\"input\":{\"userName\":\"admin\",\"password\":\"1q2w3E*\",\"tenantId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}}', '2025-03-27 09:22:12.679235', 29005, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e75e-9eaa-5f50-c05b-1dedc091c3f1', NULL, '3a18e75e-9ea7-6a71-2368-aa4af26c72c9', 'Heal.Net.HttpApi.Controllers.Bases.AccountController', 'LoginAsync', '{\"input\":{\"userName\":\"admin\",\"password\":\"1q2w3E*\",\"tenantId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}}', '2025-03-27 09:22:12.634269', 31168, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e75e-f7c4-4c3d-4609-1c35c5429f1b', NULL, '3a18e75e-f7c4-8bec-dfba-3f59aa86d19e', 'Heal.Net.Application.Bases.Users.AccountAppService', 'LoginAsync', '{\"input\":{\"userName\":\"admin\",\"password\":\"1q2w3E*\",\"tenantId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}}', '2025-03-27 09:22:47.377674', 16710, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18e75e-f7c4-e795-f35d-16dc0674300b', NULL, '3a18e75e-f7c4-8bec-dfba-3f59aa86d19e', 'Heal.Net.HttpApi.Controllers.Bases.AccountController', 'LoginAsync', '{\"input\":{\"userName\":\"admin\",\"password\":\"1q2w3E*\",\"tenantId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}}', '2025-03-27 09:22:47.334523', 19306, '{}');
INSERT INTO `abpauditlogactions` VALUES ('3a18fbe6-3826-b220-d9d0-30c77355be57', NULL, '3a18fbe6-3825-278f-f904-0cde4983e3b6', 'Volo.Abp.Account.Web.Pages.Account.LoginModel', 'OnPostAsync', '{\"action\":\"Login\"}', '2025-03-31 09:03:02.998321', 11958, '{}');

-- ----------------------------
-- Table structure for abpauditlogs
-- ----------------------------
DROP TABLE IF EXISTS `abpauditlogs`;
CREATE TABLE `abpauditlogs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ApplicationName` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `TenantName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ImpersonatorUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ImpersonatorUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ImpersonatorTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ImpersonatorTenantName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ExecutionTime` datetime(6) NOT NULL,
  `ExecutionDuration` int NOT NULL,
  `ClientIpAddress` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ClientName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ClientId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CorrelationId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `BrowserInfo` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `HttpMethod` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Url` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Exceptions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Comments` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `HttpStatusCode` int NULL DEFAULT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpAuditLogs_TenantId_ExecutionTime`(`TenantId` ASC, `ExecutionTime` ASC) USING BTREE,
  INDEX `IX_AbpAuditLogs_TenantId_UserId_ExecutionTime`(`TenantId` ASC, `UserId` ASC, `ExecutionTime` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpauditlogs
-- ----------------------------
INSERT INTO `abpauditlogs` VALUES ('3a18bffc-83e2-b19f-5316-fc07b5a89c97', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-19 17:50:22.183707', 1011, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/Account/Login', NULL, '', 302, '{}', '0c57679bc20c483294345bb626ea7055');
INSERT INTO `abpauditlogs` VALUES ('3a18c883-cc17-54cf-4226-5733970ca7bb', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-21 09:34:52.795625', 13957, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'GET', '/', '[\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"对不起，在处理您的请求期间产生了一个服务器内部错误！！\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 500, '{}', 'c9fb2a003aa04a4da3081b41aabb0f7a');
INSERT INTO `abpauditlogs` VALUES ('3a18c883-e01d-db3d-f6cb-cb271ed6341d', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-21 09:35:10.400797', 1500, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'GET', '/', '[\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"对不起，在处理您的请求期间产生了一个服务器内部错误！！\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 500, '{}', '7b29b4533b65410bb65164f5aa13e85e');
INSERT INTO `abpauditlogs` VALUES ('3a18c883-e01f-de32-7d21-8ebee3273535', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-21 09:35:10.397518', 1506, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'GET', '/', '[\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"对不起，在处理您的请求期间产生了一个服务器内部错误！！\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 500, '{}', 'f45d8fc81cd94eff9f3860cf3654b5c7');
INSERT INTO `abpauditlogs` VALUES ('3a18c884-09f0-2999-b895-6253a66fa401', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-21 09:35:10.403490', 12205, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'GET', '/', '[\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"对不起，在处理您的请求期间产生了一个服务器内部错误！！\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 500, '{}', '6d42ba2752f5416d8e845d8e689d79a7');
INSERT INTO `abpauditlogs` VALUES ('3a18c9de-c6fa-f520-303f-a5386754505f', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-21 15:54:05.485183', 966, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/Account/Login', NULL, '', 302, '{}', '512f9287766f4770b2a1d09fd115fa86');
INSERT INTO `abpauditlogs` VALUES ('3a18c9e7-1419-4e5b-56c2-d7ec3cf4add0', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-21 16:03:09.504355', 979, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/Account/Login', NULL, '', 302, '{}', '939d1a6240a64acdaa6ee295fbf4c508');
INSERT INTO `abpauditlogs` VALUES ('3a18dcfa-0517-4867-8e33-39bb61280946', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-25 08:56:38.711113', 213, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'GET', '/api/permission-management/permissions', '[\r\n  {\r\n    \"code\": \"Volo.Authorization:010001\",\r\n    \"message\": \"授权失败！提供的策略尚未授予。\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  },\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"对不起，在处理您的请求期间产生了一个服务器内部错误！！\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 500, '{}', 'c78027d53c7f487cb8b45831cd205980');
INSERT INTO `abpauditlogs` VALUES ('3a18dd02-1760-36f5-b4ca-3903822816bb', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-25 09:05:27.674686', 219, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'GET', '/api/permission-management/permissions', '[\r\n  {\r\n    \"code\": \"Volo.Authorization:010001\",\r\n    \"message\": \"授权失败！提供的策略尚未授予。\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 401, '{}', '9049f47956fc4b80b7d5e4787be0c040');
INSERT INTO `abpauditlogs` VALUES ('3a18dd02-61c4-6492-b12c-c924a3952bc9', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-25 09:05:46.757789', 189, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'PUT', '/api/permission-management/permissions', '[\r\n  {\r\n    \"code\": \"Volo.Authorization:010001\",\r\n    \"message\": \"授权失败！提供的策略尚未授予。\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 401, '{}', 'c138003c02b24b24ae563c6e429e89e1');
INSERT INTO `abpauditlogs` VALUES ('3a18e345-5156-a04b-0f2b-70328ab8f268', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 14:16:35.972227', 970, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/Account/Login', NULL, '', 302, '{}', '36c5e06580ce40d686c34be6dac46b3d');
INSERT INTO `abpauditlogs` VALUES ('3a18e380-68ee-a9ee-ebe6-7c8c215266bb', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:19:44.981329', 84620, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', '[\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"对不起，在处理您的请求期间产生了一个服务器内部错误！！\",\r\n    \"details\": null,\r\n    \"data\": null,\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 500, '{}', 'c475cd4a1c204accbcec4e797501b220');
INSERT INTO `abpauditlogs` VALUES ('3a18e383-d79a-9674-32b2-ead3549eb4a9', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:24:12.447406', 42102, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', 'ead2498c35f74b37a3d4d87a7b98f2d0');
INSERT INTO `abpauditlogs` VALUES ('3a18e387-e3fe-8ccd-25ec-bba814db46ac', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:18.373188', 1492, '::1', NULL, NULL, NULL, NULL, 'POST', '/connect/token', NULL, '', 200, '{}', '8332f24552914816b12e46e56dcccc4e');
INSERT INTO `abpauditlogs` VALUES ('3a18e387-e52c-c560-f970-a57762c7e24a', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:16.815838', 3350, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/login', NULL, '', 200, '{}', '8f8eabc505ee4408a1b018a2608479de');
INSERT INTO `abpauditlogs` VALUES ('3a18e388-2881-7f00-0e77-29be55c7bbc4', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:37.192577', 217, '::1', NULL, NULL, NULL, NULL, 'POST', '/connect/token', NULL, '', 200, '{}', '16e297245ce547aba1790c7c525f6baa');
INSERT INTO `abpauditlogs` VALUES ('3a18e388-2930-a01e-c786-eb09ef82e06f', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:36.793629', 791, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/refresh', NULL, '', 200, '{}', 'bfd2e4595bc74ad8839b1582fbb80e10');
INSERT INTO `abpauditlogs` VALUES ('3a18e388-3cf5-8fe0-33b8-f00a81695d9f', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:42.574439', 70, '::1', NULL, NULL, NULL, NULL, 'POST', '/connect/token', NULL, '', 200, '{}', '3716a2402808484ebf636537cf722499');
INSERT INTO `abpauditlogs` VALUES ('3a18e388-3d9f-fba3-d2b6-0ade69ff0a44', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:42.260469', 555, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/refresh', NULL, '', 200, '{}', 'f35b0bb50eee4943a169555cec74cb15');
INSERT INTO `abpauditlogs` VALUES ('3a18e388-4b46-5251-d4e3-245c0b0b7fc8', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:46.248170', 62, '::1', NULL, NULL, NULL, NULL, 'POST', '/connect/token', NULL, '', 200, '{}', '16e5cb4b0b004a60a501539e58702a4a');
INSERT INTO `abpauditlogs` VALUES ('3a18e388-4c09-7641-43c5-6bd9e8465cf5', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:29:45.996939', 508, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/refresh', NULL, '', 200, '{}', 'bd341a98384142cbbfe3f5a9e2b13963');
INSERT INTO `abpauditlogs` VALUES ('3a18e38c-68b7-a610-dc77-153e7a321890', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:34:15.734863', 257, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', '1ab63715a6c3490ab973332712212630');
INSERT INTO `abpauditlogs` VALUES ('3a18e38c-f386-e4e4-a6c9-2c4f1fac8869', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:34:51.436091', 90, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', '52899fbb316041b8bd3c547e9bffd0b1');
INSERT INTO `abpauditlogs` VALUES ('3a18e38c-fae5-a65a-7e63-d4763e27b6cf', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:34:53.354823', 59, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', '1552070025f64a2f91e886d99fd020d0');
INSERT INTO `abpauditlogs` VALUES ('3a18e38c-ffee-c065-1c40-b89e77687061', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:34:54.632245', 70, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', 'f991776f23a441cab2331facc2b5946e');
INSERT INTO `abpauditlogs` VALUES ('3a18e38d-05db-fe17-ae32-6b023dfa9451', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 15:34:56.164374', 55, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', 'f04c7892b08f474ea28a4d7825f0ec1e');
INSERT INTO `abpauditlogs` VALUES ('3a18e3a7-ed28-149e-0e72-a8a89c6fd961', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 16:04:18.311592', 1057, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', '4da4617c840b414cac6763cac850cadb');
INSERT INTO `abpauditlogs` VALUES ('3a18e3a8-bf5d-3aa8-936b-2fa614bdb6a3', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 16:05:13.010395', 171, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', 'dede4c514d494c249012f004ce4d78e2');
INSERT INTO `abpauditlogs` VALUES ('3a18e3ab-0809-bf0b-479a-2eaed548d197', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 16:07:42.634353', 223, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', '3839d450bb1c4304b4d50e0b869d8687');
INSERT INTO `abpauditlogs` VALUES ('3a18e3ab-302e-5a62-1448-a1eeed0057a4', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 16:07:53.005043', 129, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', 'fdf19799a3214d839bed11104fed8ee3');
INSERT INTO `abpauditlogs` VALUES ('3a18e3ab-5a67-f62a-7eac-c78e99411646', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 16:08:03.874166', 69, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', '01e817a6bf3d408ebbc943356ef14bed');
INSERT INTO `abpauditlogs` VALUES ('3a18e3ab-65b7-ac46-da68-badd0c22fc8d', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-26 16:08:06.800572', 39, '::1', NULL, NULL, NULL, 'Apifox/1.0.0 (https://apifox.com)', 'POST', '/connect/token', NULL, '', 200, '{}', 'c8feab25034341749f9cd0886d90a889');
INSERT INTO `abpauditlogs` VALUES ('3a18e75e-9ea7-6a71-2368-aa4af26c72c9', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-27 09:22:12.453794', 31546, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/login', '[\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"登录系统错误\",\r\n    \"details\": null,\r\n    \"data\": {},\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 403, '{}', '3b4f34335e88467daa2a22c827f5f33e');
INSERT INTO `abpauditlogs` VALUES ('3a18e75e-f7c4-8bec-dfba-3f59aa86d19e', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-27 09:22:47.178724', 19641, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/login', '[\r\n  {\r\n    \"code\": null,\r\n    \"message\": \"登录系统错误\",\r\n    \"details\": null,\r\n    \"data\": {},\r\n    \"validationErrors\": null\r\n  }\r\n]', '', 403, '{}', '22bc9b2cdd4f4a289f5e921ffcec35b1');
INSERT INTO `abpauditlogs` VALUES ('3a18e760-5c58-639e-3294-367ae32de928', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-27 09:24:37.964933', 134, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/login', NULL, '', 400, '{}', '34bafb66a60f489fa1f790016e50e798');
INSERT INTO `abpauditlogs` VALUES ('3a18e760-e5c2-98bd-b785-0b594c79ef02', 'Heal.Net.HttpApi.Host', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-27 09:25:13.153617', 129, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/api/basics/accounts/login', NULL, '', 400, '{}', 'af368608947944c291770ee2c23f2b31');
INSERT INTO `abpauditlogs` VALUES ('3a18fbe6-3825-278f-f904-0cde4983e3b6', 'Heal.Net.AuthServer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-03-31 09:03:02.702771', 12261, '::1', NULL, NULL, NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', 'POST', '/Account/Login', NULL, '', 302, '{}', '081d39f3ece349788615f97ed5b29ab6');

-- ----------------------------
-- Table structure for abpbackgroundjobs
-- ----------------------------
DROP TABLE IF EXISTS `abpbackgroundjobs`;
CREATE TABLE `abpbackgroundjobs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `JobName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `JobArgs` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TryCount` smallint NOT NULL DEFAULT 0,
  `CreationTime` datetime(6) NOT NULL,
  `NextTryTime` datetime(6) NOT NULL,
  `LastTryTime` datetime(6) NULL DEFAULT NULL,
  `IsAbandoned` tinyint(1) NOT NULL DEFAULT 0,
  `Priority` tinyint UNSIGNED NOT NULL DEFAULT 15,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpBackgroundJobs_IsAbandoned_NextTryTime`(`IsAbandoned` ASC, `NextTryTime` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpbackgroundjobs
-- ----------------------------

-- ----------------------------
-- Table structure for abpblobcontainers
-- ----------------------------
DROP TABLE IF EXISTS `abpblobcontainers`;
CREATE TABLE `abpblobcontainers`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpBlobContainers_TenantId_Name`(`TenantId` ASC, `Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpblobcontainers
-- ----------------------------

-- ----------------------------
-- Table structure for abpblobs
-- ----------------------------
DROP TABLE IF EXISTS `abpblobs`;
CREATE TABLE `abpblobs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ContainerId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Content` longblob NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpBlobs_ContainerId`(`ContainerId` ASC) USING BTREE,
  INDEX `IX_AbpBlobs_TenantId_ContainerId_Name`(`TenantId` ASC, `ContainerId` ASC, `Name` ASC) USING BTREE,
  CONSTRAINT `FK_AbpBlobs_AbpBlobContainers_ContainerId` FOREIGN KEY (`ContainerId`) REFERENCES `abpblobcontainers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpblobs
-- ----------------------------

-- ----------------------------
-- Table structure for abpclaimtypes
-- ----------------------------
DROP TABLE IF EXISTS `abpclaimtypes`;
CREATE TABLE `abpclaimtypes`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Required` tinyint(1) NOT NULL,
  `IsStatic` tinyint(1) NOT NULL,
  `Regex` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `RegexDescription` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Description` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ValueType` int NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpclaimtypes
-- ----------------------------

-- ----------------------------
-- Table structure for abpentitychanges
-- ----------------------------
DROP TABLE IF EXISTS `abpentitychanges`;
CREATE TABLE `abpentitychanges`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `AuditLogId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ChangeTime` datetime(6) NOT NULL,
  `ChangeType` tinyint UNSIGNED NOT NULL,
  `EntityTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `EntityId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `EntityTypeFullName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpEntityChanges_AuditLogId`(`AuditLogId` ASC) USING BTREE,
  INDEX `IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId`(`TenantId` ASC, `EntityTypeFullName` ASC, `EntityId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpEntityChanges_AbpAuditLogs_AuditLogId` FOREIGN KEY (`AuditLogId`) REFERENCES `abpauditlogs` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpentitychanges
-- ----------------------------

-- ----------------------------
-- Table structure for abpentitypropertychanges
-- ----------------------------
DROP TABLE IF EXISTS `abpentitypropertychanges`;
CREATE TABLE `abpentitypropertychanges`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `EntityChangeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `NewValue` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `OriginalValue` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `PropertyName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PropertyTypeFullName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpEntityPropertyChanges_EntityChangeId`(`EntityChangeId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId` FOREIGN KEY (`EntityChangeId`) REFERENCES `abpentitychanges` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpentitypropertychanges
-- ----------------------------

-- ----------------------------
-- Table structure for abpfeaturegroups
-- ----------------------------
DROP TABLE IF EXISTS `abpfeaturegroups`;
CREATE TABLE `abpfeaturegroups`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpFeatureGroups_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpfeaturegroups
-- ----------------------------
INSERT INTO `abpfeaturegroups` VALUES ('3a18bffc-4a6b-8e9a-efd1-16ea284b23c7', 'SettingManagement', 'L:AbpSettingManagement,Feature:SettingManagementGroup', '{}');

-- ----------------------------
-- Table structure for abpfeatures
-- ----------------------------
DROP TABLE IF EXISTS `abpfeatures`;
CREATE TABLE `abpfeatures`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `GroupName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ParentName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DefaultValue` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsVisibleToClients` tinyint(1) NOT NULL,
  `IsAvailableToHost` tinyint(1) NOT NULL,
  `AllowedProviders` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ValueType` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpFeatures_Name`(`Name` ASC) USING BTREE,
  INDEX `IX_AbpFeatures_GroupName`(`GroupName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpfeatures
-- ----------------------------
INSERT INTO `abpfeatures` VALUES ('3a18bffc-4a9c-633f-1175-f4b46e28d74e', 'SettingManagement', 'SettingManagement.Enable', NULL, 'L:AbpSettingManagement,Feature:SettingManagementEnable', 'L:AbpSettingManagement,Feature:SettingManagementEnableDescription', 'true', 1, 0, NULL, '{\"name\":\"ToggleStringValueType\",\"properties\":{},\"validator\":{\"name\":\"BOOLEAN\",\"properties\":{}}}', '{}');
INSERT INTO `abpfeatures` VALUES ('3a18bffc-4b6e-3d3a-d83f-fc23421b5eb9', 'SettingManagement', 'SettingManagement.AllowChangingEmailSettings', 'SettingManagement.Enable', 'L:AbpSettingManagement,Feature:AllowChangingEmailSettings', NULL, 'false', 1, 0, NULL, '{\"name\":\"ToggleStringValueType\",\"properties\":{},\"validator\":{\"name\":\"BOOLEAN\",\"properties\":{}}}', '{}');

-- ----------------------------
-- Table structure for abpfeaturevalues
-- ----------------------------
DROP TABLE IF EXISTS `abpfeaturevalues`;
CREATE TABLE `abpfeaturevalues`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ProviderKey` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpFeatureValues_Name_ProviderName_ProviderKey`(`Name` ASC, `ProviderName` ASC, `ProviderKey` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpfeaturevalues
-- ----------------------------

-- ----------------------------
-- Table structure for abplinkusers
-- ----------------------------
DROP TABLE IF EXISTS `abplinkusers`;
CREATE TABLE `abplinkusers`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `SourceUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `SourceTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `TargetUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TargetTenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpLinkUsers_SourceUserId_SourceTenantId_TargetUserId_Target~`(`SourceUserId` ASC, `SourceTenantId` ASC, `TargetUserId` ASC, `TargetTenantId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abplinkusers
-- ----------------------------

-- ----------------------------
-- Table structure for abporganizationunitroles
-- ----------------------------
DROP TABLE IF EXISTS `abporganizationunitroles`;
CREATE TABLE `abporganizationunitroles`  (
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `OrganizationUnitId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`OrganizationUnitId`, `RoleId`) USING BTREE,
  INDEX `IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId`(`RoleId` ASC, `OrganizationUnitId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUn~` FOREIGN KEY (`OrganizationUnitId`) REFERENCES `abporganizationunits` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AbpOrganizationUnitRoles_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abporganizationunitroles
-- ----------------------------

-- ----------------------------
-- Table structure for abporganizationunits
-- ----------------------------
DROP TABLE IF EXISTS `abporganizationunits`;
CREATE TABLE `abporganizationunits`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `Code` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DisplayName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EntityVersion` int NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `LastModificationTime` datetime(6) NULL DEFAULT NULL,
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `DeletionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpOrganizationUnits_Code`(`Code` ASC) USING BTREE,
  INDEX `IX_AbpOrganizationUnits_ParentId`(`ParentId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `abporganizationunits` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abporganizationunits
-- ----------------------------

-- ----------------------------
-- Table structure for abppermissiongrants
-- ----------------------------
DROP TABLE IF EXISTS `abppermissiongrants`;
CREATE TABLE `abppermissiongrants`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpPermissionGrants_TenantId_Name_ProviderName_ProviderKey`(`TenantId` ASC, `Name` ASC, `ProviderName` ASC, `ProviderKey` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abppermissiongrants
-- ----------------------------
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-59b0-f9a3-f963df102c99', NULL, 'AbpIdentity.Roles', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-7ebc-7465-20798e61b974', NULL, 'AbpIdentity.Roles.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-a8ab-0ae3-9d2089863c34', NULL, 'AbpIdentity.Roles.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-40e7-b049-c3273ddacec1', NULL, 'AbpIdentity.Roles.ManagePermissions', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-1679-5966-08e153896de6', NULL, 'AbpIdentity.Roles.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-4dd1-24b1-46e62705602d', NULL, 'AbpIdentity.Users', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-d394-8278-45226ff4e1f2', NULL, 'AbpIdentity.Users.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-7301-79ab-0fb4a2f0be54', NULL, 'AbpIdentity.Users.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-2e90-e69c-3477ff92c230', NULL, 'AbpIdentity.Users.ManagePermissions', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-2f5c-fcb6-db53a45a490e', NULL, 'AbpIdentity.Users.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-1d01-dcbf-f2865bcd76ae', NULL, 'AbpIdentity.Users.Update.ManageRoles', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-2a2c-945e-fcd9540d5dd0', NULL, 'AbpTenantManagement.Tenants', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-ee2c-e0fa-02938849c738', NULL, 'AbpTenantManagement.Tenants.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-5873-57f6-deb5adf98c07', NULL, 'AbpTenantManagement.Tenants.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-6132-6965-5f45611419c5', NULL, 'AbpTenantManagement.Tenants.ManageConnectionStrings', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-a421-442c-68fa9babda91', NULL, 'AbpTenantManagement.Tenants.ManageFeatures', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-48c9-bf34-7c6e5d5b883a', NULL, 'AbpTenantManagement.Tenants.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e23-7545-8aa2-974932048b9f', NULL, 'FeatureManagement.ManageHostFeatures', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-638a-a9a4-c04dd7022f7f', NULL, 'SettingManagement.Emailing', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-9eb4-8007-9a5f7ade4975', NULL, 'SettingManagement.Emailing.Test', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a18bffb-6e25-95f8-9190-199b16a2b0cd', NULL, 'SettingManagement.TimeZone', 'R', 'admin');

-- ----------------------------
-- Table structure for abppermissiongroups
-- ----------------------------
DROP TABLE IF EXISTS `abppermissiongroups`;
CREATE TABLE `abppermissiongroups`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpPermissionGroups_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abppermissiongroups
-- ----------------------------
INSERT INTO `abppermissiongroups` VALUES ('3a18bffc-4c29-8a45-77d3-caf4b2dec7c2', 'FeatureManagement', 'L:AbpFeatureManagement,Permission:FeatureManagement', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a18bffc-4c2f-eed9-ba18-7bbd91ab396c', 'SettingManagement', 'L:AbpSettingManagement,Permission:SettingManagement', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a18bffc-4c33-2768-d999-c90198f1fb17', 'AbpTenantManagement', 'L:AbpTenantManagement,Permission:TenantManagement', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a18bffc-4c33-2c6b-c59c-52abc10a2287', 'Heal', 'F:Heal', '{}');
INSERT INTO `abppermissiongroups` VALUES ('3a18bffc-4c33-8651-f520-f61422a6d95c', 'AbpIdentity', 'L:AbpIdentity,Permission:IdentityManagement', '{}');

-- ----------------------------
-- Table structure for abppermissions
-- ----------------------------
DROP TABLE IF EXISTS `abppermissions`;
CREATE TABLE `abppermissions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `GroupName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ParentName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsEnabled` tinyint(1) NOT NULL,
  `MultiTenancySide` tinyint UNSIGNED NOT NULL,
  `Providers` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `StateCheckers` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpPermissions_Name`(`Name` ASC) USING BTREE,
  INDEX `IX_AbpPermissions_GroupName`(`GroupName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abppermissions
-- ----------------------------
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c2c-d5cc-39ee-a21d5d5dcafc', 'FeatureManagement', 'FeatureManagement.ManageHostFeatures', NULL, 'L:AbpFeatureManagement,Permission:FeatureManagement.ManageHostFeatures', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c30-4f4b-f4e7-04bf5b821c24', 'SettingManagement', 'SettingManagement.Emailing', NULL, 'L:AbpSettingManagement,Permission:Emailing', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-0766-5064-58917a8af595', 'SettingManagement', 'SettingManagement.TimeZone', NULL, 'L:AbpSettingManagement,Permission:TimeZone', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-0d85-8bd9-a4ca0d577ad5', 'AbpIdentity', 'AbpIdentity.Roles.Update', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:Edit', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-0f49-e0f8-57fa177c87ea', 'AbpIdentity', 'AbpIdentity.Users', NULL, 'L:AbpIdentity,Permission:UserManagement', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-1227-5011-89c2cac51c6b', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.Create', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:Create', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-1eb7-a401-e0fe817408ab', 'AbpIdentity', 'AbpIdentity.Users.Create', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:Create', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-2d59-6a76-40419d52712a', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.Delete', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:Delete', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-54b3-6b1f-a0380d62ac83', 'AbpTenantManagement', 'AbpTenantManagement.Tenants', NULL, 'L:AbpTenantManagement,Permission:TenantManagement', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-5ae1-5ed3-1898e63cdf2e', 'AbpIdentity', 'AbpIdentity.Roles.ManagePermissions', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:ChangePermissions', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-6439-0704-60c2b2115cb0', 'AbpIdentity', 'AbpIdentity.Roles.Delete', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:Delete', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-696e-8e9c-79351f0ffdb9', 'AbpIdentity', 'AbpIdentity.UserLookup', NULL, 'L:AbpIdentity,Permission:UserLookup', 1, 3, 'C', NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-83d4-1a4a-536ae95c55d5', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.ManageConnectionStrings', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:ManageConnectionStrings', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-a493-90b1-8c28be79d720', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.ManageFeatures', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:ManageFeatures', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-b57c-b60b-e1d19950b808', 'AbpTenantManagement', 'AbpTenantManagement.Tenants.Update', 'AbpTenantManagement.Tenants', 'L:AbpTenantManagement,Permission:Edit', 1, 2, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-b836-fd3b-c81c3d306152', 'AbpIdentity', 'AbpIdentity.Users.ManagePermissions', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:ChangePermissions', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-b8c3-a36f-9a46216ea83f', 'AbpIdentity', 'AbpIdentity.Roles', NULL, 'L:AbpIdentity,Permission:RoleManagement', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-c05b-34ba-866b86ae9dec', 'AbpIdentity', 'AbpIdentity.Users.Update', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:Edit', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-d129-6268-3ba744c72b8f', 'AbpIdentity', 'AbpIdentity.Roles.Create', 'AbpIdentity.Roles', 'L:AbpIdentity,Permission:Create', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-d84d-a54f-408c9c239e0c', 'AbpIdentity', 'AbpIdentity.Users.Update.ManageRoles', 'AbpIdentity.Users.Update', 'L:AbpIdentity,Permission:ManageRoles', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-eb7f-4cc3-47d150b0262a', 'SettingManagement', 'SettingManagement.Emailing.Test', 'SettingManagement.Emailing', 'L:AbpSettingManagement,Permission:EmailingTest', 1, 3, NULL, NULL, '{}');
INSERT INTO `abppermissions` VALUES ('3a18bffc-4c33-f3f0-fdbe-9144b725ef39', 'AbpIdentity', 'AbpIdentity.Users.Delete', 'AbpIdentity.Users', 'L:AbpIdentity,Permission:Delete', 1, 3, NULL, NULL, '{}');

-- ----------------------------
-- Table structure for abproleclaims
-- ----------------------------
DROP TABLE IF EXISTS `abproleclaims`;
CREATE TABLE `abproleclaims`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ClaimType` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimValue` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpRoleClaims_RoleId`(`RoleId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpRoleClaims_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abproleclaims
-- ----------------------------

-- ----------------------------
-- Table structure for abproles
-- ----------------------------
DROP TABLE IF EXISTS `abproles`;
CREATE TABLE `abproles`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsDefault` tinyint(1) NOT NULL,
  `IsStatic` tinyint(1) NOT NULL,
  `IsPublic` tinyint(1) NOT NULL,
  `EntityVersion` int NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpRoles_NormalizedName`(`NormalizedName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abproles
-- ----------------------------
INSERT INTO `abproles` VALUES ('3a18bffb-7709-5094-9981-51c929fb0cdb', NULL, 'admin', 'ADMIN', 0, 1, 1, 2, '2025-03-19 17:49:14.421920', '{}', 'f27e83d0faec4fd9a10e92eda68fb15e');

-- ----------------------------
-- Table structure for abpsecuritylogs
-- ----------------------------
DROP TABLE IF EXISTS `abpsecuritylogs`;
CREATE TABLE `abpsecuritylogs`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ApplicationName` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Identity` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Action` varchar(96) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `TenantName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ClientId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CorrelationId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ClientIpAddress` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `BrowserInfo` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_Action`(`TenantId` ASC, `Action` ASC) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_ApplicationName`(`TenantId` ASC, `ApplicationName` ASC) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_Identity`(`TenantId` ASC, `Identity` ASC) USING BTREE,
  INDEX `IX_AbpSecurityLogs_TenantId_UserId`(`TenantId` ASC, `UserId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsecuritylogs
-- ----------------------------
INSERT INTO `abpsecuritylogs` VALUES ('3a18bffc-8307-c5a6-bbec-b9025109b081', NULL, 'Heal.Net.AuthServer', 'Identity', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-19 17:50:22.978001', '{}', '2b7f7ecd2a274b2e8b0b6a365048707b');
INSERT INTO `abpsecuritylogs` VALUES ('3a18bffc-8ef3-51bc-1541-0b1a89d9fad3', NULL, 'Heal.Net.AuthServer', 'Identity', 'Logout', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-19 17:50:26.035755', '{}', 'fee9ab6132344d659c9c6b6c09f826bb');
INSERT INTO `abpsecuritylogs` VALUES ('3a18c9de-c604-0225-4dc4-1b66db476688', NULL, 'Heal.Net.AuthServer', 'Identity', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-21 15:54:06.208086', '{}', '33a2727cd6f041ad9e3d71f5eddec3cd');
INSERT INTO `abpsecuritylogs` VALUES ('3a18c9de-d0ef-b0e9-0b9b-226bc79c4873', NULL, 'Heal.Net.AuthServer', 'Identity', 'Logout', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-21 15:54:09.007440', '{}', '96801f77142646478e4ddc9b40127e44');
INSERT INTO `abpsecuritylogs` VALUES ('3a18c9e7-12fd-8bd9-4bb0-43aa6f3cc9f9', NULL, 'Heal.Net.AuthServer', 'Identity', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-21 16:03:10.200925', '{}', '2d5d9f5562c64e0d995c52b6bcc10607');
INSERT INTO `abpsecuritylogs` VALUES ('3a18c9e7-1b85-c424-8266-6c0b40d9446a', NULL, 'Heal.Net.AuthServer', 'Identity', 'Logout', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-21 16:03:12.389238', '{}', '0842af5825354926b7e16894bfa84647');
INSERT INTO `abpsecuritylogs` VALUES ('3a18e345-505b-87f6-8cac-9debefab17ee', NULL, 'Heal.Net.AuthServer', 'Identity', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-26 14:16:36.694996', '{}', '216d703e7cf942f8b38ecdddfb125ffe');
INSERT INTO `abpsecuritylogs` VALUES ('3a18e383-ceaf-cd8e-24bb-ab85c14bf873', NULL, 'Heal.Net.AuthServer', 'OpenIddict', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, 'HealNetApp', NULL, '::1', 'Apifox/1.0.0 (https://apifox.com)', '2025-03-26 15:24:52.267433', '{}', 'b165d6687e2441539fc617d61538ad89');
INSERT INTO `abpsecuritylogs` VALUES ('3a18e387-e1cc-be3a-8a30-6bd5739d9809', NULL, 'Heal.Net.AuthServer', 'OpenIddict', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, 'HealNetApp', NULL, '::1', NULL, '2025-03-26 15:29:19.306479', '{}', 'd9593efe9f0241d69eb4bc65a568ad66');
INSERT INTO `abpsecuritylogs` VALUES ('3a18e38c-6830-e940-25af-f6121fbd7c0a', NULL, 'Heal.Net.AuthServer', 'OpenIddict', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, 'HealNetApp', NULL, '::1', 'Apifox/1.0.0 (https://apifox.com)', '2025-03-26 15:34:15.856761', '{}', '8d60de4b0a034d96b1149fecef6c1466');
INSERT INTO `abpsecuritylogs` VALUES ('3a18e3a7-ea4e-3504-022b-e01848801c5f', NULL, 'Heal.Net.AuthServer', 'OpenIddict', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, 'HealNetApp', NULL, '::1', 'Apifox/1.0.0 (https://apifox.com)', '2025-03-26 16:04:18.638317', '{}', '1a2b74bc2fd24ab9bcb9044a16724058');
INSERT INTO `abpsecuritylogs` VALUES ('3a18e3ab-07a2-0a01-ef7e-2472f4d55c2c', NULL, 'Heal.Net.AuthServer', 'OpenIddict', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, 'HealNetApp', NULL, '::1', 'Apifox/1.0.0 (https://apifox.com)', '2025-03-26 16:07:42.754147', '{}', 'c12e7462186a4fe5a5282bb42939881e');
INSERT INTO `abpsecuritylogs` VALUES ('3a18fbe6-3115-eb61-80be-ddcddc40c2bf', NULL, 'Heal.Net.AuthServer', 'Identity', 'LoginSucceeded', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-31 09:03:13.161798', '{}', 'e5c14662187f4b428f4f9aa5481149da');
INSERT INTO `abpsecuritylogs` VALUES ('3a18fbe6-ca98-96f9-1ca0-60f739a45b59', NULL, 'Heal.Net.AuthServer', 'Identity', 'Logout', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'admin', NULL, NULL, NULL, '::1', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36', '2025-03-31 09:03:52.470719', '{}', '5506015a78bd429d9909b9f841da7973');

-- ----------------------------
-- Table structure for abpsessions
-- ----------------------------
DROP TABLE IF EXISTS `abpsessions`;
CREATE TABLE `abpsessions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `SessionId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Device` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DeviceInfo` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ClientId` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IpAddresses` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `SignedIn` datetime(6) NOT NULL,
  `LastAccessed` datetime(6) NULL DEFAULT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpSessions_Device`(`Device` ASC) USING BTREE,
  INDEX `IX_AbpSessions_SessionId`(`SessionId` ASC) USING BTREE,
  INDEX `IX_AbpSessions_TenantId_UserId`(`TenantId` ASC, `UserId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsessions
-- ----------------------------

-- ----------------------------
-- Table structure for abpsettingdefinitions
-- ----------------------------
DROP TABLE IF EXISTS `abpsettingdefinitions`;
CREATE TABLE `abpsettingdefinitions`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DisplayName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DefaultValue` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsVisibleToClients` tinyint(1) NOT NULL,
  `Providers` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsInherited` tinyint(1) NOT NULL,
  `IsEncrypted` tinyint(1) NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpSettingDefinitions_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsettingdefinitions
-- ----------------------------
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c2c-e13d-cb20-a5d8b69824ba', 'Abp.Localization.DefaultLanguage', 'L:AbpLocalization,DisplayName:Abp.Localization.DefaultLanguage', 'L:AbpLocalization,Description:Abp.Localization.DefaultLanguage', 'en', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-014c-c70f-0794820e8041', 'Abp.Mailing.Smtp.Domain', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Domain', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Domain', NULL, 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-0718-9b8a-c105604e97e6', 'Abp.Identity.Lockout.MaxFailedAccessAttempts', 'L:AbpIdentity,DisplayName:Abp.Identity.Lockout.MaxFailedAccessAttempts', 'L:AbpIdentity,Description:Abp.Identity.Lockout.MaxFailedAccessAttempts', '5', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-08f4-336f-7090fd16176f', 'Abp.Identity.User.IsUserNameUpdateEnabled', 'L:AbpIdentity,DisplayName:Abp.Identity.User.IsUserNameUpdateEnabled', 'L:AbpIdentity,Description:Abp.Identity.User.IsUserNameUpdateEnabled', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-0d87-4ff7-6ef679e73558', 'Abp.Mailing.Smtp.UserName', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.UserName', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.UserName', NULL, 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-1438-4fa4-a3e46865ad09', 'Abp.Account.IsSelfRegistrationEnabled', 'L:AbpAccount,DisplayName:Abp.Account.IsSelfRegistrationEnabled', 'L:AbpAccount,Description:Abp.Account.IsSelfRegistrationEnabled', 'true', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-22f9-083b-de2503fffeb3', 'Abp.Mailing.Smtp.Port', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Port', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Port', '25', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-233b-602f-c9f3cb0b0eb7', 'Abp.Identity.Password.ForceUsersToPeriodicallyChangePassword', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.ForceUsersToPeriodicallyChangePassword', 'L:AbpIdentity,Description:Abp.Identity.Password.ForceUsersToPeriodicallyChangePassword', 'False', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-2520-eff3-a3563b99e244', 'Abp.Identity.Password.RequireNonAlphanumeric', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireNonAlphanumeric', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireNonAlphanumeric', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-27b1-b67f-182b6e752550', 'Abp.Identity.SignIn.EnablePhoneNumberConfirmation', 'L:AbpIdentity,DisplayName:Abp.Identity.SignIn.EnablePhoneNumberConfirmation', 'L:AbpIdentity,Description:Abp.Identity.SignIn.EnablePhoneNumberConfirmation', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-28e2-0763-656c9945b34c', 'Abp.Account.EnableLocalLogin', 'L:AbpAccount,DisplayName:Abp.Account.EnableLocalLogin', 'L:AbpAccount,Description:Abp.Account.EnableLocalLogin', 'true', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-38e8-ce1e-af2ab5c9a4ea', 'Abp.Mailing.Smtp.Password', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Password', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Password', NULL, 0, NULL, 1, 1, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-3a83-34c2-b960d25d1509', 'Abp.Identity.SignIn.RequireConfirmedPhoneNumber', 'L:AbpIdentity,DisplayName:Abp.Identity.SignIn.RequireConfirmedPhoneNumber', 'L:AbpIdentity,Description:Abp.Identity.SignIn.RequireConfirmedPhoneNumber', 'False', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-4164-cc85-29e2b547148b', 'Abp.Mailing.Smtp.Host', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.Host', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.Host', '127.0.0.1', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-50ed-a03f-92965ca9eced', 'Abp.Identity.Lockout.AllowedForNewUsers', 'L:AbpIdentity,DisplayName:Abp.Identity.Lockout.AllowedForNewUsers', 'L:AbpIdentity,Description:Abp.Identity.Lockout.AllowedForNewUsers', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-590d-4b7f-5c9d901839d8', 'Abp.Identity.SignIn.RequireConfirmedEmail', 'L:AbpIdentity,DisplayName:Abp.Identity.SignIn.RequireConfirmedEmail', 'L:AbpIdentity,Description:Abp.Identity.SignIn.RequireConfirmedEmail', 'False', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-5d7b-0d5b-e1d6a3a2f250', 'Abp.Identity.User.IsEmailUpdateEnabled', 'L:AbpIdentity,DisplayName:Abp.Identity.User.IsEmailUpdateEnabled', 'L:AbpIdentity,Description:Abp.Identity.User.IsEmailUpdateEnabled', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-70ca-bce1-d9f952259e7e', 'Abp.Identity.Password.RequiredUniqueChars', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequiredUniqueChars', 'L:AbpIdentity,Description:Abp.Identity.Password.RequiredUniqueChars', '1', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-7258-cd6c-c5da75e8d07f', 'Abp.Mailing.DefaultFromDisplayName', 'L:AbpEmailing,DisplayName:Abp.Mailing.DefaultFromDisplayName', 'L:AbpEmailing,Description:Abp.Mailing.DefaultFromDisplayName', 'ABP application', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-7644-8f64-bf0202546363', 'Abp.Mailing.DefaultFromAddress', 'L:AbpEmailing,DisplayName:Abp.Mailing.DefaultFromAddress', 'L:AbpEmailing,Description:Abp.Mailing.DefaultFromAddress', 'noreply@abp.io', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-8e6b-99c4-b6ca4ea7016b', 'Abp.Timing.TimeZone', 'L:AbpTiming,DisplayName:Abp.Timing.Timezone', 'L:AbpTiming,Description:Abp.Timing.Timezone', 'UTC', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-ab4b-dfc3-25321ea156c1', 'Abp.Identity.Password.RequiredLength', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequiredLength', 'L:AbpIdentity,Description:Abp.Identity.Password.RequiredLength', '6', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-bd01-6b7e-4248a7bef3a9', 'Abp.Identity.OrganizationUnit.MaxUserMembershipCount', 'L:AbpIdentity,Identity.OrganizationUnit.MaxUserMembershipCount', 'L:AbpIdentity,Identity.OrganizationUnit.MaxUserMembershipCount', '2147483647', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-c0ca-5375-402d7e20d45a', 'Abp.Identity.Lockout.LockoutDuration', 'L:AbpIdentity,DisplayName:Abp.Identity.Lockout.LockoutDuration', 'L:AbpIdentity,Description:Abp.Identity.Lockout.LockoutDuration', '300', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-cd1c-986a-0edd345c7b45', 'Abp.Identity.Password.RequireLowercase', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireLowercase', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireLowercase', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-d0f2-08bb-c13355b0bdd2', 'Abp.Identity.Password.RequireUppercase', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireUppercase', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireUppercase', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-d5ca-1f0d-fa7e0a64f951', 'Abp.Identity.Password.PasswordChangePeriodDays', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.PasswordChangePeriodDays', 'L:AbpIdentity,Description:Abp.Identity.Password.PasswordChangePeriodDays', '0', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-e2d0-93b8-d2d0ee605de0', 'Abp.Mailing.Smtp.UseDefaultCredentials', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.UseDefaultCredentials', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.UseDefaultCredentials', 'true', 0, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-ea9c-42cc-9f74ef851023', 'Abp.Identity.Password.RequireDigit', 'L:AbpIdentity,DisplayName:Abp.Identity.Password.RequireDigit', 'L:AbpIdentity,Description:Abp.Identity.Password.RequireDigit', 'True', 1, NULL, 1, 0, '{}');
INSERT INTO `abpsettingdefinitions` VALUES ('3a18bffc-4c30-f744-92dd-5d86168129c5', 'Abp.Mailing.Smtp.EnableSsl', 'L:AbpEmailing,DisplayName:Abp.Mailing.Smtp.EnableSsl', 'L:AbpEmailing,Description:Abp.Mailing.Smtp.EnableSsl', 'false', 0, NULL, 1, 0, '{}');

-- ----------------------------
-- Table structure for abpsettings
-- ----------------------------
DROP TABLE IF EXISTS `abpsettings`;
CREATE TABLE `abpsettings`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ProviderKey` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_AbpSettings_Name_ProviderName_ProviderKey`(`Name` ASC, `ProviderName` ASC, `ProviderKey` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpsettings
-- ----------------------------

-- ----------------------------
-- Table structure for abptenantconnectionstrings
-- ----------------------------
DROP TABLE IF EXISTS `abptenantconnectionstrings`;
CREATE TABLE `abptenantconnectionstrings`  (
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`TenantId`, `Name`) USING BTREE,
  CONSTRAINT `FK_AbpTenantConnectionStrings_AbpTenants_TenantId` FOREIGN KEY (`TenantId`) REFERENCES `abptenants` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abptenantconnectionstrings
-- ----------------------------

-- ----------------------------
-- Table structure for abptenants
-- ----------------------------
DROP TABLE IF EXISTS `abptenants`;
CREATE TABLE `abptenants`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NormalizedName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EntityVersion` int NOT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `LastModificationTime` datetime(6) NULL DEFAULT NULL,
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `DeletionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpTenants_Name`(`Name` ASC) USING BTREE,
  INDEX `IX_AbpTenants_NormalizedName`(`NormalizedName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abptenants
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserclaims
-- ----------------------------
DROP TABLE IF EXISTS `abpuserclaims`;
CREATE TABLE `abpuserclaims`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ClaimType` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimValue` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpUserClaims_UserId`(`UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserClaims_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserclaims
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserdelegations
-- ----------------------------
DROP TABLE IF EXISTS `abpuserdelegations`;
CREATE TABLE `abpuserdelegations`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `SourceUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TargetUserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `StartTime` datetime(6) NOT NULL,
  `EndTime` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserdelegations
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserlogins
-- ----------------------------
DROP TABLE IF EXISTS `abpuserlogins`;
CREATE TABLE `abpuserlogins`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `LoginProvider` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `ProviderKey` varchar(196) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`UserId`, `LoginProvider`) USING BTREE,
  INDEX `IX_AbpUserLogins_LoginProvider_ProviderKey`(`LoginProvider` ASC, `ProviderKey` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserLogins_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserlogins
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserorganizationunits
-- ----------------------------
DROP TABLE IF EXISTS `abpuserorganizationunits`;
CREATE TABLE `abpuserorganizationunits`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `OrganizationUnitId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`OrganizationUnitId`, `UserId`) USING BTREE,
  INDEX `IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId`(`UserId` ASC, `OrganizationUnitId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUn~` FOREIGN KEY (`OrganizationUnitId`) REFERENCES `abporganizationunits` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AbpUserOrganizationUnits_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserorganizationunits
-- ----------------------------

-- ----------------------------
-- Table structure for abpuserroles
-- ----------------------------
DROP TABLE IF EXISTS `abpuserroles`;
CREATE TABLE `abpuserroles`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`UserId`, `RoleId`) USING BTREE,
  INDEX `IX_AbpUserRoles_RoleId_UserId`(`RoleId` ASC, `UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpUserRoles_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AbpUserRoles_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpuserroles
-- ----------------------------
INSERT INTO `abpuserroles` VALUES ('3a18bffb-7381-0f8c-30e4-0855af61c762', '3a18bffb-7709-5094-9981-51c929fb0cdb', NULL);

-- ----------------------------
-- Table structure for abpusers
-- ----------------------------
DROP TABLE IF EXISTS `abpusers`;
CREATE TABLE `abpusers`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Surname` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL DEFAULT 0,
  `PasswordHash` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `SecurityStamp` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsExternal` tinyint(1) NOT NULL DEFAULT 0,
  `PhoneNumber` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL DEFAULT 0,
  `IsActive` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL DEFAULT 0,
  `LockoutEnd` datetime(6) NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL DEFAULT 0,
  `AccessFailedCount` int NOT NULL DEFAULT 0,
  `ShouldChangePasswordOnNextLogin` tinyint(1) NOT NULL,
  `EntityVersion` int NOT NULL,
  `LastPasswordChangeTime` datetime(6) NULL DEFAULT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `LastModificationTime` datetime(6) NULL DEFAULT NULL,
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `DeletionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AbpUsers_Email`(`Email` ASC) USING BTREE,
  INDEX `IX_AbpUsers_NormalizedEmail`(`NormalizedEmail` ASC) USING BTREE,
  INDEX `IX_AbpUsers_NormalizedUserName`(`NormalizedUserName` ASC) USING BTREE,
  INDEX `IX_AbpUsers_UserName`(`UserName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpusers
-- ----------------------------
INSERT INTO `abpusers` VALUES ('3a18bffb-7381-0f8c-30e4-0855af61c762', NULL, 'admin', 'ADMIN', 'admin', NULL, 'admin@abp.io', 'ADMIN@ABP.IO', 0, 'AQAAAAIAAYagAAAAEKhomxCukcPEWbECiMnG4012zg51/WD2c/grffr0bHId4xl+37A24SgvFIZLUYch9w==', 'RRRW4XABWOFMIZBZQNJKCTMSNYXK4GVK', 0, NULL, 0, 1, 0, NULL, 1, 0, 0, 2, '2025-03-19 09:49:13.568761', '{}', '12f712d8a0504d54820fd0d690b18266', '2025-03-19 17:49:13.749175', NULL, '2025-03-19 17:49:14.746945', NULL, 0, NULL, NULL);

-- ----------------------------
-- Table structure for abpusertokens
-- ----------------------------
DROP TABLE IF EXISTS `abpusertokens`;
CREATE TABLE `abpusertokens`  (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `LoginProvider` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TenantId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`UserId`, `LoginProvider`, `Name`) USING BTREE,
  CONSTRAINT `FK_AbpUserTokens_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpusertokens
-- ----------------------------

-- ----------------------------
-- Table structure for openiddictapplications
-- ----------------------------
DROP TABLE IF EXISTS `openiddictapplications`;
CREATE TABLE `openiddictapplications`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ApplicationType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ClientId` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ClientSecret` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ConsentType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `DisplayNames` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `JsonWebKeySet` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Permissions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PostLogoutRedirectUris` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `RedirectUris` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Requirements` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Settings` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClientUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `LogoUri` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `LastModificationTime` datetime(6) NULL DEFAULT NULL,
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `DeletionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictApplications_ClientId`(`ClientId` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of openiddictapplications
-- ----------------------------
INSERT INTO `openiddictapplications` VALUES ('3a18bffb-7bea-7b7a-657a-f8a54fab1c52', 'web', 'Heal_App', NULL, 'public', 'implicit', 'Console Test / Angular Application', NULL, NULL, '[\"gt:authorization_code\",\"rst:code\",\"ept:authorization\",\"ept:token\",\"ept:revocation\",\"ept:introspection\",\"gt:password\",\"gt:client_credentials\",\"gt:refresh_token\",\"gt:LinkLogin\",\"gt:Impersonation\",\"scp:address\",\"scp:email\",\"scp:phone\",\"scp:profile\",\"scp:roles\",\"scp:Heal\",\"scp:HealNetApp\"]', '[]', NULL, '[]', NULL, NULL, NULL, '/images/clients/angular.svg', '{}', '163559c997cf4a6498ac0fca51f5fde8', '2025-03-19 17:49:15.734714', NULL, '2025-03-26 14:52:31.662791', NULL, 0, NULL, NULL);
INSERT INTO `openiddictapplications` VALUES ('3a18bffb-7d0a-e3f0-5599-82c540ffda1f', 'web', 'Heal_Swagger', NULL, 'public', 'implicit', 'Swagger Application', NULL, NULL, '[\"ept:end_session\",\"gt:authorization_code\",\"rst:code\",\"ept:authorization\",\"ept:token\",\"ept:revocation\",\"ept:introspection\",\"scp:address\",\"scp:email\",\"scp:phone\",\"scp:profile\",\"scp:roles\",\"scp:Heal\",\"scp:HealNetApp\"]', NULL, NULL, '[\"https://localhost:44364/swagger/oauth2-redirect.html\"]', NULL, NULL, 'https://localhost:44364/swagger', '/images/clients/swagger.svg', '{}', '75f15a9abd9d46c685d2f9b15250206d', '2025-03-19 17:49:15.919138', NULL, '2025-03-26 14:52:31.686478', NULL, 0, NULL, NULL);
INSERT INTO `openiddictapplications` VALUES ('3a18e366-3938-11aa-8d2f-ea227be2677f', 'web', 'HealNetApp', 'AQAAAAEAACcQAAAAENNIOJ/MgVsXOSdWxRxeK2H0jrca7d2xuNH+fkdkCa48NEpSFhEn0n/dsU667OjRJQ==', 'confidential', 'explicit', 'HealNetApp Application', NULL, NULL, '[\"rst:code id_token\",\"ept:end_session\",\"gt:authorization_code\",\"rst:code\",\"ept:authorization\",\"ept:token\",\"ept:revocation\",\"ept:introspection\",\"gt:implicit\",\"rst:id_token\",\"gt:password\",\"gt:client_credentials\",\"gt:refresh_token\",\"gt:urn:ietf:params:oauth:grant-type:device_code\",\"ept:device_authorization\",\"gt:heal_net_password\",\"scp:address\",\"scp:email\",\"scp:phone\",\"scp:profile\",\"scp:roles\",\"scp:Heal\",\"scp:HealNetApp\"]', '[\"https://localhost:44364/signout-callback-oidc\"]', NULL, '[\"https://localhost:44364/signin-oidc\"]', NULL, NULL, NULL, NULL, '{}', '95a936399f3d4ba1872467ccf4d754a0', '2025-03-26 14:52:33.504225', NULL, '2025-03-26 16:08:06.825642', NULL, 0, NULL, NULL);

-- ----------------------------
-- Table structure for openiddictauthorizations
-- ----------------------------
DROP TABLE IF EXISTS `openiddictauthorizations`;
CREATE TABLE `openiddictauthorizations`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ApplicationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `CreationDate` datetime(6) NULL DEFAULT NULL,
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Scopes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Subject` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type`(`ApplicationId` ASC, `Status` ASC, `Subject` ASC, `Type` ASC) USING BTREE,
  CONSTRAINT `FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `openiddictapplications` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of openiddictauthorizations
-- ----------------------------
INSERT INTO `openiddictauthorizations` VALUES ('3a18e383-d567-795a-4d3e-8fef74ab7160', '3a18e366-3938-11aa-8d2f-ea227be2677f', '2025-03-26 07:24:53.920933', NULL, '[\"HealNetApp\",\"offline_access\"]', 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'ad-hoc', '{}', '0214ebd8051d4e8a92c03449d27e763c');
INSERT INTO `openiddictauthorizations` VALUES ('3a18e387-e2de-56f4-9222-7dc91f0e20e6', '3a18e366-3938-11aa-8d2f-ea227be2677f', '2025-03-26 07:29:19.579612', NULL, '[\"HealNetApp\",\"offline_access\"]', 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'ad-hoc', '{}', 'ccf7199f525d4faeb4c8ab6417bc3725');
INSERT INTO `openiddictauthorizations` VALUES ('3a18e38c-6897-aa95-f5cd-65ebdcfbb089', '3a18e366-3938-11aa-8d2f-ea227be2677f', '2025-03-26 07:34:15.959403', NULL, '[\"HealNetApp\",\"offline_access\"]', 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'ad-hoc', '{}', 'cf19fbb735214d018f61294f1530ac9e');
INSERT INTO `openiddictauthorizations` VALUES ('3a18e3a7-ecfd-7ce7-adcd-308152721eab', '3a18e366-3938-11aa-8d2f-ea227be2677f', '2025-03-26 08:04:19.325305', NULL, '[\"HealNetApp\",\"offline_access\"]', 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'ad-hoc', '{}', '3300411e59904b7eadf7ba1054a27f6a');
INSERT INTO `openiddictauthorizations` VALUES ('3a18e3ab-07e8-8398-0154-435fbf6e006d', '3a18e366-3938-11aa-8d2f-ea227be2677f', '2025-03-26 08:07:42.824316', NULL, '[\"HealNetApp\",\"offline_access\"]', 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'ad-hoc', '{}', '97fa28d732d14492bd6772f881fd2715');

-- ----------------------------
-- Table structure for openiddictscopes
-- ----------------------------
DROP TABLE IF EXISTS `openiddictscopes`;
CREATE TABLE `openiddictscopes`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Descriptions` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `DisplayNames` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Resources` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `LastModificationTime` datetime(6) NULL DEFAULT NULL,
  `LastModifierId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `DeleterId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `DeletionTime` datetime(6) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictScopes_Name`(`Name` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of openiddictscopes
-- ----------------------------
INSERT INTO `openiddictscopes` VALUES ('3a18bffb-7b19-5b9f-1e06-a75410c44ca8', NULL, NULL, 'Heal API', NULL, 'Heal', NULL, '[\"Heal\"]', '{}', '48215a893ca048d9aa81fb99f8b67450', '2025-03-19 17:49:15.488281', NULL, NULL, NULL, 0, NULL, NULL);
INSERT INTO `openiddictscopes` VALUES ('3a18e366-2f5f-697b-9d7e-921393c1be7f', NULL, NULL, 'HealNetApp API', NULL, 'HealNetApp', NULL, '[\"HealNetApp\"]', '{}', '9e823d8ba5544ff09a2fe1627ad3a1f2', '2025-03-26 14:52:31.011558', NULL, NULL, NULL, 0, NULL, NULL);

-- ----------------------------
-- Table structure for openiddicttokens
-- ----------------------------
DROP TABLE IF EXISTS `openiddicttokens`;
CREATE TABLE `openiddicttokens`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ApplicationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `AuthorizationId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL,
  `CreationDate` datetime(6) NULL DEFAULT NULL,
  `ExpirationDate` datetime(6) NULL DEFAULT NULL,
  `Payload` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `RedemptionDate` datetime(6) NULL DEFAULT NULL,
  `ReferenceId` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Subject` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ExtraProperties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ConcurrencyStamp` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_OpenIddictTokens_ApplicationId_Status_Subject_Type`(`ApplicationId` ASC, `Status` ASC, `Subject` ASC, `Type` ASC) USING BTREE,
  INDEX `IX_OpenIddictTokens_AuthorizationId`(`AuthorizationId` ASC) USING BTREE,
  INDEX `IX_OpenIddictTokens_ReferenceId`(`ReferenceId` ASC) USING BTREE,
  CONSTRAINT `FK_OpenIddictTokens_OpenIddictApplications_ApplicationId` FOREIGN KEY (`ApplicationId`) REFERENCES `openiddictapplications` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId` FOREIGN KEY (`AuthorizationId`) REFERENCES `openiddictauthorizations` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of openiddicttokens
-- ----------------------------
INSERT INTO `openiddicttokens` VALUES ('3a18e3a7-ed0e-22c3-88fe-230ccc775d16', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3a7-ecfd-7ce7-adcd-308152721eab', '2025-03-26 08:04:19.000000', '2025-03-26 09:04:19.000000', NULL, NULL, NULL, NULL, 'revoked', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'access_token', '{}', 'cb2b758a6d894211b7a58a748c369b00');
INSERT INTO `openiddicttokens` VALUES ('3a18e3a7-ed1c-1a3a-08fa-a77d62e5317a', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3a7-ecfd-7ce7-adcd-308152721eab', '2025-03-26 08:04:19.000000', '2025-04-09 08:04:19.000000', NULL, NULL, '2025-03-26 08:05:13.103468', NULL, 'revoked', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'refresh_token', '{}', '089956983db04826aa974b86d02bb938');
INSERT INTO `openiddicttokens` VALUES ('3a18e3a8-bf29-67f0-9dc6-b79054ce1246', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3a7-ecfd-7ce7-adcd-308152721eab', '2025-03-26 08:05:13.000000', '2025-03-26 09:05:13.000000', NULL, NULL, NULL, NULL, 'revoked', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'access_token', '{}', '64fda4fd84da476c9313bae6d482b2f4');
INSERT INTO `openiddicttokens` VALUES ('3a18e3a8-bf49-5120-186d-f437330b039e', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3a7-ecfd-7ce7-adcd-308152721eab', '2025-03-26 08:05:13.000000', '2025-04-09 08:05:13.000000', NULL, NULL, NULL, NULL, 'revoked', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'refresh_token', '{}', '5661b741f1544a1697560fd2afbb6496');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-07f1-6f4d-41ff-bd1d82b2fa7d', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:07:42.000000', '2025-03-26 09:07:42.000000', NULL, NULL, NULL, NULL, 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'access_token', '{}', 'f7b5fdb85a4a433ca5ccd1b2d3907620');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-07fd-3a41-90c3-d24398fdeca4', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:07:42.000000', '2025-04-09 08:07:42.000000', NULL, NULL, '2025-03-26 08:07:53.070718', NULL, 'redeemed', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'refresh_token', '{}', '731283b2b1f048e2b0c4387218fc1583');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-301b-9648-81f5-2d23cf33769f', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:07:53.000000', '2025-03-26 09:07:53.000000', NULL, NULL, NULL, NULL, 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'access_token', '{}', 'f2afa05c12d3479ea04e682a7ab0fb0e');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-3024-f2d2-82ad-a57dd08ea091', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:07:53.000000', '2025-04-09 08:07:53.000000', NULL, NULL, NULL, NULL, 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'refresh_token', '{}', '26b4815c2cce4ec88ff8ba010049d447');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-5a4f-2db6-751d-b9582d9d53cd', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:08:03.000000', '2025-03-26 09:08:03.000000', NULL, NULL, NULL, NULL, 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'access_token', '{}', '0c39d9f20fd04457b1b0e11655b775cf');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-5a5b-4726-db2c-ce32344fea24', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:08:03.000000', '2025-04-09 08:08:03.000000', NULL, NULL, NULL, NULL, 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'refresh_token', '{}', '056952e6168f4eb793697e73bde3453e');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-65a7-0049-685f-489a447a458a', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:08:06.000000', '2025-03-26 09:08:06.000000', NULL, NULL, NULL, NULL, 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'access_token', '{}', '282368dbbe6c4e80a0b4468ca9277f8a');
INSERT INTO `openiddicttokens` VALUES ('3a18e3ab-65ae-264c-659d-483a3a501743', '3a18e366-3938-11aa-8d2f-ea227be2677f', '3a18e3ab-07e8-8398-0154-435fbf6e006d', '2025-03-26 08:08:06.000000', '2025-04-09 08:08:06.000000', NULL, NULL, NULL, NULL, 'valid', '3a18bffb-7381-0f8c-30e4-0855af61c762', 'refresh_token', '{}', '37cc6897907140c9b825073e8001b2ee');

SET FOREIGN_KEY_CHECKS = 1;
