using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace IntegracaoBrasilApi.Domain.ApiManagement;

public class IgnoreJsonPropertyContractResolver : CamelCasePropertyNamesContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        if (property.AttributeProvider!.GetAttributes(typeof(JsonPropertyAttribute), true).Count > 0)
        {
            property.PropertyName = ResolvePropertyName(property.UnderlyingName!);
        }

        return property;
    }
}