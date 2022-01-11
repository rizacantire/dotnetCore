using System;
using LinqPractices.DbOperations;
using LinqPractices.Entities;
using System.Linq;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqDbContext _context = new LinqDbContext();
            DataGenerator.Initialize();
            var students = _context.Students.ToList<Student>();
            //Find()
            Console.WriteLine("-*-*-* Find *-*-*-");
            var student = _context.Students.Where(st => st.StudentId == 1).FirstOrDefault();
            Console.WriteLine(student.Name);
            var st2 = _context.Students.Find(2);
            System.Console.WriteLine(st2.Name);





        }
    }
}
