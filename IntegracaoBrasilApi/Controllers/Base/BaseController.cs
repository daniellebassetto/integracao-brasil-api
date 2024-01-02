using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController<IService>(IService service) : ControllerBase
    where IService : IBaseService
{
    protected readonly IService _service = service;
}