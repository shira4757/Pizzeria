namespace Pizzeria.Entities
{
    public class DataContex
    {

        public List<Pizza> pizzas;
        public List<Order> orders;
        public List<Customer> customers;
        public int counterP = 1;
        public int counterO = 1;
        public int counterC = 1;
        public DataContex()
        {
            pizzas = new List<Pizza> { new Pizza { Id = counterP++, Descreption = "regular", Price = 20 } };
            orders = new List<Order> { new Order { Id = counterO++, IdCustomer = 1, OrderDate = DateTime.Today, Pizzaslst = { new Pizza { Id = 2, Descreption = "bla", Price = 28 } } } };
            customers = new List<Customer> { new Customer { Id = counterC++, Name = "Eti", Adress = "shivtey israel", Phone = "0556776033" } };
        }
    }
}
