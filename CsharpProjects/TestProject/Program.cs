using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExercisesApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Choose exercise (1-16): ");
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
                default: Console.WriteLine("Invalid choice."); break;
            }

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }

        // Exercise 1: Sum all elements in a 3x4 matrix
        static void Exercise1()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[i, j];

            Console.WriteLine($"[1] Sum of matrix elements: {sum}");
        }

        // Exercise 2: Split, sort, and flag invalid items (length != 4)
        static void Exercise2()
        {
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
            string[] items = orderStream.Split(',');
            Array.Sort(items);
            Console.WriteLine("[2] Sorted items (flagging errors):");
            foreach (var item in items)
            {
                Console.WriteLine(item.Length == 4 ? item : $"{item}\t- Error");
            }
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

        // Exercise 4: Split sentence, replace, join with hyphens
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

        // Exercise 5: Print array, reverse word order of a phrase
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

        // Exercise 6: Simple HTTP GET (uses JSONPlaceholder to avoid 404s)
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

        // Exercise 7: Same matrix traversal & sum with dimension vars
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

        // Exercise 8: Resize int array from 3 to 5, fill new, print
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

        // Exercise 11: Array.Clear a range
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

        // Exercise 13: Decimal -> float cast
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
    }
}
