using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudyRowi.Models;

namespace StudyRowi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

           /* var contextOptions = new DbContextOptionsBuilder<StudyContext>()
                .Options; */
               
            // StudyContext db = new StudyContext(contextOptions);

            // var journal1 = new StudyJournal
            // {
            //     Name = "Дневник",
            //     Grade = 5,
            //     Students = new Student
            //     {
            //         FirstName = "Иванов",
            //         LastName = "Иван",
            //         Patronymic = "Иванович",
            //         DateReceipt = 1,
            //         FormStudy = "Очная",
            //         Groupe = new Groupe
            //         {
            //             Name = "1A"
            //         }
            //     },
            //     StudyPlans = new StudyPlan
            //     {
            //         Name = "Учебный год",
            //         Speciality = "Математик",
            //         Discipline = "Математика",
            //         Semestr = 1,
            //         StudyTime = 50,
            //         FormExam = "Экзамен",
            //     }
            // };

            // db.StudyJournals.Add(journal1);   
            // db.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


// {
//                 "Name": "Дневник",
//                 "Grade": 5,
//                 "Students": "new Student"
//                 {
//                     "FirstName": "Иванов",
//                     "LastName": "Иван",
//                     "Patronymic": "Иванович",
//                     "DateReceipt": 1,
//                     "FormStudy": "Очная",
//                     "Groupe": "new Groupe"
//                     {
//                         "Name": "1A"
//                     }
//                 },
//                 "StudyPlans": "new StudyPlan"
//                 {
//                     "Name": "Учебный год",
//                     "Speciality": "Математик",
//                     "Discipline": "Математика",
//                     "Semestr": 1,
//                     "StudyTime": 50,
//                     "FormExam": "Экзамен"
//                 }
// };