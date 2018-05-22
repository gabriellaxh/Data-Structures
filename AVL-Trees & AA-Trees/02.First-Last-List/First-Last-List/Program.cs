using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Wintellect.PowerCollections;

public class Program
{
    static void Main(string[] args)
    {
        FirstLastList<Product> items = new FirstLastList<Product>();
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(0.50m, "candy"));
        items.Add(new Product(1.20m, "cola"));

        
        var returnedItems = items.Min(4).Select(p => p.Title).ToList();

        
        //var expectedItems = new string[] {
        //    "coffee", "candy", "mint drops", "beer" };
        //CollectionAssert.AreEqual(expectedItems, returnedItems);
    }
}

class Product : IComparable<Product>
{
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Product(decimal price, string title)
    {
        this.Price = price;
        this.Title = title;
    }

    public int CompareTo(Product other)
    {
        return this.Price.CompareTo(other.Price);

    }
}
