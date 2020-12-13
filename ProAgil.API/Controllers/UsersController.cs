using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProAgil.API.Controllers.Base;
using ProAgil.Application.Interfaces;
using ProAgil.Application.ViewModels;
using ProAgil.Domain.Identity;
using System;
using System.Threading.Tasks;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(UserViewModel userViewModel)
        {
            try
            {
                var user = _mapper.Map<User>(userViewModel);
                var result = await _userManager.CreateAsync(user, userViewModel.Password);
                var userToReturn = _mapper.Map<UserViewModel>(user);

                if (result.Succeeded)
                {
                    return Created("", userToReturn);
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao cadastrar usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel, [FromServices]IConfiguration configuration)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLoginViewModel.UserName);
                if (user == null) return NotFound("Usuário/Senha incorreto");
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginViewModel.Password, false);
                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userLoginViewModel.UserName.ToUpper());
                    var userToReturn = _mapper.Map<UserLoginViewModel>(appUser);
                    var token = await _tokenService.Generate(appUser, configuration.GetSection("AppSettings:Token").Value);
                    return Ok(new
                    {
                        token,
                        user = userToReturn
                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao logar. Erro: {ex.Message}");
            }
        }
    }
}
