using Microsoft.AspNetCore.Mvc;
using ProAgil.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public  IEnumerable<Evento> Get()
        {
            return new Evento[] { 
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular e Net",
                    Local = "BH",
                    QtdPessoas = 1,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    Lote = "Primeiro"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Naruto",
                    Local = "SP",
                    QtdPessoas = 2,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    Lote = "Segundo"
                },
            };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <Evento> Get(int id)
        {
            return new Evento[] {
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular e Net",
                    Local = "BH",
                    QtdPessoas = 1,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    Lote = "Primeiro"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Naruto",
                    Local = "SP",
                    QtdPessoas = 2,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    Lote = "Segundo"
                },
            }.FirstOrDefault(x => x.EventoId == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
