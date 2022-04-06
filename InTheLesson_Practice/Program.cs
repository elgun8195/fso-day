using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace InTheLesson_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Files Self Practice
            //Directory.CreateDirectory(@"C:\Users\Acer\Desktop\InTheLesson_Practice\InTheLesson_Practice\Files");
            //if (!File.Exists(@"C:\Users\Acer\Desktop\InTheLesson_Practice\InTheLesson_Practice\Files\Database.json"))
            //{
            //    File.Create(@"C:\Users\Acer\Desktop\InTheLesson_Practice\InTheLesson_Practice\files\Database.json");
            //}
            //************************

            //Employee employe1 = new Employee("Test1", 111);
            //Employee employe2 = new Employee("Test2", 222);

            //Department department = new Department("Department1");

            //department.AddMethod(employe1);
            //department.AddMethod(employe2);


            //string filename = @"C:\Users\Acer\Desktop\InTheLesson_Practice\InTheLesson_Practice\Files\Database.json";

            //StreamWriter writer = new StreamWriter(filename);
            //string result=JsonConvert.SerializeObject(department);
            //using (StreamWriter sw = new StreamWriter(filename))
            //{
            //    sw.Write(result);
            //}

            //Program prog= JsonSerializer.Deserialize<Program>(filename);
            //string fileName = "WeatherForecast.json";
            //string jsonString = File.ReadAllText(@"C:\Users\Acer\Desktop\InTheLesson_Practice\InTheLesson_Practice\Files\Database.json");
            //Department deserialized = JsonConvert.DeserializeObject<Department>(jsonString);


            //using (StreamReader reader = new StreamReader(jsonString))
            //{
            //    Console.Write(deserialized);
            //}         

            #endregion

            Department department = new Department("Test department");

            bool check = true;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Get employee by id");
                Console.WriteLine("3. Remove employee");
                Console.WriteLine("0. Quit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Salary:");
                        double salary = Convert.ToDouble(Console.ReadLine());

                        Employee employee1 = new Employee(name, salary);
                        department.AddEmployee(employee1);
                        string result = JsonConvert.SerializeObject(department);
                        using (StreamWriter sw = new StreamWriter(@"C:\Users\Acer\Desktop\InTheLesson_Practice\InTheLesson_Practice\Files\Database.json"))
                        {
                            sw.Write(result);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Id?:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        
                        using (StreamReader sr = new StreamReader(@"C:\Users\Acer\Desktop\InTheLesson_Practice\InTheLesson_Practice\Files\Database.json"))
                        {
                            string result1 = sr.ReadToEnd();

                            Employee list = JsonConvert.DeserializeObject<Employee>(result1);
                            department.GetEmployeeById(id).ShowInfo();

                        }


                        break;

                    case "3":

                        break;

                    case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("wrong input!!!");
                        break;
                }
            } while (check);
        }
    }
}