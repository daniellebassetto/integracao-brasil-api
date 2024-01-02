using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CnpjController(ICnpjService cnpjService) : ControllerBase
{
    private readonly ICnpjService _cnpjService = cnpjService;

    [HttpGet("{cnpj}")]
    public async Task<ActionResult<CnpjModel>> GetCnpj(string cnpj)
    {
        var response = await _cnpjService.GetCnpj(cnpj);

        if (response == null)
            return BadRequest("Cnpj não encontrado!");
        else
            return Ok(response);
    }
}