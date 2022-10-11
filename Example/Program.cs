using System;
using System.Xml;
namespace Example
{
    class Program
    {
        public static string ReadNodeText(int taskNum, string nodeName)
        {
            XmlDocument xmlDocument = new();
            try
            {
                xmlDocument.Load("..\\..\\..\\Example.xml");
                XmlElement? xRoot = xmlDocument.DocumentElement;
                XmlNode? taskNode = xRoot?.SelectSingleNode($"task[@number='{taskNum}']").SelectSingleNode(nodeName);
                if (taskNode is not null)
                {
                    return taskNode.InnerText;
                    //Console.WriteLine(taskNode.InnerText);
                }
                else return "1  file not found";
            }
            catch
            {
                try
                {
                    xmlDocument.Load("Example.xml");
                    XmlElement? xRoot = xmlDocument.DocumentElement;
                    XmlNode? taskNode = xRoot?.SelectSingleNode($"task[@number='{taskNum}']").SelectSingleNode(nodeName);
                    if (taskNode is not null)
                    {
                        return taskNode.InnerText;
                        //Console.WriteLine(taskNode.InnerText);
                    }
                    else return "2  file not found";
                }
                catch { return "3  file not found"; }
            }
        }

        static string[] ReadUserDataFromFile(string path)
        {
            string[] result1 = new string[] { };
            string[] result2 = new string[] { };
            int counter = 0;
            try
            {
                foreach (string line in System.IO.File.ReadLines(path))
                {
                    Array.Resize(ref result1, result1.Length + 1);
                    result1[result1.Length - 1] = line;
                    Console.WriteLine(line);
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
            result2 = result1[counter].Split(" ");
            if (result2.Length < 2) result2 = result1;
            PrintArray(result2);
            return result2;
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

        static void PrintArray(string[] strArr)
        {
            foreach (string str in strArr) Console.Write($"{str} ");
        }

        static void WriteFile(string[] text)
        {
            StreamWriter str = new StreamWriter("outputData.txt");
            for (int i = 0; i < text.Length; i++)
            {
                str.Write($"{text[i]} ");
            }
            str.Close();
        }
        static void Main()
        {
            Console.Clear();
            string[] result = new string[] { };
            string path = "../Example/inputUserData.txt";
            char[] delimiterChar = { ' ', '(', ')', '[', ']', '/', '!', '?', ';' };
            Console.WriteLine(ReadNodeText(1, "text"));
            Console.WriteLine(ReadNodeText(1, "welcomtext"));
            string[] userDataInsert = Console.ReadLine().Trim().Split(delimiterChar);
            string[] userData = new string[] { };
            if (userDataInsert.Length == 1 && userDataInsert[0].Length == 0)
            {
                try { userData = ReadUserDataFromFile(path); }
                catch { Console.WriteLine("file not found, use default array"); userData = SetUserDataDefault(); }
                if (userData.Length == 0) { Console.WriteLine("file empty, use default array"); userData = SetUserDataDefault(); }
            }
            else if (userDataInsert.Length == 1 && userDataInsert[0].Length > 4)
            {
                if (userDataInsert[0].ToLower()[^4..^0] == ".txt")
                {
                    try
                    {
                        { userData = ReadUserDataFromFile(userDataInsert[0]); }
                    }
                    catch { Console.WriteLine($"{userDataInsert[0]} file not found, use default array"); userData = SetUserDataDefault(); }
                    if (userData.Length == 0) { Console.WriteLine($"{userDataInsert[0]} file empty, use default array"); userData = SetUserDataDefault(); }
                }
                else { Console.WriteLine($"{userDataInsert[0]} this no file path? use as array"); userData = userDataInsert; }
            }
            else if (userDataInsert.Length >= 1 && userDataInsert[0] != "") userData = userDataInsert;
            foreach (string str in userData)
            {
                if (str.Length < 4)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = str;
                }
            }
            Console.WriteLine("Результат работы программы массив из следующих элементов:");
            PrintArray(result);
            Console.WriteLine("\nЖелаете сохранить результат работы программы в файл? введите yes/YES для согласия, или Enter для отказа");
            string? key = Console.ReadLine();
            if (key.ToLower() == "yes")
            {
                WriteFile(result);
            }
        }
    }
}
