using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class RequireValueTypePropertiesSchemaFilter : ISchemaFilter
{
    private readonly HashSet<OpenApiSchema> valueTypes = new HashSet<OpenApiSchema>();

    public void Apply(OpenApiSchema model, SchemaFilterContext context)
    {
        if (context.Type.IsValueType)
        {
            valueTypes.Add(model);
        }

        if (model.Properties != null)
        {
            foreach (var prop in model.Properties)
            {
                if (valueTypes.Contains(prop.Value))
                {
                    model.Required.Add(prop.Key);
                }
            }
        }
    }
}