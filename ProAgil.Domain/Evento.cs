using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.Domain
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Lote> Lote { get; set; }
        public List<RedeSocial> redeSocial { get; set; }
        public List<PalestranteEvento> palestranteEventos { get; set; }
        public string ImagemUrl { get; set; }
    }
}
