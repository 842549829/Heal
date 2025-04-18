namespace Heal.Domain.Shared.Exceptions;

/// <summary>
/// 领域验证异常
/// </summary>
public class DomainValidationException : Exception
{
    /// <summary>
    /// 本地化键
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// 动态参数
    /// </summary>
    public object[] Arguments { get; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="key">本地化键</param>
    /// <param name="arguments">动态参数（可选）</param>
    public DomainValidationException(string key, params object[] arguments)
        : base($"Validation failed for key '{key}' with arguments: {string.Join(", ", arguments)}")
    {
        Key = key;
        Arguments = arguments;
    }

   

    ///// <summary>
    ///// 序列化构造函数（用于跨进程传递异常）
    ///// </summary>
    ///// <param name="info">序列化信息</param>
    ///// <param name="context">流上下文</param>
    //[Obsolete("Obsolete")]
    //protected DomainValidationException(SerializationInfo info, StreamingContext context)
    //    : base(info, context)
    //{
    //    Key = info.GetString(nameof(Key))!;
    //    Arguments = (object[])info.GetValue(nameof(Arguments), typeof(object[]))!;
    //}

    ///// <summary>
    ///// 序列化方法（用于跨进程传递异常）
    ///// </summary>
    ///// <param name="info">序列化信息</param>
    ///// <param name="context">流上下文</param>
    //[Obsolete("Obsolete")]
    //public override void GetObjectData(SerializationInfo info, StreamingContext context)
    //{
    //    base.GetObjectData(info, context);
    //    info.AddValue(nameof(Key), Key);
    //    info.AddValue(nameof(Arguments), Arguments);
    //}
}