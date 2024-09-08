using AWP.Business;
using AWP.DTO;
using AWP.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AWP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly AuthManager authManager;
       

        public AuthController(AuthManager authManager)
        {
            this.authManager = authManager;
            
        }
        [HttpPost("Register")]
        public async Task<Response> Register(RegisterVM authUserVM)
        {

            if (ModelState.IsValid)
            {
               // var remoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
              //  var DeviceName = Request.Headers["User-Agent"].ToString();
                return await authManager.Register(authUserVM);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege =   string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                  

                };
            }

        }
        [HttpPost("VerfiyOTP")]
        public async Task<Response> VerfiyOTP(OTPVM OTP)
        {
            if (ModelState.IsValid)
            {
                var UserId = User.Claims.Where(x => x.Properties.Any(c => c.Value == JwtRegisteredClaimNames.Sub)).FirstOrDefault()?.Value;

                return await authManager.VerfiyOTP(OTP,UserId);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)),
                };
            }

        }
        [HttpPost("ResendOTP")]
        public async Task<Response> ResendOTP(ResendOTPVM OTP)
        {
            if (ModelState.IsValid)
            {
                var UserId = User.Claims.Where(x => x.Properties.Any(c => c.Value == JwtRegisteredClaimNames.Sub)).FirstOrDefault()?.Value;
                return await authManager.ResendOTP(OTP, UserId);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)),



                };
            }

        }
        [HttpPost("Login")]
        public async Task<Response> Login(LoginVM authUserVM)
        {

            if (ModelState.IsValid)
            {
                // var remoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                //  var DeviceName = Request.Headers["User-Agent"].ToString();
                return await authManager.Login(authUserVM);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege =   string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))


                };
            }

        }
        [HttpPost("ResetPassword")]
        public async Task<Response> ResetPassword(ResetPasswordVM authUserVM)
        {

            if (ModelState.IsValid)
            {
                // var remoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                //  var DeviceName = Request.Headers["User-Agent"].ToString();
                return await authManager.ResetPassword(authUserVM);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege =  string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))


                };
            }

        }
        [Authorize]
        [HttpGet("UserInfo")]
        public async Task<Response> UserInfo()
        {

            if (ModelState.IsValid)
            {
                var userId = User.Claims.Where(x => x.Properties.Any(c => c.Value == JwtRegisteredClaimNames.Sub)).FirstOrDefault()?.Value;
                return await authManager.UserInfo(userId);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))


                };
            }

        }
    }
}
