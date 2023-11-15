namespace Pizzeria.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public List<Pizza> Pizzaslst { get; set; } = new List<Pizza>();
        public DateTime OrderDate { get; set; }


        public Order() { }

        public Order(int id, int idCustomer, List<Pizza> pizzaslst, DateTime orderDate)
        {
            Id = id;
            IdCustomer = idCustomer;
            Pizzaslst = pizzaslst;
            OrderDate = orderDate;
        }
    }
}
