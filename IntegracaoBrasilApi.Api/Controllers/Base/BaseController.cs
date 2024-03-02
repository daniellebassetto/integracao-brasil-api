using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.ApiManagement;
using IntegracaoBrasilApi.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IntegracaoBrasilApi.Api.Controllers;

[Authorize]
[ApiController]
public class BaseController<TIService, TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput, TInputIdentifier>(TIService service) : Controller
    where TIService : IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput, TInputIdentifier>
    where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
{
    public Guid _guidApiDataRequest;
    public TIService _service = service;

    [NonAction]
    public async Task<ActionResult> ResponseExceptionAsync(Exception ex)
    {
        return await Task.FromResult(BadRequest(new { Value = ex.Message }));
    }

    #region Read
    [HttpGet]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> GetAll()
    {
        try
        {
            return await ResponseAsync(_service.GetAll());
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> Get(string id)
    {
        try
        {
            return await ResponseAsync(_service.Get(id));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetListByListId")]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> GetListByListId(List<string> listId)
    {
        try
        {
            return await ResponseAsync(_service.GetListByListId(listId));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetByIdentifier")]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        try
        {
            return await ResponseAsync(_service.GetByIdentifier(inputIdentifier));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetListByListIdentifier")]
    public virtual async Task<ActionResult<BaseResponse<List<TOutput>>>> GetListByListIdentifier([FromBody] List<TInputIdentifier> listInputIdentifier)
    {
        try
        {
            return await ResponseAsync(_service.GetListByListIdentifier(listInputIdentifier));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Create
    [HttpPost]
    [AllowAnonymous]
    public virtual async Task<ActionResult<BaseResponse<string>>> Create(TInputCreate inputCreate)
    {
        try
        {
            return await ResponseAsync(_service.Create(inputCreate));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("Multiple")]
    public virtual async Task<ActionResult<BaseResponse<List<string>>>> Create(List<TInputCreate> listInputCreate)
    {
        try
        {
            return await ResponseAsync(_service.Create(listInputCreate));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Update
    [HttpPut]
    public virtual async Task<ActionResult<BaseResponse<string>>> Update(TInputIdentityUpdate inputIdentityUpdate)
    {
        try
        {
            return await ResponseAsync(_service.Update(inputIdentityUpdate));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPut("Multiple")]
    public virtual async Task<ActionResult<BaseResponse<List<string>>>> Update(List<TInputIdentityUpdate> listInputIdentityUpdate)
    {
        try
        {
            return await ResponseAsync(_service.Update(listInputIdentityUpdate));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Delete
    [HttpDelete]
    public virtual async Task<ActionResult<BaseResponse<bool>>> Delete(string id)
    {
        try
        {
            return await ResponseAsync(_service.Delete(id));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpDelete("Multiple")]
    public virtual async Task<ActionResult<BaseResponse<List<bool>>>> Delete(List<string> listId)
    {
        try
        {
            return await ResponseAsync(_service.Delete(listId));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    [NonAction]
    public async Task<ActionResult> ResponseAsync(object result)
    {
        return await ResponseAsync<object>(result);
    }

    [NonAction]
    public async Task<ActionResult> ResponseAsync<ResponseType>(ResponseType result)
    {
        try
        {
            return await Task.FromResult(Ok(new BaseResponse<ResponseType> { Result = result }));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}"));
        }
    }

    [NonAction]
    public void SetData()
    {
        Guid guidApiDataRequest = ApiData.CreateApiDataRequest();
        SetGuid(guidApiDataRequest);
    }

    [NonAction]
    public void SetGuid(Guid guidApiDataRequest)
    {
        _guidApiDataRequest = guidApiDataRequest;
        GenericModule.SetGuidApiDataRequest(this, guidApiDataRequest);
    }

    [NonAction]
    public override async void OnActionExecuting(ActionExecutingContext context)
    {
        try
        {
            SetData();
        }
        catch (Exception ex)
        {
            context.Result = await ResponseExceptionAsync(ex);
        }
    }
}

#region InputIdentityUpdate, TInputUpdate, TEntity, TInputIdentifier
public class BaseController_1<TIService>(TIService service) : BaseController<TIService, object, object, BaseInputIdentityUpdate_0, object, object>(service)
    where TIService : IBaseService_0
{ }
#endregion