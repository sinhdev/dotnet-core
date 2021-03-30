using System;
// using EFCoreMySql.Models;

namespace EFCoreMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (Models.OrderDBContext context = new Models.OrderDBContext()){
                var order = context.Orders.Find(1);
                Console.WriteLine(order.OrderDate);
            }
        }
    }
}
