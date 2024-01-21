using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pMan.BAL.Interface;
using pMan.DTOs;
using pMan.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace pMan.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly IMapper _mapper;
        private readonly ICardService _cardService;

        public CardController(IConfiguration configuration, ICardService cardService, IMapper mapper)
        {
            Configuration = configuration;
            _mapper = mapper;
            _cardService = cardService;
        }

        /// <summary>
        /// Get list of Crads unconditionally.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                List<CardModel> allCrads = await _cardService.GetAllAsync();
                return Ok(new { success = true, data = allCrads });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
                throw;
            }
        }

        [HttpPost]
        public ActionResult Post(CardInsertDto card)
        {
            try
            {
                _cardService.Add(card);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
                throw;
            }
        }
    }
}
