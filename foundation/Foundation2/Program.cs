class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Product product1 = new Product("Laptop", "A123", 1000, 1);
        Product product2 = new Product("Mouse", "B456", 20, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

        // Add more orders similarly...
    }
}
