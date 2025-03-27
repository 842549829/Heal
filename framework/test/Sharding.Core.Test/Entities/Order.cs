namespace Sharding.Core.Test.Entities;

public interface IEntity
{
    public string Id { get; set; }
}

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

public enum OrderStatusEnum
{
    NoPay = 1,
    Paying = 2,
    Payed = 3,
    PayFail = 4
}