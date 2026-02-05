namespace Lab_1
{

    class BankAccount
    {
        private string accountNumber;
        private string ownerName;
        private double balance;

        public BankAccount(string accountNumber, string ownerName, double balance)
        {
            this.accountNumber = accountNumber;
            this.ownerName = ownerName;
            this.balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
        }

        public void Transfer(double amount, BankAccount targetAccount)
        {
            if (amount > 0 && amount <= balance)
            {
                this.balance -= amount;
                targetAccount.balance += amount;
            }
        }

        public double GetBalance()
        {
            return balance;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Owner: {ownerName}, Balance: ${balance}");
        }
    }


    static class ArrayUtils
    {
        public static void Reverse<T>(T[] arr)
        {
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }
            for (int i = 0, j = arr.Length - 1; i < j; i++, j--)
            {
                T temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        public static T FindMax<T>(T[] arr)
            where T : IComparable<T>
        {
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }
            var max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(max) > 0)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public static T FindMin<T>(T[] arr)
            where T : IComparable<T>
        {
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }
            var min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(min) < 0)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        public static bool IsSorted<T>(T[] arr)
            where T : IComparable<T>
        {
            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i].CompareTo(arr[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int CountOccurrences<T>(T[] arr, T value)
        {
            var count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(value))
                    count++;
            }
            return count;
        }

        public static T[] Merge<T>(T[] arr1, T[] arr2)
            where T : IComparable<T>
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();

            T[] result = new T[arr1.Length + arr2.Length];

            int i = 0, j = 0, k = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i].CompareTo(arr2[j]) <= 0)
                {
                    result[k++] = arr1[i++];
                }
                else
                {
                    result[k++] = arr2[j++];
                }
            }

            while (i < arr1.Length)
            {
                result[k++] = arr1[i++];
            }

            while (j < arr2.Length)
            {
                result[k++] = arr2[j++];
            }

            return result;
        }

        internal class Program
        {

            static int[] ArrayRotation(int[] array, int k)
            {
                var n = array.Length;
                int[] result = new int[n];
                int index = 0;
                for (int i = n - k; i < n; i++)
                {
                    result[index] = array[i];
                    index++;
                }
                for (int i = 0; i < n - k; i++)
                {
                    result[index] = array[i];
                    index++;
                }

                return result;
            }

            static int[,] spiralMatrix(int n = 3)
            {
                int[,] result = new int[n, n];
                int top = 0, bottom = n - 1, left = 0, right = n - 1;
                int row = 0, col = 0;
                int direction = 0;
                for (int i = 0; i < n * n; i++)
                {
                    result[row, col] = i;

                    if (direction == 0) // right
                    {
                        if (col < right)
                            col++;
                        else
                        {
                            direction = 1;
                            top++;
                            row++;
                        }
                    }
                    else if (direction == 1) // down
                    {
                        if (row < bottom)
                            row++;
                        else
                        {
                            direction = 2;
                            right--;
                            col--;
                        }
                    }
                    else if (direction == 2) // left
                    {
                        if (col > left)
                            col--;
                        else
                        {
                            direction = 3;
                            bottom--;
                            row--;
                        }
                    }
                    else if (direction == 3) // up
                    {
                        if (row > top)
                            row--;
                        else
                        {
                            direction = 0;
                            left++;
                            col++;
                        }
                    }
                }

                return result;
            }

            static int[][] pascal(int n)
            {
                int[][] array = new int[n][];
                array[0] = new int[1] { 1 };
                for (int i = 1; i < n; i++)
                {
                    array[i] = new int[i + 1];
                    var arrlen = array[i].Length;
                    array[i][0] = 1;
                    array[i][arrlen - 1] = 1;
                    for (int j = 1; j < arrlen - 1; j++)
                    {
                        array[i][j] = array[i - 1][j - 1] + array[i - 1][j];
                    }
                }
                return array;
            }


            static int[] bubbleSort(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            int temp = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                return arr;
            }


            static int[] selectionSort(int[] arr)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    var minIndex = i;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[minIndex] > arr[j])
                        {
                            minIndex = j;
                        }
                    }
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }

                return arr;
            }



            static void Main(string[] args)
            {
                // task 1
                int[] array = { 1, 2, 3, 4, 5 };
                var results = Program.ArrayRotation(array, 2);
                foreach (var item in results)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("------------------------------------------");


                // task 2
                var t2 = Program.spiralMatrix(3);
                foreach (var item in t2)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("------------------------------------------");


                // task 3
                var t3 = Program.pascal(6);
                foreach (var item in t3)
                {
                    foreach (var item1 in item)
                    {
                        Console.Write($"{item1} ");

                    }
                    Console.WriteLine("");

                }

                Console.WriteLine("------------------------------------------");

                // task 4 
                int[] t4 = new int[] { 5, 6, 4, 2, 9, 7, 2, 6, 7, 6, 1, 2, 4 };
                t4 = Program.bubbleSort(t4);
                foreach (var item in t4)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine("");

                Console.WriteLine("------------------------------------------");

                // task 4
                int[] t42 = new int[] { 5, 6, 4, 2, 9, 7, 2, 6, 7, 6, 1, 2, 4 };
                t42 = Program.selectionSort(t42);
                foreach (var item in t42)
                {
                    Console.Write($"{item} ");
                }


                // task 5 


                Console.WriteLine("");

                Console.WriteLine("------------------------------------------");

                BankAccount account1 = new BankAccount("A001", "Ahmed", 5000);
                BankAccount account2 = new BankAccount("A002", "Sara", 3000);

                account1.Deposit(1000);

                account1.Withdraw(500);

                account1.Transfer(2000, account2);

                account1.DisplayInfo();

                account2.DisplayInfo();


                // task 8 

                Console.WriteLine("Enter a sentence:");
                string input = Console.ReadLine();

                string lower = input.ToLower();

                string[] words = lower.Split(" ");

                Dictionary<string, int> count = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    if (count.ContainsKey(word))
                        count[word]++;
                    else
                        count[word] = 1;
                }
                var sorted = new List<KeyValuePair<string, int>>(count);
                sorted.Sort((a, b) => b.Value.CompareTo(a.Value));

                foreach (var pair in sorted)
                {
                    Console.WriteLine(pair.Key + " = " + pair.Value.ToString());
                }


            }
        }
    }
}
