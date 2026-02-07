using static Lab_6.Program;
using static Lab_6.TemperatureSensor.Program;

namespace Lab_6
{
    public delegate double MathOp(double x, double y);

    public delegate void NotifyHandler(string s);

    public delegate bool IntFilter(int value);

    public delegate void TemperatureHandler(string msg, double value);
    class Calc
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }
        public static double Sub(double x, double y)
        {
            return x - y;
        }
        public static double Mul(double x, double y)
        {
            return x * y;
        }
        public static double Div(double x, double y)
        {
            try
            {
                return x / y;
            }
            catch (DivideByZeroException e)
            {
                throw new Exception("Cant divide by zero ya ahbl");
            }
        }
    }



    class TemperatureSensor
    {
        public event TemperatureHandler TemperatureHigh;

        public void SetTemperature(double temp)
        {
            if (temp > 30)
            {
                if (TemperatureHigh != null)
                {
                    TemperatureHigh("Danger! It's hot!", temp);
                }
            }
        }
    }

    public class TemperatureMonitor
    {
        public void OnHighTemperature(string msg, double temp)
        {
            Console.WriteLine($"[Monitor Alert]: {msg} (Current Temp: {temp})");
        }
    }
    internal class Program
    {

        public static void SendEmail(string s)
        {
            Console.WriteLine(s + " From Send Email");
        }
        public static void SendSMS(string s)
        {
            Console.WriteLine(s + " From Send SMS");
        }

        public static List<int> FilterArray(int[] array, IntFilter filter)
        {
            List<int> list = new List<int>();
            foreach (var item in array)
            {
                if (filter(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        public static bool isGreaterThan2(int x)
        {
            return x > 2;
        }
        static void Main(string[] args)
        {
            // task 1
            MathOp op = Calc.Add;

            var res = op(5, 7);
            Console.WriteLine(res);

            op = Calc.Mul;
            res = op(5, 7);
            Console.WriteLine(res);
            Console.WriteLine("-------------------------------------------------------------------");
            // task 2
            NotifyHandler notify = Program.SendEmail;
            notify("Send it Succufully");

            notify += Program.SendSMS;
            notify("Send it Succufully");

            notify -= Program.SendEmail;

            notify("Send it Succufully");
            Console.WriteLine("-------------------------------------------------------------------");

            // task 3
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var even = FilterArray(numbers, IsEven);
            foreach (var item in even)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------");
            var odd = FilterArray(numbers, IsOdd);
            foreach (var item in odd)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------------------------------------------");

            // task 4
            even = FilterArray(numbers, delegate (int x) { return x % 2 == 0; });
            foreach (var item in even)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------------------------------------------");

            // task 5 & 6
            List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            numbers2.Sort((a, b) => b.CompareTo(a));
            numbers2.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-----------");
            var x = numbers2.FindAll(x => x % 2 == 0);
            x.ForEach(x => Console.WriteLine(x));


            // task 7
            TemperatureSensor sensor = new TemperatureSensor();
            TemperatureMonitor monitor = new TemperatureMonitor();

            sensor.TemperatureHigh += monitor.OnHighTemperature;

            sensor.SetTemperature(20);

            Console.WriteLine("----------------");

            sensor.SetTemperature(35);

            Console.WriteLine("----------------");

            sensor.TemperatureHigh -= monitor.OnHighTemperature;

            sensor.SetTemperature(45); 
        }
    }
}
