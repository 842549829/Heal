using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Xml.XPath;

namespace Heal.Net.HttpApi.Host.Filters;

/// <summary>
/// EnumSchemaFilter
/// </summary>
public class EnumSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// _xmlDoc
    /// </summary>
    private readonly XPathDocument? _xmlDoc;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="xmlPath">xmlPath</param>
    public EnumSchemaFilter(string xmlPath)
    {
        if (File.Exists(xmlPath))
        {
            _xmlDoc = new XPathDocument(xmlPath);
        }
    }

    /// <summary>
    /// Apply
    /// </summary>
    /// <param name="schema">schema</param>
    /// <param name="context">context</param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum || _xmlDoc == null)
        {
            return;
        }

        var navigator = _xmlDoc.CreateNavigator();

        // 查找枚举类型的 XML 注释
        var enumNode = navigator.SelectSingleNode($"/doc/members/member[@name='T:{context.Type.FullName}']");
        if (enumNode != null)
        {
            schema.Description = enumNode.SelectSingleNode("summary")?.Value.Trim();
        }

        // 清空默认的枚举值
        schema.Enum.Clear();

        // 创建一个字符串列表来存储枚举值和注释
        var descriptions = new System.Text.StringBuilder();

        foreach (var field in context.Type.GetFields())
        {
            if (field.IsSpecialName) // 排除构造函数等特殊字段
            {
                continue;
            }

            var fieldValue = Convert.ToInt32(field.GetValue(null)); // 获取枚举值（数字）
            var fieldName = field.Name;

            // 查找字段的 XML 注释
            var fieldNode = navigator.SelectSingleNode($"/doc/members/member[@name='F:{context.Type.FullName}.{fieldName}']");
            var description = fieldNode?.SelectSingleNode("summary")?.Value.Trim() ?? fieldName;

            // 拼接格式： "{值} {注释}"
            descriptions.AppendLine($"{fieldValue} {description}");

            // 添加枚举值到 schema.Enum
            schema.Enum.Add(new OpenApiInteger(fieldValue));
        }

        // 将拼接好的描述赋值给 schema.Description
        schema.Description += "\n" + descriptions.ToString().Trim();
    }
}