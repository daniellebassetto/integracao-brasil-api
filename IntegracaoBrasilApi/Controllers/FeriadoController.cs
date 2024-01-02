using IntegracaoBrasilApi.Controllers.Base;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeriadoController(IFeriadoService service) : BaseController<IFeriadoService>(service)
{
    [HttpGet("{ano}")]
    public async Task<ActionResult<List<FeriadoModel>>> Get(int ano)
    {
        var response = await _service.Get(ano);

        if (response == null)
            return BadRequest("Nenhum feriado encontrado!");
        else
            return Ok(response);
    }
}