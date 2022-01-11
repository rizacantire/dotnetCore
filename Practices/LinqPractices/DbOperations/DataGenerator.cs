using System;
using System.Linq;
using LinqPractices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                // Look for any board games.
                if (context.Students.Any())
                {
                    return;   // Data was already seeded
                }

                context.Students.AddRange(
                   new Student()
                   {
                       Name = "Ayse",
                       Surname = "Yılmaz",
                       ClassId = 1
                   },
                   new Student()
                   {
                       Name = "Deniz",
                       Surname = "Arda",
                       ClassId = 1
                   },
                   new Student()
                   {
                       Name = "Umut",
                       Surname = "Arda",
                       ClassId = 2
                   },
                   new Student()
                   {
                       Name = "Merve",
                       Surname = "Çalışkan",
                       ClassId = 2
                   }
                   );

                context.SaveChanges();
            }
        }
    }
}