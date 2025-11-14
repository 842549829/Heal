using Microsoft.EntityFrameworkCore;
using Sharding.Core.Test.EntityFrameworkCore;
using ShardingCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

//添加分片配置
services.AddShardingDbContext<ShardingDbContext>()
    .UseRouteConfig(op =>
    {
        op.AddShardingTableRoute<OrderTimeShardingRule>();
    })
    .UseConfig((_, op) =>
    {
        op.UseShardingQuery((conn, options) =>
        {
            options.UseMySQL(conn);
        });
        op.UseShardingTransaction((conn, options) =>
        {
            options.UseMySQL(conn);
        });
        op.AddDefaultDataSource(Guid.NewGuid().ToString("n"), configuration.GetConnectionString("Default"));
    }).AddShardingCore();

services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Services.UseAutoTryCompensateTable();

app.Run();