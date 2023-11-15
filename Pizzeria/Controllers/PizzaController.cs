using Microsoft.AspNetCore.Mvc;
using Pizzeria.Entities;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly DataContex _contex;

        public PizzaController(DataContex contex)
        {
            _contex = contex;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Pizza>> Get()
        {
            return _contex.pizzas;
        }

        //GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            if (id > _contex.counterP || id < 1) { return StatusCode(404, "Customer not found"); }
            return _contex.pizzas.Find(c => c.Id == id);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Pizza piz)
        {
            //add Pizza to list
            _contex.pizzas.Add(new Pizza { Id = _contex.counterP++, Price = piz.Price, Descreption = piz.Descreption });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pizza piz)
        {

            //find Pizza by id
            var p = _contex.pizzas.Find(x => x.Id == id);
            if (p != null)
            {
                p.Price = piz.Price;
                p.Descreption = piz.Descreption;
            }
        }

        // DELETE api/<EventsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var cust = customers.Find(c => c.Id == id);
        //    customers.Remove(cust);
        //}
    }
}
