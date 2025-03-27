namespace Sharding.Core.Test.Entities;

/// <summary>
/// Entity
/// </summary>
public interface IEntity
{
    public string Id { get; set; }
}

/// <summary>
/// Create
/// </summary>
public interface ICreate : IEntity
{
    /// <summary>
    /// CreationTime
    /// </summary>
    public DateTime CreationTime { get; set; }
}

/// <summary>
/// order table
/// </summary>
public class Order : ICreate
{
    /// <summary>
    /// order Id
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// payer id
    /// </summary>
    public string Payer { get; set; } = null!;

    /// <summary>
    /// pay money cent
    /// </summary>
    public long Money { get; set; }
    /// <summary>
    /// area
    /// </summary>
    public string Area { get; set; } = null!;

    /// <summary>
    /// order status
    /// </summary>
    public OrderStatusEnum OrderStatus { get; set; }

    /// <summary>
    /// CreationTime
    /// </summary>
    public DateTime CreationTime { get; set; }
}

/// <summary>
/// order status
/// </summary>
public enum OrderStatusEnum
{
    /// <summary>
    /// no pay
    /// </summary>
    NoPay = 1,

    /// <summary>
    /// paying
    /// </summary>
    Paying = 2,

    /// <summary>
    /// payed
    /// </summary>
    Payed = 3,

    /// <summary>
    /// pay fail
    /// </summary>
    PayFail = 4
}