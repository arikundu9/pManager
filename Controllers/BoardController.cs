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
    public class BoardController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly IMapper _mapper;
        private readonly IBoardService _boardService;

        public BoardController(IConfiguration configuration, IBoardService boardService, IMapper mapper)
        {
            Configuration = configuration;
            _mapper = mapper;
            _boardService = boardService;
        }

        /// <summary>
        /// Get list of boards unconditionally.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                List<BoardModel> allBoards = await _boardService.GetAllAsync();
                return Ok(new { success = true, data = allBoards });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
                throw;
            }
        }

        [HttpPost]
        public ActionResult Post(BoardDto board)
        {
            try
            {
                _boardService.Add(board);
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
