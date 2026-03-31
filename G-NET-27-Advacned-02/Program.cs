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

        //  TASK 03.1 – Print Reports
        //  Delegate used: Action<Product>
        //  Why: Action<T> represents a void operation on T. The caller
        //  decides what to print; this method just iterates – no output
        //  logic is hard-coded here.
        static void PrintReport(List<Product> products, Action<Product> print)
        {
            foreach (var p in products) print(p);
        }

        //  TASK 03.2 – Transform Products
        //  Delegate used: Func<Product, string>
        //  Why: Func<TIn, TOut> maps each product to any output type.
        //  The transformation logic lives in the lambda, not here, so
        //  new formats need zero changes to this method.
        static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
        {
            var result = new List<string>();
            foreach (var product in products) 
                result.Add(transform(product));
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


            //  TASK 03.1 – Print Reports

            Console.WriteLine("\n===== Task 03.1: Print Reports =====\n");

            // Scenario 1 – Short Report
            Console.WriteLine("-- Short Report --");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            // Scenario 2 – Detailed Report
            Console.WriteLine("\n-- Detailed Report --");
            PrintReport(catalog,
                p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

            //  TASK 03.2 – Transform Products

            Console.WriteLine("\n===== Task 03.2: Transform Products =====\n");

            // Scenario 3 – Summary List  
            Console.WriteLine("-- Summary List --");
            var summaries = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (var s in summaries) Console.WriteLine(s);

            // Scenario 4 – Price Label  
            Console.WriteLine("\n-- Price Labels --");
            var labels = TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (var l in labels) Console.WriteLine(l);

        }
    }
}
