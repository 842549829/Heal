using Heal.Domain.Entities;

namespace Heal.Net.Domain.Bases.Users.Entities;

/// <summary>
/// 患者
/// </summary>
/// <param name="id">id</param>
/// <param name="name">名称</param>
/// <param name="code">编码</param>
/// <param name="idCardType">证件类型</param>
/// <param name="idCardNo">证件号</param>
/// <param name="gender">性别</param>
/// <param name="phone">电话</param>
public class Patient(Guid id, string name, string code, string idCardType, string idCardNo, string gender, string phone)
    : FullPersonnelAuditedAggregateRoot<Guid>(id, name, code, idCardType, idCardNo, gender, phone)
{
    // 工作单位
    // 工作单位地址
    // 工作单位电话
    // 紧急联系人
    // 紧急联系人电话
    // 紧急联系人关系
    // 紧急联系人地址
    // 民族
    // 政治面貌
    // 国籍
    // 籍贯
    // 健康状况
    // 婚姻状况
    // 血型
    // 现住址
    // 户籍地址
    // 居住证地址
    // 居住证有效期
    // 身份证有效期
    // 身份证地址
    // 身份证正面照
    // 身份证反面照
    // 身份证国徽照
    // 身份证号码
    // 就诊卡号
    // 来源 (门诊，住院，体检，其他)
    // 监护人Id
    // 监护人
    // 监护人关系
    // 监护人电话
    // 监护人地址
    // 监护人身份证
    // 监护人身份证正面照
    // 监护人身份证反面照
    // 监护人身份证国徽照
    // 监护人姓名
    // 监护人性别
    // 监护人民族
    // 监护人政治面貌
    // 监护人国籍
    // 监护人籍贯
    // 监护人健康状况
    // 监护人婚姻状况
    // 监护人血型
    // 监护人现住址
    // 监护人户籍地址
    // 监护人居住证地址
    // 监护人居住证有效期
    // 监护人身份证有效期
    // 监护人身份证地址
    // 监护人身份证正面照
    // 监护人身份证反面照
    // 别名(藏族名，外文名，曾用名，其他)
    // 病案号
}