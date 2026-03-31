namespace G_NET_27_Advacned_02
{
    internal class Program
    {
        //  TASK 01 – Smart Product Search
        //  Delegate used: Func<Product, bool>
        //  Why: Func<TIn, TOut> lets any caller supply a custom filter
        //  as a lambda without changing this method. New filter rules
        //  plug in without modifying existing code (Open/Closed Principle).
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            var result = new List<Product>();
            foreach (var product in products)
                if (filter(product)) 
                    result.Add(product);
            return result;
        }

        static void Main(string[] args)
        {
            List<Product> catalog = new ()
            {
            new Product("Laptop",       "Electronics", 1200, 10),
            new Product("Phone",        "Electronics",  800, 25),
            new Product("T-Shirt",      "Clothing",      30, 100),
            new Product("Jeans",        "Clothing",      60,  50),
            new Product("chocolate",    "food",      5,  200),
            new Product("Coffe Beans",    "food",      15,  80),
            new Product("C# Book",     "Books",      45,   30),
            new Product("Novel",       "Books",  20,   60),
            new Product("Headphones",   "Electronics",   150,  40),
            new Product("Jacket",       "Clothing",      120,   15),
            };

            //  TASK 01 – Four lambda searches

            Console.WriteLine("===== Task 01: Smart Product Search =====\n");

            // Search 1 – All Electronics
            Console.WriteLine("-- Electronics --");
            var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            foreach (var p in electronics)
                Console.WriteLine($"  {p.Name} - ${p.Price} (Stock: {p.Stock})");

            // Search 2 – Cheaper than $50
            Console.WriteLine("\n-- Under $50 --");
            var cheap = SearchProducts(catalog, p => p.Price < 50);
            foreach (var p in cheap)
                Console.WriteLine($"  {p.Name} - ${p.Price} (Stock: {p.Stock})");

            // Search 3 – In stock (Stock > 0)
            Console.WriteLine("\n--  In stock --");
            var inStock = SearchProducts(catalog, p => p.Stock > 0);
            foreach (var p in inStock)
                Console.WriteLine($"  {p.Name} - ${p.Price} (Stock: {p.Stock})");

            // Search 4 – Clothing under $100
            Console.WriteLine("\n-- Clothing under $100 --");
            var clothingUnder100 = SearchProducts(catalog,
                p => p.Category == "Clothing" && p.Price < 100);
            foreach (var p in clothingUnder100)
                Console.WriteLine($"  {p.Name} - ${p.Price} (Stock: {p.Stock})");

        }
    }
}
