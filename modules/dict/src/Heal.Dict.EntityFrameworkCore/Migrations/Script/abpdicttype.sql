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

 Date: 06/05/2025 13:49:40
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for abpdicttype
-- ----------------------------
DROP TABLE IF EXISTS `abpdicttype`;
CREATE TABLE `abpdicttype`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '父级Id',
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
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '字典类型' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpdicttype
-- ----------------------------
INSERT INTO `abpdicttype` VALUES ('3a19b62f-7b27-76bc-7c5f-9378d66a5d2c', NULL, '{}', '3a19b62f-7b27-76bc-7c5f-9378d66a5d2c', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '强制性国家标准', 'GB', 'GB', 'GB', 1, 1, 'admin', 'admin', NULL, 'GB');
INSERT INTO `abpdicttype` VALUES ('3a19b631-5789-417f-6ff3-93315bbdf69e', NULL, '{}', '3a19b631-5789-417f-6ff3-93315bbdf69e', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '推荐性国家标准', 'GB/T', 'GB/T', 'GB/T', 1, 2, 'admin', 'admin', NULL, 'GB/T');
INSERT INTO `abpdicttype` VALUES ('3a19b632-750b-15f1-01ae-4b3115046351', NULL, '{}', '3a19b632-750b-15f1-01ae-4b3115046351', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '指导性国家标准', 'GB/Z', 'GB/Z', 'GB/Z', 1, 3, 'admin', 'admin', NULL, 'GB/Z');
INSERT INTO `abpdicttype` VALUES ('3a19b635-2064-f30c-d1c9-d39c92bc1cf4', NULL, '{}', '3a19b635-2064-f30c-d1c9-d39c92bc1cf4', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '强制性卫生标准', 'WS', 'WS', 'GB/Z', 1, 4, 'admin', 'admin', NULL, 'WS');
INSERT INTO `abpdicttype` VALUES ('3a19b636-0c47-b5cd-d7df-b94ff7936409', NULL, '{}', '3a19b636-0c47-b5cd-d7df-b94ff7936409', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '推荐性卫生标准', 'WS/T', 'WS/T', 'WS/T', 1, 5, 'admin', 'admin', NULL, 'WS/T');
INSERT INTO `abpdicttype` VALUES ('3a19b636-57ce-94fb-f1b4-586be0e33934', NULL, '{}', '3a19b636-57ce-94fb-f1b4-586be0e33934', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '指导性卫生标准', 'WS/Z', 'WS/Z', 'WS/Z', 1, 6, 'admin', 'admin', NULL, 'WS/Z');
INSERT INTO `abpdicttype` VALUES ('3a19b637-57d9-347b-c56a-307921cad825', NULL, '{}', '3a19b637-57d9-347b-c56a-307921cad825', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '强制性行业标准', 'CV', 'CV', 'CV', 1, 7, 'admin', 'admin', NULL, 'CV');
INSERT INTO `abpdicttype` VALUES ('3a19b638-2a62-e97a-fbf0-2973af32905f', NULL, '{}', '3a19b638-2a62-e97a-fbf0-2973af32905f', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '推荐性行业标准', 'CV/T', 'CV/T', 'CV/T', 1, 8, 'admin', 'admin', NULL, 'CV/T');
INSERT INTO `abpdicttype` VALUES ('3a19b638-9ef8-2d0e-f10a-fd17f28352dc', NULL, '{}', '3a19b638-9ef8-2d0e-f10a-fd17f28352dc', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '指导性行业标准', 'CV/Z', 'CV/Z', 'CV/Z', 1, 9, 'admin', 'admin', NULL, 'CV/Z');
INSERT INTO `abpdicttype` VALUES ('3a19b639-1f1b-bdbb-a20c-886c985e3806', NULL, '{}', '3a19b639-1f1b-bdbb-a20c-886c985e3806', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '强制性系统标准', 'XT', 'XT', 'XT', 1, 10, 'admin', 'admin', NULL, 'XT');
INSERT INTO `abpdicttype` VALUES ('3a19b63b-f366-4ee0-c1d6-05985ae3bec7', '3a19b637-57d9-347b-c56a-307921cad825', '{}', '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', '2025-05-06 13:12:53.000000', NULL, '2025-05-06 13:13:00.000000', NULL, 0, NULL, NULL, NULL, '身份证件类别', 'CV02.01.101', 'shenfenzhengjianleibie', 'sfzjlb', 1, 11, 'admin', 'admin', NULL, '身份证件类别');

SET FOREIGN_KEY_CHECKS = 1;
