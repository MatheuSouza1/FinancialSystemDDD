using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialUserController : ControllerBase
    {
        private readonly IFinancialUser financialUser;
        private readonly IFinancialUserService financialUserService;

        public FinancialUserController(IFinancialUser financialUser, IFinancialUserService financialUserService)
        {
            this.financialUser = financialUser;
            this.financialUserService = financialUserService;
        }

        [Produces("application/json")]
        [HttpGet("/api/GetFinancialUser")]

        public async Task<ActionResult<List<FinancialUser>>> ListUsersFromSystem(int SystemId)
        {
            var users = await financialUser.ListAllFinancialUserFromSystem(SystemId);
            return Ok(users);
        }

        [Produces("application/json")]
        [HttpPost("/api/RegisterFinancialUser")]
        public async Task<ActionResult> RegisterFinancialUser(int systemId, string email)
        {
            try
            {
                await financialUserService.RegisterUser(new FinancialUser
                {
                    SystemId = systemId,
                    Email = email,
                    Admin = false,
                    ActualSystem = true
                });
                return Ok("Usuario adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
