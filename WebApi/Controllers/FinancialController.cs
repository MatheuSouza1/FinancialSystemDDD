using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly IFinancial Financial;
        private readonly IFinancialService FinancialService;

        public FinancialController(IFinancial financial, IFinancialService financialService)
        {
            Financial = financial;
            FinancialService = financialService;
        }

        [Produces("application/json")]
        [HttpGet("/api/GetSystemsFromUser")]
        public async Task<ActionResult<List<Financial>>> GetSystemsFromUser(string email)
        {
            var result = await Financial.GetAllFinancialSystemsFromUser(email);
            if(result.IsNullOrEmpty())
            {
                return NotFound("Nâo foi encontrado nenhum sistema para este usuário.");
            }
            return Ok(result);
        }

        [Produces("application/json")]
        [HttpPost("/api/AddSystem")]
        public async Task<ActionResult<Financial>> AddSystem(Financial financial)
        {
            try
            {
                FinancialService.AddFinancialSystem(financial);
                return Ok("Usuario adicionado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpPut("/api/UpdateSystem")]
        public async Task<ActionResult> UpdateSystem(Financial financial)
        {
            try
            {
                await FinancialService.UpdateFinancialSystem(financial);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }
    }
}
