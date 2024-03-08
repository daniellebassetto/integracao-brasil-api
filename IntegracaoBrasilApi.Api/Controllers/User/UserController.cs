using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.ApiManagement;
using IntegracaoBrasilApi.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Api.Controllers;

[Route("api/[controller]")]
public class UserController(IApiDataService apiDataService, IUserService service) : BaseController<IUserService, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser, InputIdentifierUser>(apiDataService, service) 
{
    #region IgnoreApi
    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<OutputUser>>> GetAll()
    {
        return base.GetAll();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<OutputUser>>> GetByIdentifier(InputIdentifierUser inputIdentifier)
    {
        return base.GetByIdentifier(inputIdentifier);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<OutputUser>>>> GetListByListIdentifier(List<InputIdentifierUser> listInputIdentifier)
    {
        return base.GetListByListIdentifier(listInputIdentifier);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<OutputUser>>> GetListByListId(List<string> listId)
    {
        return base.GetListByListId(listId);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<string>>>> Create(List<InputCreateUser> listInputCreate)
    {
        return base.Create(listInputCreate);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<string>>>> Update(List<InputIdentityUpdateUser> listInputIdentityUpdate)
    {
        return base.Update(listInputIdentityUpdate);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponse<List<bool>>>> Delete(List<string> listId)
    {
        return base.Delete(listId);
    }
    #endregion
}