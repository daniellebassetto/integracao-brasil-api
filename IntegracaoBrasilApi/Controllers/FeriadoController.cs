using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeriadoController(IFeriadoService feriadoService) : ControllerBase
{
    private readonly IFeriadoService _feriadoService = feriadoService;

    [HttpGet("{ano}")]
    public async Task<ActionResult<List<FeriadoModel>>> Get(int ano)
    {
        var response = await _feriadoService.Get(ano);

        if (response == null)
            return BadRequest("Feriado não encontrado!");
        else
            return Ok(response);
    }
}