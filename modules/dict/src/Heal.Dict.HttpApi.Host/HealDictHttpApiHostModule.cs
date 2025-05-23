﻿using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.MultiTenancy;
using Heal.Dict.Application;
using Heal.Dict.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Heal.Dict.Application.Contracts;
using Heal.Dict.Domain;
using Heal.Dict.Domain.Shared;
using Heal.Net.HttpApi.Host.Filters;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Dict.HttpApi.Host;

/// <summary>
/// HealNetHttpApiHostModule
/// </summary>
[DependsOn(
    typeof(HealDictHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(HealDictApplicationModule),
    typeof(HealDictEntityFrameworkCoreModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
public class HealDictHttpApiHostModule : AbpModule
{
    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">context</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        ConfigureSwagger(context, configuration);
        ConfigureVirtualFileSystem(context);
        ConfigureCors(context, configuration);
        ConfigureAuthentication(context, configuration);
        ConfigureJsonOptions(context);
    }

    /// <summary>
    /// 配置JsonOptions 
    /// </summary>
    /// <param name="context">服务配置上下文。</param>
    public void ConfigureJsonOptions(ServiceConfigurationContext context)
    {
        Configure<JsonOptions>(options =>
        {
            // 使用驼峰命名规则
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            // 忽略循环引用
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

            // 忽略空值
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

            // 可选：允许注释
            options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
        });

        //var customRootPath = "v1";
        //var assembly = typeof(HealNetHttpApiHostModule).Assembly;
        //if (string.IsNullOrWhiteSpace(customRootPath))
        //{
        //    throw new ArgumentException("自定义根路径不能为空或仅包含空白字符。", nameof(customRootPath));
        //}

        //if (assembly == null)
        //{
        //    throw new ArgumentNullException(nameof(assembly), "程序集不能为 null。");
        //}

        //Configure<AbpAspNetCoreMvcOptions>(options =>
        //{
        //    options.ConventionalControllers.Create(assembly, settings =>
        //    {
        //        settings.RootPath = customRootPath.Trim('/');
        //    });
        //});
    }

    /// <summary>
    /// ConfigureVirtualFileSystem
    /// </summary>
    /// <param name="context">context</param>
    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<HealDictDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heal.Dict.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<HealDictDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heal.Dict.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<HealDictApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heal.Dict.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<HealDictApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Heal.Dict.Application"));
            });
        }
    }

    /// <summary>
    /// ConfigureSwagger
    /// </summary>
    /// <param name="context">context</param>
    /// <param name="configuration">configuration</param>
    private static void ConfigureSwagger(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAbpSwaggerGenWithOidc(
            configuration["AuthServer:Authority"]!,
            ["Heal"],
            [AbpSwaggerOidcFlows.AuthorizationCode],
            null,
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Heal API", Version = "v1" });
                options.DocInclusionPredicate((_, _) => true);
                options.CustomSchemaIds(type => type.FullName);

                var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(assembly => !assembly.IsDynamic && !string.IsNullOrEmpty(assembly.Location))
                    .ToList();

                foreach (var xmlPath in assemblies.Select(assembly => $"{assembly.GetName().Name}.xml").Select(xmlFile => Path.Combine(AppContext.BaseDirectory, xmlFile)).Where(File.Exists))
                {
                    options.IncludeXmlComments(xmlPath);
                    // 添加枚举字段描述的支持
                    options.SchemaFilter<EnumSchemaFilter>(xmlPath);
                }
            });
    }

    /// <summary>
    /// ConfigureCors
    /// </summary>
    /// <param name="context">context</param>
    /// <param name="configuration">configuration</param>
    private static void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.Trim().RemovePostFix("/"))
                            .ToArray() ?? []
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    /// <summary>
    /// ConfigureAuthentication
    /// </summary>
    /// <param name="context">context</param>
    /// <param name="configuration">configuration</param>
    private static void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = ApplicationProgramConstants.ApplicationName;

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = messageReceivedContext =>
                    {
                        if (messageReceivedContext.Request.Headers.ContainsKey("Authorization"))
                        {
                            return Task.CompletedTask;
                        }

                        if (messageReceivedContext.Request.Query.TryGetValue("access_token", out var token))
                        {
                            messageReceivedContext.Token = token;
                        }

                        return Task.CompletedTask;
                    }
                };
            });
    }

    /// <summary>
    /// OnApplicationInitialization
    /// </summary>
    /// <param name="context">context</param>
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.UseForwardedHeaders();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        app.MapAbpStaticAssets();
        app.UseRouting();
        app.UseAbpSecurityHeaders();
        app.UseCors();
        app.UseAuthentication();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Heal API");

            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}