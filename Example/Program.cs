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
                    result1[counter] = line;
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
            
            do
            {
            counter = new Random().Next(0, counter);
            result2 = result1[counter].Split(" ");
            if (result2.Length < 2) result2 = result1; break;
            }
            while (true);
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
        static void Main()
        {   
            string path = "../inputUserData.txt";
            char[] delimiterChar = { ' ', '.', '(', ')', '[', ']', '/', '!', '?', ';', ':' };
            Console.WriteLine(ReadNodeText(1,"welcomtext"));
            string[] userDataInsert= Console.ReadLine().Trim().Split(delimiterChar);
            int count = 0;
            string[] userData = new string[]{};
            if(userDataInsert.Length == 0) userData = ReadUserDataFromFile(path);
            foreach( string str in userDataInsert)
            {
                if (str.ToLower()[^-4..^-0] == ".txt") {userData = ReadUserDataFromFile(str); break;}
                count++;
            }
            if (userData.Length == 0) userData = SetUserDataDefault();
            foreach 

        }
    }
}
