using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApiComJwtUtilizandoUuid.Shared
{
    public static class ComandosCompartilhados
    {
        public static byte[] RetornarChaveSegredoEmUmArrayDeBytes() {
            var chaveSegredo = Environment.GetEnvironmentVariable("JWT_KEY_SECRET");
            return !string.IsNullOrEmpty(chaveSegredo) ? 
                    System.Text.Encoding.ASCII.GetBytes(chaveSegredo) : 
                    new byte[0];

        }
    }
}