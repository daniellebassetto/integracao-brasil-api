namespace IntegracaoBrasilApi.Api.Generic;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LanguageDescription(string language, string description) : Attribute
{
    public string Language { get; } = language;
    public string Description { get; } = description;
}