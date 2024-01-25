using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApiComJwtUtilizandoUuid.Contextos.UsuarioContexto.Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public List<string> Acessos { get; private set; }

        public Usuario(Guid id, string nome, string senha, List<string> acessos)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Acessos = acessos;
        }
                    
        public Usuario(string nome, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Senha = senha;
            Acessos = new List<string>();
        }



        public void AddNovaRole(string role)
        {
            if(Acessos == null)
                Acessos = new List<string>();

            if(Acessos.Contains(role))
                throw new Exception("O usuário já possui esse acesso!");
                
            Acessos.Add(role);
        } 

        public void RemoveRole(string role)
        {
            if(Acessos == null)
                Acessos = new List<string>();

            if(!Acessos.Contains(role))
                throw new Exception("O usuário não possui esse acesso!");
                
            Acessos.Remove(role);
        }

        public bool EhValido()
        {
            return !string.IsNullOrEmpty(Nome) 
                && !string.IsNullOrEmpty(Senha);
        }
    }
}