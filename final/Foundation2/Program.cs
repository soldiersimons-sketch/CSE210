using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Rexburg", "Idaho", "USA");
        Customer customer1 = new Customer("Sarah Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P100", 800.00, 1));
        order1.AddProduct(new Product("Mouse", "P101", 25.00, 2));

        Address address2 = new Address("456 King Street", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("James Wilson", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "P102", 75.00, 1));
        order2.AddProduct(new Product("Monitor", "P103", 250.00, 2));

        List<Order> orders = new List<Order> { order1, order2 };
        Console.WriteLine("ONLINE ORDERING SYSTEM");
        Console.WriteLine("======================");

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"\nORDER #{orderNumber}");
            Console.WriteLine("----------------------");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotal():F2}");
            Console.WriteLine("======================");
            orderNumber++;
        }
    }
}
