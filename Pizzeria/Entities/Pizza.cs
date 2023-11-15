namespace Pizzeria.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Descreption { get; set; }
        public double Price { get; set; }


        public Pizza() { }
        public Pizza(int id, string descreption)
        {
            Id = id;
            Descreption = descreption;
        }
    }
}
