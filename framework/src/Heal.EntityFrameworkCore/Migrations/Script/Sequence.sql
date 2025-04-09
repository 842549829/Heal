-- 创建序列表
CREATE TABLE sequences (
    seq_name VARCHAR(50) PRIMARY KEY, -- 序列名称
    seq_value BIGINT NOT NULL DEFAULT 0 -- 当前序列值
);


-- 创建序列存储过程

DELIMITER $$

CREATE PROCEDURE get_next_val(IN seq_name_param VARCHAR(50), OUT next_val BIGINT)
BEGIN
    DECLARE current_val BIGINT;

    -- 开始事务
    START TRANSACTION;

    -- 尝试插入序列（如果不存在则插入，默认值为 0）
    INSERT INTO sequences (seq_name, seq_value)
    VALUES (seq_name_param, 0)
    ON DUPLICATE KEY UPDATE seq_value = seq_value;

    -- 获取当前序列值，并加 1
    SELECT seq_value INTO current_val FROM sequences WHERE seq_name = seq_name_param FOR UPDATE;
    UPDATE sequences SET seq_value = current_val + 1 WHERE seq_name = seq_name_param;

    -- 提交事务
    COMMIT;

    -- 返回下一个序列值
    SET next_val = current_val + 1;
END$$

DELIMITER ;


-- 创建序列自定义函数
SET GLOBAL log_bin_trust_function_creators = 1;

DELIMITER $$

CREATE FUNCTION get_next_val(seq_name_param VARCHAR(50)) 
RETURNS BIGINT
NOT DETERMINISTIC
MODIFIES SQL DATA
BEGIN
    DECLARE current_val BIGINT;

    -- 尝试插入序列（如果不存在则插入，默认值为 0）
    INSERT INTO sequences (seq_name, seq_value)
    VALUES (seq_name_param, 0)
    ON DUPLICATE KEY UPDATE seq_value = seq_value;

    -- 获取当前序列值，并加 1
    SELECT seq_value INTO current_val FROM sequences WHERE seq_name = seq_name_param FOR UPDATE;
    UPDATE sequences SET seq_value = current_val + 1 WHERE seq_name = seq_name_param;

    -- 返回下一个序列值
    RETURN current_val + 1;
END$$

DELIMITER ;