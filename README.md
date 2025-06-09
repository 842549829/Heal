### 命令安装
```bash
# 安装 dotnet ef cli
dotnet tool install --global dotnet-ef
# 更新 dotnet ef cli
dotnet tool update --global dotnet-ef
```
### Net数据库还原

```bash
# 生成迁移文件
dotnet ef migrations add init -c HealNetDbContext
# 更新数据库
dotnet ef database update -c HealNetDbContext
# 生成迁移脚本 ( 用于生成环境 )
dotnet ef migrations script --verbose -i --project "./" -c HealNetDbContext -o "./Migrations/Script/20250416064948_init.sql"
# 生成某一次迭代更新的脚本, 从这个迭代 20240329102615_file1 到 20240408082719_announcement 迭代版本之间的差异脚本
dotnet ef migrations script --verbose -i --project "./" -c HealNetDbContext -o "./Migrations/Script/20250430072903_init2.sql"  20250418013255_init1 20250430072903_init2
```

### Dict数据库还原
```bash
# 生成迁移文件
dotnet ef migrations add init -c HealDictDbContext
# 更新数据库
dotnet ef database update -c HealDictDbContext
# 生成迁移脚本 ( 用于生成环境 )
dotnet ef migrations script --verbose -i --project "./" -c HealDictDbContext -o "./Migrations/Script/20250506053754_init.sql"
# 生成某一次迭代更新的脚本, 从这个迭代 ******** 到 ********** 迭代版本之间的差异脚本
dotnet ef migrations script --verbose -i --project "./" -c HealDictDbContext -o "./Migrations/Script/20250430072903_init2.sql"  20250418013255_init1 20250430072903_init2
```

### 自签名证书
```bash
#生成私钥（server.key）
openssl genrsa -out server.key 2048
#生成自签名证书（server.crt）
openssl req -new -x509 -days 365 -key server.key -out server.crt
#将私钥 + 证书打包为 .pfx 文件
openssl pkcs12 -export -out server.pfx -inkey server.key -in server.crt
#查看 PFX 文件内容（可选）
openssl pkcs12 -info -in server.pfx
#将 server.crt 导入 Java 的 cacerts（用于信任）
keytool -import -alias localhost -file server.crt -keystore "%JAVA_HOME%\lib\security\cacerts"
```