using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****\n");
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo{Name = "Mac's Coffe", Description = "Coffe with TEETH", NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo{ Name = "Crunchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73}
            };
            SelectEverything(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescription(itemsInStock);
            AlphabetizeProductNames(itemsInStock);
            DisplayFiff();
            DisplayIntersection();
            DisplayUnion();
            DisplayConcatNoDups();
            AggregationOps();
        }
        static void SelectEverything(ProductInfo[] products)
        {
            Console.WriteLine("All product details:");
            var allProduct = from p in products select p;
            foreach (var prod in allProduct)
            {
                Console.WriteLine(prod.ToString());
            }
        }
        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");
            var overstock = from p in products where p.NumberInStock > 25 select p;
            foreach (var prod in overstock)
            {
                Console.WriteLine(prod.ToString());
            }
        }
        static void GetNamesAndDescription(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var item in nameDesc)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            var subset = from p in products orderby p.Name select p;
            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
        }
        static void DisplayFiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach(string s in carDiff)
                Console.WriteLine(s);
        }
        static void DisplayIntersection()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c).Intersect(from c2 in yourCars select c2);
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s);
        }
        static void DisplayUnion()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            // Get the union of these containers.
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);
            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Prints all common members.
        }
        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            // Prints:
            // Yugo Aztec BMW Saab.
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s);
        }
        static void AggregationOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 8.2 };
            Console.WriteLine("Max temp: {0}", (from t in winterTemps select t).Max());
            Console.WriteLine("Min yemp: {0}", (from t in winterTemps select t).Min());
            Console.WriteLine("Avarage temp: {0}", (from t in winterTemps select t).Average());
            Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
        }
    }
}
