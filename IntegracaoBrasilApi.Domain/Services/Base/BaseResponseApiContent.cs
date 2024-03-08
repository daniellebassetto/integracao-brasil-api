using Newtonsoft.Json;

namespace IntegracaoBrasilApi.Domain.Services;

public class BaseResponseApiContent<TTypeResult, TTypeException>
{
    public TTypeResult? Result { get; set; }
    public TTypeException? Exception { get; set; }
    public List<Notification>? ListNotification { get; set; }
    [JsonIgnore] public int StatusCode { get; set; }
}