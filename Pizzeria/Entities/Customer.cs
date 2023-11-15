namespace Pizzeria.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public Customer() { }

        public Customer(int id, string name, string phone, string adress)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Adress = adress;
        }
    }


}
