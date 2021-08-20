using System;
using System.Collections.Generic;

namespace api_desafio21dias.ModelViews
{
    public record HomeView
    {
        public string Informacao => "Bem vindo ao sistema";
        public List<dynamic> Endpoints => new List<dynamic>(){
            new {
                Item = new { Documentacao = "/swagger" }
            },
            new {
                Item = new { Path = "/alunos" }
            }
        };
    }
}
