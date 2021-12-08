using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EtecFilmes.Models
{
    public class Usuario : IdentityUser
    {
        [StringLength(60)]
        public string Nome { get; set; }
        public int LimiteAlteraçãoNomeUsuario { get; set; } = 10;
        public byte[] Avatar { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}