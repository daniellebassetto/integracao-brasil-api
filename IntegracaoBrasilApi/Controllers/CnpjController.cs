using IntegracaoBrasilApi.Controllers.Base;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CnpjController(ICnpjService service) : BaseController<ICnpjService>(service)
{
    [HttpGet("{cnpj}")]
    public async Task<ActionResult<CnpjModel>> Get(string cnpj)
    {
        var response = await _service.Get(cnpj);

        if (response == null)
            return BadRequest("Cnpj não encontrado!");
        else
            return Ok(response);
    }
}