using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Dtos
{
    public class EventoDto
    {
        public int EventoId { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Local é entre 3 e 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage="O tema deve ser Preenchido")]
        public string Tema { get; set; }
        [Range(1, 120000, ErrorMessage ="Quantidade de Pessoas é entre 2 e 120000")]
        public int QtdPessoas { get; set; }
        [Phone]
        public string Telefone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<LoteDto> Lote { get; set; }
        public List<RedeSocialDto> redeSocial { get; set; }
        public List<PalestranteDto> palestrante { get; set; }
        public string ImagemUrl { get; set; }
    }
}
