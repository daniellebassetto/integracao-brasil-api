using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Arguments;

public class OutputGetByCnpjLegalPersonRegistration
{
    public string? Cnpj { get; set; }
    [JsonProperty("identificador_matriz_filial")] public int? MatrixBranchCode { get; set; }
    [JsonProperty("descricao_identificador_matriz_filial")] public string? MatrixBranchDescription { get; set; }
    [JsonProperty("razao_social")] public string? CompanyName { get; set; }
    [JsonProperty("nome_fantasia")] public string? TradeName { get; set; }
    [JsonProperty("situacao_cadastral")] public int? RegistrationStatusCode { get; set; }
    [JsonProperty("descricao_situacao_cadastral")] public string? RegistrationStatusDescription { get; set; }
    [JsonProperty("data_situacao_cadastral")] public string? RegistrationStatusDate { get; set; }
    [JsonProperty("motivo_situacao_cadastral")] public int? ReasonRegistrationStatusCode { get; set; }
    [JsonProperty("descricao_motivo_situacao_cadastral")] public string? ReasonRegistrationStatusDescription { get; set; }
    [JsonProperty("nome_cidade_no_exterior")] public string? NameCityExterior { get; set; }
    [JsonProperty("codigo_natureza_juridica")] public int? LegalNatureCode { get; set; }
    [JsonProperty("natureza_juridica")] public string? LegalNatureDescription { get; set; }
    [JsonProperty("data_inicio_atividade")] public DateTime? DateStartActivity { get; set; }
    [JsonProperty("cnae_fiscal")] public int? TaxCnaeCode { get; set; }
    [JsonProperty("cnae_fiscal_descricao")] public string? TaxCnaeDescription { get; set; }
    [JsonProperty("descricao_tipo_de_logradouro")] public string? DescriptionTypePublicPlace { get; set; }
    [JsonProperty("logradouro")] public string? PublicPlace { get; set; }
    [JsonProperty("numero")] public string? Number { get; set; }
    [JsonProperty("complemento")] public string? Complement { get; set; }
    [JsonProperty("bairro")] public string? Neighborhood { get; set; }
    [JsonProperty("cep")] public int? PostalCode { get; set; }
    [JsonProperty("uf")] public string? StateAbbreviation { get; set; }
    [JsonProperty("codigo_municipio")] public int? CityCode { get; set; }
    [JsonProperty("codigo_municipio_ibge")] public int? CityIbgeCode { get; set; }
    [JsonProperty("municipio")] public string? CityDescription { get; set; }
    [JsonProperty("ddd_telefone_1")] public string? FirstPhone { get; set; }
    [JsonProperty("ddd_telefone_2")] public string? SecondPhone { get; set; }
    [JsonProperty("ddd_fax")] public string? Fax { get; set; }
    [JsonProperty("qualificacao_do_responsavel")] public int? ResponsibleQualification { get; set; }
    [JsonProperty("capital_social")] public int? ShareCapital { get; set; }
    [JsonProperty("codigo_porte")] public int? SizeCode { get; set; }
    [JsonProperty("porte")] public string? SizeDescription { get; set; }
    [JsonProperty("opcao_pelo_simples")] public bool? NationalSimpleOptant { get; set; }
    [JsonProperty("data_opcao_pelo_simples")] public DateTime? NationalSimpleOptionDate { get; set; }
    [JsonProperty("data_exclusao_do_simples")] public DateTime? NationalSimpleOptionExclusionDate { get; set; }
    [JsonProperty("opcao_pelo_mei")] public bool? MeiOption { get; set; }
    [JsonProperty("data_opcao_pelo_mei")] public DateTime? MeiOptionDate { get; set; }
    [JsonProperty("data_exclusao_do_mei")] public DateTime? MeiOptionExclusionDate { get; set; }
    [JsonProperty("situacao_especial")] public string? SpecialStatus { get; set; }
    [JsonProperty("data_situacao_especial")] public DateTime? SpecialStatusDate { get; set; }
    [JsonProperty("codigo_pais")] public int? CountryCode { get; set; }
    [JsonProperty("pais")] public string? CountryDescription { get; set; }
    public string? Email { get; set; }
    [JsonProperty("ente_federativo_responsavel")] public string? FederalEntityResponsible { get; set; }
    [JsonProperty("cnaes_secundarios")] public List<SecondaryCnae>? ListSecondaryCnae { get; set; }
    [JsonProperty("qsa")] public List<BoardPartnerAdministrator>? ListBoardPartnerAdministrator { get; set; }
}