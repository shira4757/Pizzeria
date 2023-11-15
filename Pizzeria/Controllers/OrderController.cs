using Microsoft.AspNetCore.Mvc;
using Pizzeria.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContex _contex;

        public OrderController(DataContex contex)
        {
            _contex = contex;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _contex.orders;
        }

        //GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            if (id > _contex.counterO || id < 1) { return StatusCode(404, "Customer not found"); }
            return _contex.orders.Find(c => c.Id == id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] Order o)
        {
            //add event to list
            _contex.orders.Add(new Order { Id = _contex.counterO++, OrderDate = o.OrderDate, IdCustomer = o.IdCustomer, Pizzaslst = o.Pizzaslst });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order or)
        {

            //find order by id
            var o = _contex.orders.Find(x => x.Id == id);
            //update properties
            if (o == null)
            {

                o.OrderDate = or.OrderDate;
                o.IdCustomer = or.IdCustomer;
                o.Pizzaslst = or.Pizzaslst;
            }
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var o = _contex.orders.Find(e => e.Id == id);
            if (o == null)
            {
                //  return NotFound();
            }
            _contex.orders.Remove(o);
        }
    }
}
