using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IntegracaoBrasilApi.Api.Generic;

public class SwaggerCustomDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var newPaths = new OpenApiPaths();

        foreach (var path in swaggerDoc.Paths)
        {
            var newPath = path.Key.Replace("[controller]", $"v{swaggerDoc.Info.Version}");
            newPaths.Add(newPath, path.Value);

            foreach (var operation in path.Value.Operations)
            {
                var apiDescription = context.ApiDescriptions.FirstOrDefault(desc =>
                    $"/{desc.RelativePath}".Equals(path.Key, StringComparison.OrdinalIgnoreCase) &&
                    $"{desc.HttpMethod}".Equals(operation.Key.ToString(), StringComparison.OrdinalIgnoreCase));

                if (apiDescription != null)
                {
                    var customAttribute = apiDescription.ActionDescriptor.EndpointMetadata
                        .OfType<LanguageDescription>()
                        .Where(x => x.Language == swaggerDoc.Info.Version)
                        .FirstOrDefault();

                    operation.Value.Description = customAttribute?.Description;
                }
            }
        }

        swaggerDoc.Paths = newPaths;
    }
}