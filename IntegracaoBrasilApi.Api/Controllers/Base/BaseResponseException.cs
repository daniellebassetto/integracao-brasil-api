using IntegracaoBrasilApi.Domain.Services;

namespace IntegracaoBrasilApi.Api.Controllers;

public class BaseResponseException : Exception
{
    public List<Notification> Incidents { get; private set; }

    public BaseResponseException(List<Notification> _incidents)
    {
        Incidents = _incidents;
    }
}