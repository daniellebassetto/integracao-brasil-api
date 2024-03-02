using IntegracaoBrasilApi.Arguments;
using IntegracaoBrasilApi.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoBrasilApi.Api.Controllers;

[Route("api/[controller]")]
public class UserController(IUserService service) : BaseController<IUserService, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser, InputIdentifierUser>(service) { }