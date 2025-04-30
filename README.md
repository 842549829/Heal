### 数据库还原

```bash
# 安装 dotnet ef cli
dotnet tool install --global dotnet-ef
# 更新 dotnet ef cli
dotnet tool update --global dotnet-ef
# 生成迁移文件
dotnet ef migrations add init -c HealNetDbContext
# 更新数据库
dotnet ef database update -c HealNetDbContext
# 生成迁移脚本 ( 用于生成环境 )
dotnet ef migrations script --verbose -i --project "./" -c HealNetDbContext -o "./Migrations/Script/20250416064948_init.sql"
# 生成某一次迭代更新的脚本, 从这个迭代 20240329102615_file1 到 20240408082719_announcement 迭代版本之间的差异脚本
dotnet ef migrations script --verbose -i --project "./" -c HealNetDbContext -o "./Migrations/Script/20250430072903_init2.sql"  20250418013255_init1 20250430072903_init2
```
