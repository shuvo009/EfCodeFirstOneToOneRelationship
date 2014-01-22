using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstOneToOneRelationship
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product
            {
                Name = "Name",
                Stock = new Stock()
            };

            var context = new EfContext();
            context.Products.Add(product);
            context.SaveChanges();

            var stock = context.Stocks.Include("Product").FirstOrDefault();

            Console.WriteLine(stock.Product.Name);

            var testProduct = context.Products.Include("Stock").FirstOrDefault();
            Console.WriteLine(testProduct.Stock.Quantity);

            Console.Read();
        }
    }
}
