using System;

namespace Hogwards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Hogwards!");
            StudyContext db = new StudyContext();

            var plan1 = new StudyJournal
            {
                Name = "Дневник",
                Students = new Student
                {
                    FirstName = "Петров",
                    LastName = "Влад",
                    Patronymic = "Александрович",
                    DateReceipt = 2005,
                    FormStudy = "Дневная",
                    Groupe = new Groupe
                    {
                        Name = "1А"
                    }
                },
                StudyPlans = new StudyPlan
                {
                    Name = "Первый год",
                    Speciality = "Маг",
                    Discipline = "Математика",
                    Semestr = 1,
                    StudyTime = 50,
                    FormExam = "Экзамен"
                }

            };

            db.SaveChanges();
            Console.WriteLine
                ($"Hello Hogwards! " +
                $"{plan1.Students.FirstName} " +
                $"{plan1.Students.LastName} " +
                $"{plan1.Students.Patronymic} " +
                $"{plan1.StudyPlans.Speciality} "
                );

            /*            foreach (var plan in plan1)
                        {
                            foreach (var form in plan.Forms)
                            {

                            }
                        }


                        Console.WriteLine($"Hello Hogwards! {plan1.Students.FirstName}");
            */
        }
    }
}
         //   StudyContext db = new StudyContext();

//    var studyPlan = new StudyPlan { Name = "Первый курс", Id = 1 };


//  db.SaveChanges();

/*  var students = db.Students;
  foreach (var student in students)
  {
      foreach (var form in student.FormStudy)
      {
          Console.WriteLine($"{student} учится на {form}");
      }
  }*/

/*  var disciplines = db.Disciplines;
  foreach (var discipline in disciplines)
  {
      foreach (var hours in Enumerable.Range(1, discipline.StudyTime))
      {
          Console.WriteLine($"У {discipline},{hours} часов на обучение");
      }
  }
  */

/* public void DeleteStudent(string[] args)
 {
     StudyContext context = new StudyContext();

     Console.Write("Введите Имя, Фамилию, Отчество студента для удаления: ");
     string? firstName = Console.ReadLine();
     string? lastName = Console.ReadLine();
     string? patronymic = Console.ReadLine();

     Student student = context.Students
         .Where(x => x.FirstName == firstName)
         .Where(x => x.LastName == lastName)
         .Where(x => x.Patronymic == patronymic)
         .FirstOrDefault();

     context.Students.Remove(student);
     context.SaveChanges();

     Console.WriteLine($"Студент с {firstName} {lastName} {patronymic} удален из базы данных ");
 }
 public static void UpdateStudent()
 {
     StudyContext context = new StudyContext();

     Console.Write("Введите данные для изменения (Имя, Фамилию, Отчество): ");
     string? firstName = Console.ReadLine();
     string? lastName = Console.ReadLine();
     string? patronymic = Console.ReadLine();

     IEnumerable<Student> customers = context.Students
        .Where(c => c.FirstName == firstName)
        .Where(c => c.LastName == lastName)
        .Where(c => c.Patronymic == patronymic)
        .Select(c => c.Id)
        .AsEnumerable()
        .Select(id => new Student
         {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Patronymic = patronymic
         }
        );

     foreach (Student customer in customers)
     {
         context.Students.Attach(customer);
         context.Entry(customer)
             .Property(c => c.FirstName).IsModified = true;
         context.Entry(customer)
             .Property(c => c.LastName).IsModified = true;
         context.Entry(customer)
             .Property(c => c.Patronymic).IsModified = true;
     }

     context.SaveChanges();
     Console.WriteLine($"Студент с {firstName} {lastName} {patronymic} в базе данных изменён");
 }
 public static void AddNewStudent()
 {
     StudyContext context = new StudyContext();
     Console.Write("Введите данные (Имя, Фамилию, Отчество), чтобы добавить студента: ");
     string? firstName = Console.ReadLine();
     string? lastName = Console.ReadLine();
     string? patronymic = Console.ReadLine();

     // Создать нового покупателя
     Student student = new Student
     {
         FirstName = firstName,
         LastName = lastName,
         Patronymic = patronymic
     };

     // Добавить в DbSet
     context.Students.Add(student);

     // Сохранить изменения в базе данных
     context.SaveChanges();
     Console.WriteLine($"Студент с {firstName} {lastName} {patronymic} в базе данных добавлен");
 }
 public void DeleteStudyJournal(string[] args)
 {
     StudyContext context = new StudyContext();

     Console.Write("Название журнала для удаления: ");
     string? name = Console.ReadLine();

     StudyJournal studyJournal = context.StudyJournals
         .Where(x => x.Name == name)
         .FirstOrDefault();

     context.StudyJournals.Remove(studyJournal);
     context.SaveChanges();

     Console.WriteLine($"Журнал {name} удален из базы данных ");
 }
 public static void UpdateStudyJournal()
 {
     StudyContext context = new StudyContext();

     Console.Write("Введите данные для изменения журнала: ");
     string? name = Console.ReadLine();
     Console.Write("Введите данные ID студента для изменения: ");
     string? studentId = Console.ReadLine();
     int studentId2 = Int32.Parse(studentId);
     Console.Write("Введите оценку для студента: ");
     string? grade = Console.ReadLine();
     int grade2 = Int32.Parse(grade);

     IEnumerable<StudyJournal> customers = context.StudyJournals
        .Where(c => c.Name == name)
        .Where(c => c.StudentId == studentId2)
        .Where(c => c.Grade == grade2)
        .Select(c => c.Id)
        .AsEnumerable()
        .Select(id => new StudyJournal
        {
            Id = id,
            Name = name,
            StudentId = studentId2,
            Grade = grade2
        }
        );

     foreach (StudyJournal customer in customers)
     {
         context.StudyJournals.Attach(customer);
         context.Entry(customer)
             .Property(c => c.Name).IsModified = true;
         context.Entry(customer)
             .Property(c => c.StudentId).IsModified = true;
         context.Entry(customer)
             .Property(c => c.Grade).IsModified = true;
     }

     context.SaveChanges();
     Console.WriteLine($"Данные {name} в базе данных изменён");
     Console.WriteLine($"Данные {studentId2} в базе данных изменён");
     Console.WriteLine($"Данные {grade2} в базе данных изменён");
 }
 public static void AddNewStudyJournal()
 {
     StudyContext context = new StudyContext();
     Console.Write("Введите данные для изменения журнала: ");
     string? name = Console.ReadLine();
     Console.Write("Введите данные ID студента для изменения: ");
     string? studentId = Console.ReadLine();
     int studentId2 = Int32.Parse(studentId);
     Console.Write("Введите оценку для студента: ");
     string? grade = Console.ReadLine();
     int grade2 = Int32.Parse(grade);

     // Создать нового покупателя
     StudyJournal studyJournal = new StudyJournal
     {
         Name = name,
         StudentId = studentId2,
         Grade = grade2
     };

     // Добавить в DbSet
     context.StudyJournals.Add(studyJournal);

     // Сохранить изменения в базе данных
     context.SaveChanges();
     Console.WriteLine($"Данные {name} в базе данных добавлен");
 }
}*/

