using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORMDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            

            IDbConnection conn = new MySqlConnection(connString);

            var productRepo = new DapperProductRepository(conn);
            
            productRepo.CreateProduct("Test", 1.99, 1);

            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId} {product.Name} {product.Price}"); 
            }



        }
    }
}