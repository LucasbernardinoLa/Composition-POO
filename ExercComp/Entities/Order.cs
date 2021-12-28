using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using ExercComposition.Entities.Enums;

namespace ExercComposition.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();


        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItems(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItems(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem items in Items)
            {
                sum += items.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order sumary");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.AppendLine($"{Client.Name} {Client.BirthDate.ToString("(dd/MM/yyyy)")} {Client.Email}");
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine($"{item.Product.Name}, ${item.Price}, Quantity: {item.Quantity}, ${item.SubTotal()}");
            }
            sb.Append($"Total price: ");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();


        }
    }
}