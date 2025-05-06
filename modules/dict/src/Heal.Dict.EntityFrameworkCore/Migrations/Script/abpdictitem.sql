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

 Date: 06/05/2025 13:49:47
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for abpdictitem
-- ----------------------------
DROP TABLE IF EXISTS `abpdictitem`;
CREATE TABLE `abpdictitem`  (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT 'Id',
  `Style` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '样式',
  `DictTypeId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL COMMENT '所属类型Id',
  `Key` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '键',
  `ParentId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NULL DEFAULT NULL COMMENT '父级Id',
  `Alias` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '别名',
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
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `FK_AbpDictItem_AbpDictType_DictTypeId`(`DictTypeId` ASC) USING BTREE,
  CONSTRAINT `FK_AbpDictItem_AbpDictType_DictTypeId` FOREIGN KEY (`DictTypeId`) REFERENCES `abpdicttype` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '字典项' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of abpdictitem
-- ----------------------------
INSERT INTO `abpdictitem` VALUES ('3a19b649-9647-6c1c-c98b-1bdb35b45141', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b649-9647-6c1c-c98b-1bdb35b45141', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '居民身份证', '01', 'jmsfz', 'jmsfz', 1, 1, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '居民户口簿', '02', 'jmhukb', 'jmsfz', 1, 2, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64b-4607-a03a-f989-c341c8b5f205', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '护照', '03', 'jmhukb', 'jmsfz', 1, 3, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64b-7e99-e24b-3fff-0ebe89ac5c01', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '军官证', '04', 'jmhukb', 'jmsfz', 1, 4, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64b-b362-635c-654b-fb4e88dfe546', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '驾驶证', '05', 'jmhukb', 'jmsfz', 1, 5, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64b-e0ac-6c4f-fe5b-c2647f695177', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '港澳居民来往内地通行证', '06', 'jmhukb', 'jmsfz', 1, 6, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64c-0af7-d8f9-531c-8bcfe269ce8d', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '台湾居民来往大陆通行证', '07', 'jmhukb', 'jmsfz', 1, 7, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64c-3798-b114-b39b-554bfd5aa582', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '临时居民身份证', '08', 'jmhukb', 'jmsfz', 1, 8, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64c-9398-9ce0-9b56-2bac346e65ba', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '武装警察身份证件', '09', 'jmhukb', 'jmsfz', 1, 9, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64c-c3a2-b113-8736-b9379b652fcd', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '中华人民共和国港澳居民居住证', '10', 'jmhukb', 'jmsfz', 1, 10, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64c-e9b9-907e-cd57-4a627970a64e', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '中华人民共和国台湾居民居住证', '11', 'jmhukb', 'jmsfz', 1, 11, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64d-14d9-4984-f74c-f5be61a63af8', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '社会保障卡', '12', 'jmhukb', 'jmsfz', 1, 12, 'admin', 'admin', NULL, NULL);
INSERT INTO `abpdictitem` VALUES ('3a19b64e-a88e-6f05-5e69-7986f9dc5793', NULL, '3a19b63b-f366-4ee0-c1d6-05985ae3bec7', 'CV02.01.101', NULL, NULL, '{}', '3a19b64a-a45d-4ffe-a54e-8c8ac5b77de4', '2025-05-06 13:41:25.000000', NULL, NULL, NULL, 0, NULL, NULL, NULL, '其他法定有效证件', '99', 'jmhukb', 'jmsfz', 1, 13, 'admin', 'admin', NULL, NULL);

SET FOREIGN_KEY_CHECKS = 1;
