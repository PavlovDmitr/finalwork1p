
namespace Example
{
    class Program
    {
        static string[] GetUserData()
        {
            string[] result = new string[] { };

            return result;
        }

        static string[] ReadUserDataFromFile(string path)
        {
            string[] result = new string[] { };
            int counter = 0;
            try
            {
                foreach (string line in System.IO.File.ReadLines(path))
                {
                    result[counter] = line;
                    counter++;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid path");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }

            counter = new Random().Next(0, counter);
            result = result[counter].Split(" ");
            return result;
        }

        static string[] SetUserDataDefault()
        {
            string[] result = new string[] { "Russia", "Denmark", "Kazan" };
            int rnd = new Random().Next(1, 4);
            string[] result1 = new string[] { "hello", "2", "world", ":-)" };
            string[] result2 = new string[] { "1234", "1567", "-2", "computer science" };
            if (rnd == 1) result = result1;
            if (rnd == 2) result = result2;
            return result;
        }
        static void Main(string[] args)
        {
            string path = "../inputUserData.txt";

        }
    }
}
