using Microsoft.AspNetCore.Mvc;
using ToyStoreAPI.DAL;
using ToyStoreAPI.DTOs;
using ToyStoreAPI.Services;

namespace ToyStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly AuthService _authService;

        public AuthController(UserRepository userRepository, AuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // Check if user already exists
            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Username already exists" });
            }

            var existingEmail = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingEmail != null)
            {
                return BadRequest(new { message = "Email already exists" });
            }

            // Hash password and create user
            var passwordHash = _authService.HashPassword(request.Password);
            var userId = await _userRepository.CreateUserAsync(request.Username, request.Email, passwordHash);

            if (userId > 0)
            {
                var token = _authService.GenerateJwtToken(request.Username, request.Email, "Customer");
                return Ok(new AuthResponse
                {
                    Token = token,
                    Username = request.Username,
                    Email = request.Email,
                    Role = "Customer"
                });
            }

            return BadRequest(new { message = "Failed to create user" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            if (!_authService.VerifyPassword(request.Password, user.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var token = _authService.GenerateJwtToken(user.Username, user.Email, user.Role);
            return Ok(new AuthResponse
            {
                Token = token,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            });
        }
    }
}
