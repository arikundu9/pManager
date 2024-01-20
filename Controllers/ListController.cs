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
    public class ListController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly IMapper _mapper;
        private readonly IListService _listService;

        public ListController(IConfiguration configuration, IListService listService, IMapper mapper)
        {
            Configuration = configuration;
            _mapper = mapper;
            _listService = listService;
        }

        /// <summary>
        /// Get list of list unconditionally.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                List<ListModel> allBoards = await _listService.GetAllAsync();
                return Ok(new { success = true, data = allBoards });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
                throw;
            }
        }

        [HttpPost]
        public ActionResult Post(ListInsertDto list)
        {
            try
            {
                _listService.Add(list);
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
