using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using app.neptuno.dto;

namespace app.neptuno.api
{
    public class ListPropertySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(InItemDTO))
            {
                schema.Properties.Add("ItemXBodega", new OpenApiSchema
                {
                    Type = "array",
                    Items = new OpenApiSchema { Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "InItemBodegaDTO" } }
                });
            }
        }
    }
}