namespace lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task 1 and 2
            Date d = new Date(2026, 2, 1);
            Date d1 = new Date(2026, 2, 1);
            d.displayDate();
            Console.WriteLine(Date.counter);


            Console.WriteLine("---------------------------------------------------");
            // task 3
            Employee emp = new Employee(1, "Seif", 5500);
            Manger mgr = new Manger(1, "Seif", 5500, 10000, 5);

            emp.displayInfo();
            mgr.displayInfo();

            Console.WriteLine("---------------------------------------------------");

            // task 4
            Shape[] shapes = { new Circle(5), new Rectangle(4, 6), new Triangle(3, 4, 5) };


            foreach (Shape s in shapes)
            {
                Console.WriteLine($"Area: {s.CalculateArea()}");
                Console.WriteLine($"Perimeter: {s.CalculatePerimeter()}");
                Console.WriteLine("---------------------------------------------------");
            }



            // task 5
            //Animal anm = new Animal(); 
            Dog dog = new Dog();
            Bird bird = new Bird();
            dog.makeSound();
            bird.makeSound();
            bird.Sleeping();
            Console.WriteLine("---------------------------------------------------");


            // task 6 
            Robot robot = new Robot();
            robot.charge();
            Console.WriteLine(robot.getBattery());
            robot.move();
            Console.WriteLine(robot.GetSpeed());

            Console.WriteLine("---------------------------------------------------");

            // task 7 
            Student std = new Student(1);
            std.Name = "Mansy";
            std.Age = 23;
            std.display();


            // task 8 
            Account[] accounts ={new SavingsAccount("sa1", "EMan", 1000, 0.05, 500),
                                 new CheckingAccount("ca1", "Mansy", 2000, 1000)};

            foreach (Account acc in accounts)
            {
                acc.Deposit(500);
                acc.ApplyInterest();
                acc.PrintDetails();
                Console.WriteLine("---------------------------------------------------");
            }

        }
    }
}
