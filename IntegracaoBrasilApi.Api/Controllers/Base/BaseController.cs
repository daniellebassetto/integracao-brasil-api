using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.ApiManagement;
using IntegracaoBrasilApi.Domain.Interfaces.Service;
using IntegracaoBrasilApi.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IntegracaoBrasilApi.Api.Controllers;

[Authorize]
[ApiController]
public class BaseController<TIService, TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput, TInputIdentifier> : Controller
    where TIService : IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput, TInputIdentifier>
    where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
{
    protected readonly IApiDataService? _apiDataService;
    public Guid _guidApiDataRequest;
    public TIService? _service;
    public List<Notification> ListNotification = [];

    public BaseController(IApiDataService apiDataService, TIService service)
    {
        _apiDataService = apiDataService;
        _service = service;
    }

    public BaseController(IApiDataService apiDataService)
    {
        _apiDataService = apiDataService;
    }

    #region Read
    [HttpGet]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> GetAll()
    {
        try
        {
            return await ResponseAsync(_service!.GetAll());
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

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> Get(string id)
    {
        try
        {
            return await ResponseAsync(_service!.Get(id));
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

    [HttpPost("GetListByListId")]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> GetListByListId(List<string> listId)
    {
        try
        {
            return await ResponseAsync(_service!.GetListByListId(listId));
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

    [HttpPost("GetByIdentifier")]
    public virtual async Task<ActionResult<BaseResponse<TOutput>>> GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        try
        {
            return await ResponseAsync(_service!.GetByIdentifier(inputIdentifier));
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

    [HttpPost("GetListByListIdentifier")]
    public virtual async Task<ActionResult<BaseResponse<List<TOutput>>>> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier)
    {
        try
        {
            return await ResponseAsync(_service!.GetListByListIdentifier(listInputIdentifier));
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
    #endregion

    #region Create
    [HttpPost]
    [AllowAnonymous]
    public virtual async Task<ActionResult<BaseResponse<string>>> Create(TInputCreate inputCreate)
    {
        try
        {
            return await ResponseAsync(_service?.Create(inputCreate));
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

    [HttpPost("Multiple")]
    public virtual async Task<ActionResult<BaseResponse<List<string>>>> Create(List<TInputCreate> listInputCreate)
    {
        try
        {
            return await ResponseAsync(_service?.Create(listInputCreate));
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
    #endregion

    #region Update
    [HttpPut]
    public virtual async Task<ActionResult<BaseResponse<string>>> Update(TInputIdentityUpdate inputIdentityUpdate)
    {
        try
        {
            return await ResponseAsync(_service?.Update(inputIdentityUpdate));
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

    [HttpPut("Multiple")]
    public virtual async Task<ActionResult<BaseResponse<List<string>>>> Update(List<TInputIdentityUpdate> listInputIdentityUpdate)
    {
        try
        {
            return await ResponseAsync(_service?.Update(listInputIdentityUpdate));
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
    #endregion

    #region Delete
    [HttpDelete]
    public virtual async Task<ActionResult<BaseResponse<bool>>> Delete(string id)
    {
        try
        {
            return await ResponseAsync(_service?.Delete(id));
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

    [HttpDelete("Multiple")]
    public virtual async Task<ActionResult<BaseResponse<List<bool>>>> Delete(List<string> listId)
    {
        try
        {
            return await ResponseAsync(_service?.Delete(listId));
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
    #endregion

    [NonAction]
    public async Task<ActionResult> ResponseAsync(BaseResponseApiContent<object, object> result)
    {
        return await ResponseAsync<object, object>(result);
    }

    [NonAction]
    public async Task<ActionResult> ResponseAsync<TTypeResult, TTypeException>(BaseResponseApiContent<TTypeResult, TTypeException> result)
    {
        if (_service != null)
            ListNotification.AddRange(_service?.ListNotification!);

        List<Notification> listNegativeNotification = (from i in ListNotification.Union(result!.ListNotification) ?? [] where i.MessageType == EnumMessageType.Negative select i).ToList();

        if (listNegativeNotification.Count == 0)
        {
            try
            {
                _apiDataService?.RemoveApiDataRequest(_guidApiDataRequest);
                if (result.Result != null)
                {
                    return StatusCode(result.StatusCode != 0 ? result.StatusCode : 200, new BaseResponseApi<TTypeResult, TTypeException> { Value = new BaseResponseApiContent<TTypeResult, TTypeException> { Result = result.Result, ListNotification = result.ListNotification } });
                }
                else
                    return StatusCode(result.StatusCode != 0 ? result.StatusCode : 400, new BaseResponseApi<TTypeResult, TTypeException> { Value = new BaseResponseApiContent<TTypeResult, TTypeException> { Exception = result.Exception, ListNotification = result.ListNotification } });
            }
            catch (BaseResponseException ex)
            {
                return await BaseResponseExceptionAsync(ex);
            }
            catch (Exception ex)
            {
                _apiDataService?.RemoveApiDataRequest(_guidApiDataRequest);
                return BadRequest(new BaseResponseApi<TTypeResult, TTypeException> { Value = new BaseResponseApiContent<TTypeResult, TTypeException> { Result = default, ListNotification = [new($"Houve um problema interno com o servidor. {ex.Message}", EnumMessageType.Negative)] } });
            }
        }
        else
        {
            _apiDataService?.RemoveApiDataRequest(_guidApiDataRequest);
            return BadRequest(new BaseResponseApi<TTypeResult, TTypeException> { Value = new BaseResponseApiContent<TTypeResult, TTypeException> { ListNotification = result.ListNotification } });
        }
    }

    [NonAction]
    public async Task<ActionResult> ResponseAsync<ResponseType>(ResponseType result)
    {
        if (_service != null)
            ListNotification.AddRange(_service?.ListNotification!);

        List<Notification> listNegativeNotification = (from i in ListNotification ?? [] where i.MessageType == EnumMessageType.Negative select i).ToList();

        if (listNegativeNotification.Count == 0)
        {
            try
            {
                return Ok(new BaseResponseApi<ResponseType, string> { Value = new BaseResponseApiContent<ResponseType, string>() { Result = result } });
            }
            catch (BaseResponseException ex)
            {
                return await BaseResponseExceptionAsync(ex);
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
        else
        {
            return BadRequest(listNegativeNotification);
        }
    }

    [NonAction]
    public async Task<ActionResult> BaseResponseExceptionAsync(BaseResponseException ex)
    {
        return await Task.FromResult(BadRequest(new { Value = new { Result = (object?)default, ListNotification = ex.Incidents } }));
    }

    [NonAction]
    public async Task<ActionResult> ResponseExceptionAsync(Exception ex)
    {
        return await Task.FromResult(BadRequest(new { Value = ex.Message }));
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
public class BaseController_1<TIService>(IApiDataService apiDataService, TIService service) : BaseController<TIService, object, object, BaseInputIdentityUpdate_0, object, object>(apiDataService, service)
    where TIService : IBaseService_0
{ }
#endregion