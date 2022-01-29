using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.abstractions;
using System;
using System.Threading.Tasks;

namespace RapidPayAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IPaymentService _paymentService;

        public CardController(ICardService cardService, IPaymentService paymentService)
        {
            _cardService = cardService;
            _paymentService = paymentService;
        }

        [HttpPost("card")]
        public async Task<IActionResult> CreateCreditCard(CardDto card)
        {
            try
            {
                await _cardService.Create(card);
                return NoContent();
            }
            catch (ApplicationException appEx)
            {
                return BadRequest(appEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("pay")]
        public async Task<IActionResult> MakePayment(PaymentDto data)
        {
            try
            {
                await _paymentService.Pay(data);
                return NoContent();
            }
            catch (ApplicationException appEx)
            {
                return BadRequest(appEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("card/get-balance")]
        public async Task<ActionResult<BalanceDto>> GetBalance(string cardNumber)
        {
            try
            {
                return Ok(await _paymentService.GetBalance(cardNumber));

            }
            catch (ApplicationException appEx)
            {
                return BadRequest(appEx.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
