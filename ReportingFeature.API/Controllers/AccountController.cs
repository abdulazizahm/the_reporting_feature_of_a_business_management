using AutoMapper;
using AWP.DAL.Models;
using AWP.REPO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using AWP.Business;
using AWP.DTO.Auth;
using AWP.DTO;
using Microsoft.AspNetCore.Authorization;
using AWP.DTO.Helps;
using System.IdentityModel.Tokens.Jwt;
using AWP.DTO.Accounts;

namespace AWP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly AccountManager AccountManager;

        public AccountController(AccountManager AccountManager) 
        {
            this.AccountManager = AccountManager;
        }
        [HttpGet("Profile")]
        public async Task<Response> GetUserProfile() 
        {
            var userId = User.Claims.Where(x => x.Properties.Any(c => c.Value == JwtRegisteredClaimNames.Sub)).FirstOrDefault()?.Value;
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(userId))
            {
                var lang = Request.Headers["Accept-Language"].ToString();
                return await AccountManager.GetUserProfile(userId!);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege = "Please enter correct data" + string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))


                };
            }
        }

        [HttpPut("UpdateProfile")]
        public async Task<Response> UpdateProfile(UserProfileDto userProfileDto)
        {
            var userId = User.Claims.Where(x => x.Properties.Any(c => c.Value == JwtRegisteredClaimNames.Sub)).FirstOrDefault()?.Value;
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(userId))
            {
                var lang = Request.Headers["Accept-Language"].ToString();
                return await AccountManager.EditUserProfile(userProfileDto, userId!);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege = "Please enter correct data" + string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
                };
            }
        }

        [HttpPut("ChangePassword")]
        public async Task<Response> UpdatePassword([FromBody]ChangePasswordDto PasswordDto)
        {
            var userId = User.Claims.Where(x => x.Properties.Any(c => c.Value == JwtRegisteredClaimNames.Sub)).FirstOrDefault()?.Value;
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(userId))
            {
                return await AccountManager.ChangePassword(PasswordDto, userId!);
            }
            else
            {
                return new Response
                {
                    ResponseCode = Enum.ResponseTypeEnum.Error,
                    ResultMessege = "Please enter correct data " + string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))


                };
            }
        }


    }
}
