using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Xuesky.Common.JWT
{
    public static class CreateToken
    {
        public static string GetToken(string name, string pwd,string role)
        {
            //身份元素
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,name), 
                new Claim(ClaimTypes.Role,role), 
            };
            //声明身份
            var identity = new ClaimsIdentity(claims);
            //持有者
            var principal = new ClaimsPrincipal();
            //对称秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecrectKey));
            //签名证书(秘钥，加密算法)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //生成token  [注意]需要nuget添加Microsoft.AspNetCore.Authentication.JwtBearer包，并引用System.IdentityModel.Tokens.Jwt命名空间
            var token = new JwtSecurityToken(JwtSettings.Issuer, JwtSettings.Audience, claims, DateTime.Now, DateTime.Now.AddMinutes(30), creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
