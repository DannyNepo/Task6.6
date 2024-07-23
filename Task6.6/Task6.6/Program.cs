using System.Text;

namespace Task6_6
{
    internal class Program
    {
        private static string fileName = "EmployeesData.txt";
        private static StringBuilder EmployeesStr = new StringBuilder();

        static void Main()
        {
            WorkCicle();
        }

        private static void WorkCicle()
        {
            Console.WriteLine();
            Console.WriteLine("Press '1' to read the file, press '2' to add data to file or press '3' to exit");
            Console.WriteLine();
            string result = Console.ReadLine();
            Console.WriteLine();
            if (result == "1")
            {
                ReadTheFile();
                WorkCicle();
            }
            else if (result == "2") 
            {
                FillEmployeesData();
                WorkCicle();
            }
            else if (result == "3")
            {
                Console.WriteLine("See You!");
            }
            else 
            {
                Console.WriteLine("Wrong input");
                WorkCicle();
            }
        }

        private static void FillEmployeesData()
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            DateTime registrationTime = DateTime.Now;
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Date of birth: ");
            DateTime birthdayDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Place of birth: ");
            string placeOfBirth = Console.ReadLine();

            
            EmployeesStr.AppendLine($"{id}#{registrationTime}#{name}#{age}#{height}#{birthdayDate.Day}.{birthdayDate.Month}.{birthdayDate.Year}#{placeOfBirth}");
            File.AppendAllText(fileName, EmployeesStr.ToString());
            EmployeesStr.Clear();
        }

        private static void ReadTheFile()
        {
            if (File.Exists(fileName)) 
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var splitedLine = line.Split("#");
                    foreach (var part in splitedLine) Console.Write($"{part}  ");
                    Console.WriteLine();
                } 
            }
            else 
            {
                Console.WriteLine("File doesn't exist");
            }
        }
    }
}