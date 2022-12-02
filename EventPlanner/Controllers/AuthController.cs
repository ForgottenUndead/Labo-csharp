
using EventPlanner.Mappers;
using EventPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly TokenManager _tokenManager;

        public AuthController(IMemberService memberService, TokenManager tokenManager)
        {
            _memberService = memberService;
            _tokenManager = tokenManager;
        }

        [HttpPost("register")]
        public IActionResult Register(AuthRegisterViewModel form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                _memberService.Register(form.ToBLL());
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(AuthLoginViewModel form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                Member? connectedUser = _memberService.Login(form.Idenfifiant, form.Password);
                if (connectedUser == null) return BadRequest("Utilisateur inexistant");

                ConnectedUserDTO user = connectedUser.ToDTO();
                user.Token = _tokenManager.GenerateToken(connectedUser);

                return Ok(user);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize("connected")]
        [HttpGet]
        public IActionResult Get()
        {
            string id = "";
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                id = identity.Claims.First(x => x.Type == ClaimTypes.GivenName).Value;
            }
            return Ok("ça fonctionne et je suis un king " + id);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_memberService.GetById(id));
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(_memberService.GetAll());
    }
    
}
