using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Arguments;

public class BoardPartnerAdministrator
{
    [JsonProperty("identificador_de_socio")] public int? PartnerCode { get; set; }
    [JsonProperty("nome_socio")] public string? PartnerName { get; set; }
    [JsonProperty("cnpj_cpf_do_socio")] public string? PartnerCnpjCpf { get; set; }
    [JsonProperty("codigo_qualificacao_socio")] public int? PartnerQualificationCode { get; set; }
    [JsonProperty("codigo_pais")] public int? CountryCode { get; set; }
    [JsonProperty("pais")] public string? CountryDescription { get; set; }
    [JsonProperty("codigo_faixa_etaria")] public int? AgeRangeCode { get; set; }
    [JsonProperty("faixa_etaria")] public string? AgeRangeDescription { get; set; }
    [JsonProperty("percentual_capital_social")] public int? ShareCapitalPercentage { get; set; }
    [JsonProperty("data_entrada_sociedade")] public DateTime? DateEntrySociety { get; set; }
    [JsonProperty("cpf_representante_legal")] public string? LegalRepresentativeCpf { get; set; }
    [JsonProperty("nome_representante_legal")] public string? LegalRepresentativeName { get; set; }
    [JsonProperty("codigo_qualificacao_representante_legal")] public int? LegalRepresentativeQualificationCode { get; set; }
    [JsonProperty("qualificacao_representante_legal")] public string? LegalRepresentativeQualificationDescription { get; set; }
}