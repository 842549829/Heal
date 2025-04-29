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

 Date: 29/04/2025 13:41:31
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

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
INSERT INTO `abppermissions` VALUES ('3a198c1d-8d1e-2b33-11af-7c509118d59a', 'Net', 'Net.Authorizations.Roles.Create', 'Net.Authorizations.Roles', 'L:Heal,DisplayName:Create', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"create\"}');
INSERT INTO `abppermissions` VALUES ('3a198c1d-8d1e-76c8-f1f5-eb90dc12dbaa', 'Net', 'Net.Authorizations.Roles.Delete', 'Net.Authorizations.Roles', 'L:Heal,DisplayName:Delete', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"delete\"}');
INSERT INTO `abppermissions` VALUES ('3a198c1d-8d1e-770d-9b08-9eab52d34e9f', 'Net', 'Net.Authorizations.Roles.Update', 'Net.Authorizations.Roles', 'L:Heal,DisplayName:Edit', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"edit\"}');
INSERT INTO `abppermissions` VALUES ('3a198c1d-8d1e-9fc4-6aa3-a9e8555d7ef0', 'Net', 'Net.Authorizations.Roles', 'Net.Authorizations', 'L:Heal,DisplayName:RoleManagement', 1, 3, 'R', NULL, '{\"type\":2,\"path\":\"role\",\"component\":\"views/Authorization/Role/Role\",\"name\":\"Role\",\"title\":\"router.role\"}');
INSERT INTO `abppermissions` VALUES ('3a198c1d-8d1e-e931-e248-a2a40b01bee7', 'Net', 'Net.Authorizations', NULL, 'L:Heal,DisplayName:Authorization', 1, 3, 'R', NULL, '{\"type\":2,\"path\":\"/authorization\",\"component\":\"#\",\"redirect\":\"/authorization/user\",\"name\":\"Authorization\",\"title\":\"router.authorization\",\"icon\":\"vi-eos-icons:role-binding\",\"alwaysShow\":true}');
INSERT INTO `abppermissions` VALUES ('3a198c6e-216d-31a8-bfcd-b71a4a8ed045', 'Net', 'Net.Authorizations.Users.Delete', 'Net.Authorizations.Users', 'L:Heal,DisplayName:Delete', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"delete\"}');
INSERT INTO `abppermissions` VALUES ('3a198c6e-216d-5592-994b-06dcf977e629', 'Net', 'Net.Authorizations.Users.Create', 'Net.Authorizations.Users', 'L:Heal,DisplayName:Create', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"create\"}');
INSERT INTO `abppermissions` VALUES ('3a198c6e-216d-dc16-0eb6-8efaa475f592', 'Net', 'Net.Authorizations.Users.Update', 'Net.Authorizations.Users', 'L:Heal,DisplayName:Edit', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"edit\"}');
INSERT INTO `abppermissions` VALUES ('3a198c6e-216d-e7f3-e4f3-f1cd458aeefb', 'Net', 'Net.Authorizations.Users', 'Net.Authorizations', 'L:Heal,DisplayName:UserManagement', 1, 3, 'R', NULL, '{\"type\":2,\"path\":\"user\",\"component\":\"views/Authorization/User/User\",\"name\":\"User\",\"title\":\"router.user\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab42-4410-74ee-bf942e63a27e', 'Net', 'Net.Authorizations.Modules.Update', 'Net.Authorizations.Modules', 'L:Heal,DisplayName:Edit', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"edit\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab42-8ace-8d18-74f67dd8a6c4', 'Net', 'Net.Authorizations.Modules.Create', 'Net.Authorizations.Modules', 'L:Heal,DisplayName:Create', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"create\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab42-9ab2-66ae-48c045f1918c', 'Net', 'Net.Authorizations.Modules', 'Net.Authorizations', 'L:Heal,DisplayName:ModuleManagement', 1, 3, 'R', NULL, '{\"type\":2,\"path\":\"module\",\"component\":\"views/Authorization/Module/Module\",\"name\":\"Module\",\"title\":\"module.module\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab43-6b8b-b3ce-cb30252368fa', 'Net', 'Net.Authorizations.Menus.Update', 'Net.Authorizations.Menus', 'L:Heal,DisplayName:Edit', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"edit\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab43-990a-f1c0-96a9c1f53927', 'Net', 'Net.Authorizations.Menus', 'Net.Authorizations', 'L:Heal,DisplayName:MenuManagement', 1, 3, 'R', NULL, '{\"type\":2,\"path\":\"menu\",\"component\":\"views/Authorization/Menu/Menu\",\"name\":\"Menu\",\"title\":\"menu.menu\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab43-9b24-b6d3-0f0f031d16a2', 'Net', 'Net.Authorizations.Modules.Delete', 'Net.Authorizations.Modules', 'L:Heal,DisplayName:Delete', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"delete\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab43-a90d-f216-a5f072ca54b0', 'Net', 'Net.Authorizations.Menus.Create', 'Net.Authorizations.Menus', 'L:Heal,DisplayName:Create', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"create\"}');
INSERT INTO `abppermissions` VALUES ('3a19923b-ab43-daa6-0bdd-28c71d8b44f3', 'Net', 'Net.Authorizations.Menus.Delete', 'Net.Authorizations.Menus', 'L:Heal,DisplayName:Delete', 1, 3, 'R', NULL, '{\"type\":3,\"path\":\"delete\"}');

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
INSERT INTO `abppermissiongroups` VALUES ('3a198c1d-8d1d-1b50-f786-7bc015adc3c0', 'Net', 'L:Heal,F:Net', '{\"type\":1,\"hidden\":false,\"tag\":5}');

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
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-faa6-3d23-ca104cbfe1c1', NULL, 'Net', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c1d-9b7a-5730-1637-2c9fc3dafc00', NULL, 'Net.Authorizations', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb76-70a4-1f5b-33d4523fb16b', NULL, 'Net.Authorizations.Menus', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb76-663f-703b-cf44853caac8', NULL, 'Net.Authorizations.Menus.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb76-e254-8ffc-c311976459c2', NULL, 'Net.Authorizations.Menus.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb76-07c1-87b9-6a20f792c1c1', NULL, 'Net.Authorizations.Menus.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb75-a2dc-5e0c-41e1ff68c112', NULL, 'Net.Authorizations.Modules', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb76-814d-fd54-f970132f7db8', NULL, 'Net.Authorizations.Modules.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb76-59f8-072e-00e0c2e62569', NULL, 'Net.Authorizations.Modules.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a19923b-bb76-3086-2843-06ecfd60a933', NULL, 'Net.Authorizations.Modules.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c1d-9b7a-ecbf-c5f7-04be7865bc3e', NULL, 'Net.Authorizations.Roles', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c1d-9b7a-c01e-b862-3d8ddc29c5a3', NULL, 'Net.Authorizations.Roles.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c1d-9b7a-37ad-27d4-a732d2d2a7e1', NULL, 'Net.Authorizations.Roles.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c1d-9b7a-a7b0-992d-6678fe23858e', NULL, 'Net.Authorizations.Roles.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c6e-32b7-c38b-4992-9b2ffa18e4d8', NULL, 'Net.Authorizations.Users', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c6e-32b7-be8e-1904-9a0d69617e32', NULL, 'Net.Authorizations.Users.Create', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c6e-32b7-4a7e-402b-68b70bc72d28', NULL, 'Net.Authorizations.Users.Delete', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a198c6e-32b7-6d7a-5342-6ea52388aab4', NULL, 'Net.Authorizations.Users.Update', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-52dd-4721-27eef90137f2', NULL, 'SettingManagement.Emailing', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-2250-6b99-dacee9802b44', NULL, 'SettingManagement.Emailing.Test', 'R', 'admin');
INSERT INTO `abppermissiongrants` VALUES ('3a194f8d-d1cd-faa6-3d23-ca104cbfe1cc', NULL, 'SettingManagement.TimeZone', 'R', 'admin');

SET FOREIGN_KEY_CHECKS = 1;
