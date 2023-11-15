using Microsoft.AspNetCore.Mvc;
using Pizzeria.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly DataContex _contex;

        public CustomerController(DataContex contex)
        {
            _contex = contex;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return _contex.customers;
        }

        //GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            if (id > _contex.counterC || id < 1) { return StatusCode(404, "Customer not found"); }
            return _contex.customers.Find(c => c.Id == id);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Customer c)
        {
            _contex.customers.Add(new Customer { Name = c.Name, Id = _contex.counterC++, Adress = c.Adress, Phone = c.Phone });


        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer c)
        {
            Customer cu = _contex.customers.Find(x => x.Id == id);
            if (cu != null)
            {
                cu.Adress = c.Adress;
                cu.Phone = c.Phone;
                cu.Name = c.Name;
            }
        }

        //// DELETE api/<EventsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    //var e = events.Find(eve => eve.Id == id);
        //    //events.Remove(e);
        //}
    }
}

