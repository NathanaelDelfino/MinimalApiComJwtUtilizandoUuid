using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MinimalApiComJwtUtilizandoUuid.Contextos.UsuarioContexto.Domain;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using MinimalApiComJwtUtilizandoUuid.Shared;



namespace MinimalApiComJwtUtilizandoUuid.Contextos.Autorizacao.Services
{
    public class TokenService
    {
        public static string GerandoToken(Usuario usuario, bool expire)
        {
            var tokenHandler = new JwtSecurityTokenHandler();            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = expire ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(999),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(ComandosCompartilhados.RetornarChaveSegredoEmUmArrayDeBytes()), SecurityAlgorithms.HmacSha256Signature),

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    usuario.Acessos != null && usuario.Acessos.Count > 0 ? 
                            new Claim(ClaimTypes.Role, string.Join(",", usuario.Acessos)) : new Claim(ClaimTypes.Role, "")
                } )
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }   
    }
}