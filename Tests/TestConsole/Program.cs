using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
                     var dekanat = new Dekanat();

            var students = new List<Student>();

            for (var i = 0; i < 100; i++)
                dekanat.Add(new Student 
                { 
                    Name = $"Student {i +1}",
                });

            const string students_data_file = "students.csv";
            dekanat.SaveToFile(students_data_file);


            Console.ReadLine(); 
        }
    }
}
