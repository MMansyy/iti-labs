using System.Collections;
using System.Collections.Specialized;

namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Person()
            {
                Age = 23,
                City = "Alex",
                FirstName = "Mohamed",
                LastName = "Mansy"
            };


            // task 2
            var r1 = new Rectangle(1)
            {
                Width = 10,
                Height = 5
            };
            Console.WriteLine(r1.Color);
            Console.WriteLine(r1.Unit);
            Console.WriteLine(r1.Area);
            Console.WriteLine("----------------------------------------------------------------------------------");
            // task 3 
            GradeBook g = new GradeBook(10);
            g[0] = 5;
            g[1] = 2.5;

            Console.WriteLine(g[0]);
            Console.WriteLine(g[2]);
            Console.WriteLine("----------------------------------------------------------------------------------");

            // task 4
            var collection = new IndexrsTest();

            collection[0] = "First";
            collection[1] = "Second";
            collection[2] = "Third";

            Console.WriteLine(collection[1]);

            collection["server"] = "localhost";
            collection["port"] = "8080";
            collection["db"] = "mydb";

            string server = collection["server"];
            Console.WriteLine(server);

            // task 5
            ArrayList cart = new ArrayList();

            cart.Add(42);              // int
            cart.Add("Hello");         // string
            cart.Add(3.14);            // double
            cart.Add(DateTime.Now);    // DateTime

            // Remove item
            cart.Remove(42);

            // Reverse order
            cart.Reverse();

            foreach (object item in cart)
            {
                Console.WriteLine(item);
            }


            // task 6 
            var persons = new List<Person>
                {
                 new Person { FirstName = "Mohamed", LastName = "Hussein", Age = 23, City = "Alex" },
                 new Person { FirstName = "Sara",  LastName = "Ali",    Age = 22, City = "Alex" },
                 new Person { FirstName = "Omar",  LastName = "Mostafa",Age = 27, City = "Giza" }
                };

            Person found = persons.Find(x => x.Age.Equals(23));
            found.display();
            var alex = persons.FindAll(x => x.City == "Alex");
            foreach (var item in alex)
            {
                item.display();
            }
            persons.Sort((a, b) => b.Age.CompareTo(a.Age));
            foreach (var item in persons)   
            {
                item.display();
            }


            // task 7
            Calculator calc = new Calculator();

            try
            {
                double result = calc.Divide(10, 0);
                Console.WriteLine(result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format!");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error!");
            }


        }
    }
}

