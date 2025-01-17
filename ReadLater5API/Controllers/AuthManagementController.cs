﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReadLater5API.Configuration;
using ReadLater5API.Helpers;
using ReadLater5API.Models.DTOs.Requests;
using ReadLater5API.Models.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater5API.Controllers
{
    [Route("api/[controller]")] //api/AuthManagement
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        IJwtHelper _jwtHelper;

        public AuthManagementController(UserManager<IdentityUser> userManager, IJwtHelper jwtHelper)
        {
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if(existingUser != null)
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string> { "Email already in use" },
                        Success = false
                    });

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if(isCreated.Succeeded)
                {
                    var jwtToken = _jwtHelper.GenerateJwtToken(newUser);
                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(e => e.Description).ToList(),
                        Success = false
                    });
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string> { "Invalid payload"},
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if(existingUser != null)
                {
                    var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
                    if (isCorrect)
                    {
                        var jwtToken = _jwtHelper.GenerateJwtToken(existingUser);
                        return Ok(new RegistrationResponse()
                        {
                            Success = true,
                            Token = jwtToken
                        });
                    }

                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string> { "Invalid login request" },
                        Success = false
                    });
                }

                return BadRequest(new RegistrationResponse()
                {
                    Errors = new List<string> { "Invalid login request" },
                    Success = false
                });
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string> { "Invalid payload" },
                Success = false
            });
        }
    }
}
