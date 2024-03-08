using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.ApiManagement;
using IntegracaoBrasilApi.Domain.Interfaces;
using IntegracaoBrasilApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IntegracaoBrasilApi.Api.Controllers;

[Route("api/[controller]")]
public class LegalPersonRegistrationController(IApiDataService apiDataService, ILegalPersonRegistrationService service) : BaseController_1<ILegalPersonRegistrationService>(apiDataService, service)
{
    /// <summary>
    /// Consulta o Cadastro Nacional de Pessoa Física a partir do número do CNPJ
    /// </summary>
    [ProducesResponseType<OutputGetByCnpjLegalPersonRegistration>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("GetByCnpj/{cnpj}")]
    public async Task<ActionResult<BaseResponseApi<OutputGetByCnpjLegalPersonRegistration, ApiResponseException>>> GetByCnpj([Length(14,14)] string cnpj)
    {
        try
        {
            return await ResponseAsync(await _service!.GetByCnpj(cnpj));
        }
        catch (BaseResponseException ex)
        {
            return await BaseResponseExceptionAsync(ex);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    #region IgnoreApi
    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<object>>> GetAll()
    {
        return base.GetAll();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<object>>> Get(string id)
    {
        return base.Get(id);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<object>>> GetListByListId(List<string> listId)
    {
        return base.GetListByListId(listId);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<object>>> GetByIdentifier(object inputIdentifier)
    {
        return base.GetByIdentifier(inputIdentifier);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<object>>>> GetListByListIdentifier([FromBody] List<object> listInputIdentifier)
    {
        return base.GetListByListIdentifier(listInputIdentifier);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<string>>> Create(object inputCreate)
    {
        return base.Create(inputCreate);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<string>>>> Create(List<object> listInputCreate)
    {
        return base.Create(listInputCreate);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<string>>> Update(BaseInputIdentityUpdate_0 inputIdentityUpdate)
    {
        return base.Update(inputIdentityUpdate);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<string>>>> Update(List<BaseInputIdentityUpdate_0> listInputIdentityUpdate)
    {
        return base.Update(listInputIdentityUpdate);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<bool>>>> Delete(List<string> listId)
    {
        return base.Delete(listId);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<bool>>> Delete(string id)
    {
        return base.Delete(id);
    }
    #endregion
}