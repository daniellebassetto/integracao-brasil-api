using IntegracaoBrasilApi.Controllers.Base;
using IntegracaoBrasilApi.Model;
using IntegracaoBrasilApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Controllers;

public class NcmController(INcmService service) : BaseController<INcmService>(service)
{
    [HttpGet("{code}")]
    public async Task<ActionResult<NcmModel>> Get(string code)
    {
        var response = await _service.Get(code);

        if (response == null)
            return BadRequest("Nenhum ncm encontrado!");
        else
            return Ok(response);
    }
}