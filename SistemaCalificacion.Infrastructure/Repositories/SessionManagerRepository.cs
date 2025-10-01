using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using SistemaCalificacion.Application.DTOs;
using SistemaCalificacion.Application.Interfaces;
using SistemaCalificacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SistemaCalificacion.Infrastructure.Repositories
{
    public class SessionManagerRepository : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public SessionManagerRepository( IHttpContextAccessor httpContextAccessor) { 
           _httpContextAccessor = httpContextAccessor;
        }

      
        public async Task SignInAsync(User user)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Nombre),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Username" , user.Username.ToString()),
                new Claim("Estatus" , user.Status.ToString())

            };

            var identity = new ClaimsIdentity(claims , "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            await _httpContextAccessor.HttpContext!.SignInAsync("MyCookieAuth", claimsPrincipal);

        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync("MyCookieAuth");
        }
    }
}
