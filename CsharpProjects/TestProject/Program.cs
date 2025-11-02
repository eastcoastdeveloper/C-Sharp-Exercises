using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExercisesApp
{
    // ===== Helper classes for later exercises (distinct names to avoid collisions) =====
    public class Phone
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }

        public void Call(string phoneNumber) => Console.WriteLine($"Calling {phoneNumber}...");
        public void Text(string phoneNumber, string message) => Console.WriteLine($"Texting {phoneNumber}: {message}");
    }

    // Exercise 18: constructors with and without parameters
    public class Person18
    {
        public string Name { get; }
        public int Age { get; }

        public Person18()
        {
            Console.WriteLine("Person18(): parameterless constructor invoked.");
            Name = "Unknown";
            Age = 0;
        }

        public Person18(string name)
        {
            Console.WriteLine($"Person18(string): name = {name}");
            Name = name;
            Age = 0;
        }

        public Person18(string name, int age)
        {
            Console.WriteLine($"Person18(string,int): name = {name}, age = {age}");
            Name = name;
            Age = age;
        }
    }

    // Exercise 19: class with no explicit constructor (gets a default parameterless one)
    public class Person19
    {
        public int Age;                 // default 0
        public string Name = "unknown"; // default "unknown"
    }

    // Exercise 20: simple class with a parameterless constructor
    public class Person20
    {
        public Person20()
        {
            // initialization if needed
        }
    }

    // ==============================================================================
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Choose exercise (1-30): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": Exercise1(); break;
                case "2": Exercise2(); break;
                case "3": Exercise3(); break;
                case "4": Exercise4(); break;
                case "5": Exercise5(); break;
                case "6": await Exercise6Async(); break;
                case "7": Exercise7(); break;
                case "8": Exercise8(); break;
                case "9": Exercise9(); break;
                case "10": Exercise10(); break;
                case "11": Exercise11(); break;
                case "12": Exercise12(); break;
                case "13": Exercise13(); break;
                case "14": Exercise14(); break;
                case "15": Exercise15(); break;
                case "16": Exercise16(); break;
                case "17": Exercise17(); break;
                case "18": Exercise18(); break;
                case "19": Exercise19(); break;
                case "20": Exercise20(); break;
                case "21": Exercise21(); break;
                case "22": Exercise22(); break;
                case "23": Exercise23(); break;
                case "24": Exercise24(); break;
                case "25": Exercise25(); break;
                case "26": Exercise26(); break;
                case "27": Exercise27(); break;
                case "28": Exercise28(); break;
                case "29": Exercise29(); break;
                case "30": Exercise30(); break;


                default: Console.WriteLine("Invalid choice."); break;
            }

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }

        // Exercise 1: Sum elements in a 3x4 matrix
        static void Exercise1()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[i, j];

            Console.WriteLine($"[1] Sum of matrix elements: {sum}");
        }

        // Exercise 2: Split, sort, flag invalid items
        static void Exercise2()
        {
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
            string[] items = orderStream.Split(',');
            Array.Sort(items);
            Console.WriteLine("[2] Sorted items (flagging errors):");
            foreach (var item in items)
                Console.WriteLine(item.Length == 4 ? item : $"{item}\t- Error");
        }

        // Exercise 3: Sort, find index of 8, reverse, print
        static void Exercise3()
        {
            int[] numbers = { 5, 2, 8, 1, 9 };
            Array.Sort(numbers);
            int index = Array.IndexOf(numbers, 8);
            Console.WriteLine($"[3] Index of 8 after sort: {index}");
            Array.Reverse(numbers);
            Console.WriteLine("[3] Reversed array: " + string.Join(", ", numbers));
        }

        // Exercise 4: Split/replace/join with hyphens
        static void Exercise4()
        {
            string sentence = "The quick brown fox jumps over the lazy dog";
            string[] words = sentence.Split(' ');
            bool hasFox = sentence.Contains("fox");
            string newSentence = sentence.Replace("dog", "cat");
            string hyphenated = string.Join("-", words);

            Console.WriteLine($"[4] Words array length: {words.Length}");
            Console.WriteLine($"[4] Contains 'fox'? {hasFox}");
            Console.WriteLine($"[4] New sentence: {newSentence}");
            Console.WriteLine($"[4] Hyphenated: {hyphenated}");
        }

        // Exercise 5: Print array + reverse word order
        static void Exercise5()
        {
            string[] characters =
            {
                "Bugs Bunny",
                "Willie Coyote",
                "Daffy Duck",
                "Yosemite Sam",
                "Elmer Fudd"
            };
            Console.WriteLine("[5] Characters:");
            foreach (var c in characters) Console.WriteLine(c);

            string phrase = "C# is powerful and flexible";
            string[] words = phrase.Split(' ');
            Array.Reverse(words);
            string reversed = string.Join(" ", words);

            Console.WriteLine($"[5] Original phrase: {phrase}");
            Console.WriteLine($"[5] Reversed word order: {reversed}");
        }

        // Exercise 6: HTTP GET
        static async Task Exercise6Async()
        {
            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                Console.WriteLine("[6] Response JSON:\n" + body);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"[6] HTTP error: {e.Message}");
            }
        }

        // Exercise 7: Matrix sum w/ dims
        static void Exercise7()
        {
            int[,] matrix =
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12}
            };
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int total = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    total += matrix[i, j];

            Console.WriteLine($"[7] Total sum: {total}");
        }

        // Exercise 8: Resize int array
        static void Exercise8()
        {
            int[] data = { 10, 20, 30 };
            Console.WriteLine($"[8] Original Length: {data.Length}");
            Array.Resize(ref data, 5);
            data[3] = 40;
            data[4] = 50;
            Console.WriteLine($"[8] New Length: {data.Length}");
            Console.WriteLine("[8] Elements: " + string.Join(", ", data));
        }

        // Exercise 9: List<string> basics
        static void Exercise9()
        {
            List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };
            Console.WriteLine($"[9] Count after add: {fruits.Count}");
            fruits.Remove("Banana");
            fruits.Sort();
            Console.WriteLine("[9] Sorted fruits: " + string.Join(", ", fruits));
            Console.WriteLine(fruits.Contains("Apple") ? "[9] We have apples!" : "[9] No apples.");
        }

        // Exercise 10: Resize string[] inventory
        static void Exercise10()
        {
            string[] inventory = { "Sword", "Shield", "Potion" };
            Console.WriteLine($"[10] Original Length: {inventory.Length}");
            Array.Resize(ref inventory, 5);
            inventory[3] = "Gold Coin";
            inventory[4] = "Map";
            Console.WriteLine($"[10] New Length: {inventory.Length}");
            Console.WriteLine("[10] Inventory: " + string.Join(", ", inventory));
        }

        // Exercise 11: Array.Clear
        static void Exercise11()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            Console.WriteLine("[11] Original: " + string.Join(", ", numbers));
            Array.Clear(numbers, 1, 3);
            Console.WriteLine("[11] After clear: " + string.Join(", ", numbers));
        }

        // Exercise 12: Sort double[]
        static void Exercise12()
        {
            double[] scores = { 98.5, 76.2, 89.0, 99.9, 50.1 };
            Console.WriteLine("[12] Before sort: " + string.Join(", ", scores));
            Array.Sort(scores);
            Console.WriteLine("[12] After sort: " + string.Join(", ", scores));
        }

        // Exercise 13: Decimal -> float
        static void Exercise13()
        {
            decimal myDecimal = 1.23456789m;
            float myFloat = (float)myDecimal;
            Console.WriteLine($"[13] Decimal: {myDecimal}");
            Console.WriteLine($"[13] Float  : {myFloat}");
        }

        // Exercise 14: int ToString concat
        static void Exercise14()
        {
            int first = 5;
            int second = 7;
            string message = first.ToString() + second.ToString();
            Console.WriteLine($"[14] Concatenated: {message}");
        }

        // Exercise 15: int.Parse sum
        static void Exercise15()
        {
            string firstNum = "5";
            string secondNum = "7";
            int sum = int.Parse(firstNum) + int.Parse(secondNum);
            Console.WriteLine($"[15] Parsed sum: {sum}");
        }

        // Exercise 16: Convert.ToInt32 multiply
        static void Exercise16()
        {
            string value1 = "5";
            string value2 = "7";
            int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
            Console.WriteLine($"[16] Converted product: {result}");
        }

        // Exercise 17: Class Definitions demo (Phone)
        static void Exercise17()
        {
            var phone = new Phone { Brand = "Acme", Model = "X1", Year = 2025 };
            Console.WriteLine($"[17] Phone: {phone.Brand} {phone.Model} ({phone.Year})");
            phone.Call("555-1234");
            phone.Text("555-1234", "Hello from Exercise 17!");
        }

        // Exercise 18: Constructors demo
        static void Exercise18()
        {
            var p1 = new Person18();
            var p2 = new Person18("Person Two");
            var p3 = new Person18("Person Three", 30);

            Console.WriteLine($"[18] p1 => Name: {p1.Name}, Age: {p1.Age}");
            Console.WriteLine($"[18] p2 => Name: {p2.Name}, Age: {p2.Age}");
            Console.WriteLine($"[18] p3 => Name: {p3.Name}, Age: {p3.Age}");
        }

        // Exercise 19: Default constructor behavior
        static void Exercise19()
        {
            var person = new Person19();
            Console.WriteLine($"[19] Name: {person.Name}, Age: {person.Age} (defaults)");
        }

        // Exercise 20: Instantiation with parameterless constructor
        static void Exercise20()
        {
            var person1 = new Person20();
            Console.WriteLine("[20] Person20 instance created.");
        }

        // Exercise 21: Simple method definition and call
        static void Exercise21()
        {
            Console.WriteLine("[21] Calling the GreetUser() method...");
            GreetUser();
        }

        // A separate helper method
        static void GreetUser()
        {
            Console.WriteLine("Hello! Welcome to the C# methods demo.");
        }


        // Exercise 22: Method with parameters
        static void Exercise22()
        {
            Console.WriteLine("[22] Calling AddNumbers(5, 7)...");
            int result = AddNumbers(5, 7);
            Console.WriteLine($"[22] Result = {result}");
        }

        static int AddNumbers(int a, int b)
        {
            return a + b;
        }


        // Exercise 23: Method returning a string
        static void Exercise23()
        {
            string message = BuildGreeting("Eric", 2025);
            Console.WriteLine("[23] " + message);
        }

        static string BuildGreeting(string name, int year)
        {
            return $"Hello, {name}! The current year is {year}.";
        }


        // Exercise 24: Method overloading
        static void Exercise24()
        {
            Console.WriteLine("[24] Calling Multiply(3, 4) => " + Multiply(3, 4));
            Console.WriteLine("[24] Calling Multiply(3.5, 2.0) => " + Multiply(3.5, 2.0));
        }

        static int Multiply(int a, int b) => a * b;
        static double Multiply(double a, double b) => a * b;


        // Exercise 25: Using ref and out parameters
        static void Exercise25()
        {
            int x = 10;
            Console.WriteLine($"[25] Before doubling: x = {x}");
            DoubleValue(ref x);
            Console.WriteLine($"[25] After doubling: x = {x}");

            string numberString = "42";
            if (TryParseNumber(numberString, out int parsed))
                Console.WriteLine($"[25] Successfully parsed: {parsed}");
            else
                Console.WriteLine($"[25] Failed to parse '{numberString}'");
        }

        static void DoubleValue(ref int number)
        {
            number *= 2;
        }

        static bool TryParseNumber(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        // Exercise 26: Input validation
        static void Exercise26()
        {
            Console.WriteLine("[26] Checking password validity...");
            string password = "MyPass123!";
            bool isValid = ValidatePassword(password);

            Console.WriteLine(isValid
                ? $"[26] '{password}' is a strong password."
                : $"[26] '{password}' is too weak.");
        }

        static bool ValidatePassword(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }


        // Exercise 27: Calculate average score
        static void Exercise27()
        {
            int[] scores = { 88, 92, 79, 93, 84 };
            double avg = CalculateAverage(scores);
            Console.WriteLine($"[27] Average score: {avg:F2}");
        }

        static double CalculateAverage(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int total = 0;
            foreach (int n in numbers) total += n;
            return (double)total / numbers.Length;
        }


        // Exercise 28: Nested method calls
        static void Exercise28()
        {
            Console.WriteLine("[28] Starting nested calls...");
            int[] data = { 2, 4, 6, 8 };
            int doubledSum = Sum(DoubleEach(data));
            Console.WriteLine($"[28] Doubled sum = {doubledSum}");
        }

        static int[] DoubleEach(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++) result[i] = nums[i] * 2;
            return result;
        }

        static int Sum(int[] nums)
        {
            int total = 0;
            foreach (int n in nums) total += n;
            return total;
        }

        // Exercise 29: Using a utility class
        static void Exercise29()
        {
            Console.WriteLine("[29] Utility class demo:");
            Console.WriteLine($"Square(5) = {MathUtils.Square(5)}");
            Console.WriteLine($"Cube(3) = {MathUtils.Cube(3)}");
            Console.WriteLine($"IsEven(10) = {MathUtils.IsEven(10)}");
        }

        static class MathUtils
        {
            public static int Square(int n) => n * n;
            public static int Cube(int n) => n * n * n;
            public static bool IsEven(int n) => n % 2 == 0;
        }


        // Exercise 30: Overloaded greetings
        static void Exercise30()
        {
            Console.WriteLine(Greet());
            Console.WriteLine(Greet("Eric"));
            Console.WriteLine(Greet("Eric", 3));
        }

        static string Greet() => "Hello!";
        static string Greet(string name) => $"Hello, {name}!";
        static string Greet(string name, int times)
        {
            return string.Join(" ", Enumerable.Repeat($"Hi {name}!", times));
        }


    }
}
