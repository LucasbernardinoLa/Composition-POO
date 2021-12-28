using System;
using System.Globalization;
using ExercComposition.Entities;
using ExercComposition.Entities.Enums;

namespace ExercComposition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, date);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Product Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Product product = new Product(prodName, prodPrice);
                OrderItem orderItem = new OrderItem(quantity, prodPrice, product);
                order.AddItems(orderItem);
            }
            Console.WriteLine(order);
        }
    }
}