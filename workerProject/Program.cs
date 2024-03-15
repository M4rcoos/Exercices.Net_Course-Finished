using workerProject.Entities.Enums;
using workerProject.Entities;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("What department: ");
        string deptName = Console.ReadLine();

        Console.WriteLine("Enter Worker Data: ");
      
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Level(Junior/MidLevel/Senior): ");
        WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

        Console.Write("Base Salary: ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Department dept = new Department(deptName);
        Worker worker = new Worker(deptName, workerLevel, baseSalary, dept);

        Console.WriteLine("How many contracts to this worker: ");
        int n = int.Parse(Console.ReadLine());

        for(int i = 1;  i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} contract data: ");
            Console.Write("Date (DD/MM/YY): ");
            DateTime dateAndYear = DateTime.Parse(Console.ReadLine());

            Console.Write("Value per hour: ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Duration(Hour): ");

            int hours = int.Parse(Console.ReadLine());
            HourContract contract = new HourContract(dateAndYear , valuePerHour,hours);

            worker.AddContract(contract);


        }
        Console.WriteLine();
        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        string date = Console.ReadLine();
        int month = int.Parse(date.Substring(0, 2));
        int year = int.Parse(date.Substring(3));

        Console.WriteLine("Name: " + worker.Name);
        Console.WriteLine("Department: " + worker.Department.Name);
        Console.WriteLine("Income for: " + date + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

    }
}