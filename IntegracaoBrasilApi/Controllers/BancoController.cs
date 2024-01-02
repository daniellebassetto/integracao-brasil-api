using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BancoController(IBancoService bancoService) : ControllerBase
{
    private readonly IBancoService _bancoService = bancoService;

    [HttpGet]
    public async Task<ActionResult<List<BancoModel>>> Get()
    {
        var response = await _bancoService.Get();

        if (response == null)
            return BadRequest("Banco não encontrado!");
        else
            return Ok(response);
    }
}