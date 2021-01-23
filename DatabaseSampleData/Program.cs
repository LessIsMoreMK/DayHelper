using DayHelper.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DatabaseSampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeDatabase();
            Console.WriteLine("Database created.");
            InsertSampleData();
            Console.WriteLine("Sample data added.");
        }

        private static void InitializeDatabase()
        {
            Database.SetInitializer(new NullDatabaseInitializer<DayHelperContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<DayHelperContext>());
        }

        private static void InsertSampleData()
        {
            #region TaskList
            var tasklist = new TaskList
            {
                Name = "Dom",
            };
            var tasklist2 = new TaskList
            {
                Name = "Szkoła",
            };
            var tasklist3 = new TaskList
            {
                Name = "Język Obcy",
            };
            var tasklist4 = new TaskList
            {
                Name = "Książki",
            };
            #endregion

            #region Tasks
            var task = new Task
            {
                Content = "Wynieść śmieci",
                Finished = false,
                Priority = Priority.Krytyczne,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now,
                TaskList = tasklist,
            };
            var task2 = new Task
            {
                Content = "Odkurzyć",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now,
                TaskList = tasklist,
            };
            var task3 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = true,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(-1),
                TaskList = tasklist,
            };
            var task4 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = true,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-8),
                DateToFinish = DateTime.Now.AddDays(-6),
                TaskList = tasklist,
            };
            var task5 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now,
                TaskList = tasklist,
            };
            var task6 = new Task
            {
                Content = "Wymienić żarówkę",
                Finished = false,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now,
                TaskList = tasklist,
            };
            var task7 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = true,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now.AddDays(-4),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist,
            };
            var task8 = new Task
            {
                Content = "Naprawić stół",
                Finished = false,
                Priority = Priority.Krytyczne,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now,
                TaskList = tasklist,
            };
            var task9 = new Task
            {
                Content = "Naprawić czajnik",
                Finished = false,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Trudne,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(2),
                TaskList = tasklist,
            };
            var task10 = new Task
            {
                Content = "Zrobić obiad",
                Finished = false,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now,
                TaskList = tasklist,
            };

            var task11 = new Task
            {
                Content = "George Orwell 1984",
                Finished = false,
                Priority = Priority.Krytyczne,
                Difficulty = Difficulty.Niezdefiniowana,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(20),
                TaskList = tasklist4,
            };
            var task12 = new Task
            {
                Content = "Stanisław Lem Niezwyciężony",
                Finished = false,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(10),
                TaskList = tasklist4,
            };
            var task13 = new Task
            {
                Content = "RicTrudne Branson Kroki W Nieznane",
                Finished = false,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(35),
                TaskList = tasklist4,
            };
            var task14 = new Task
            {
                Content = "Remigiusz Mróz Nieodnaleziona",
                Finished = false,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(90),
                TaskList = tasklist4,
            };
            var task15 = new Task
            {
                Content = "Faktfulness",
                Finished = true,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist4,
            };

            var task16 = new Task
            {
                Content = "Czas present simple",
                Finished = true,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist3,
            };
            var task17 = new Task
            {
                Content = "Czas past continuous",
                Finished = true,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-8),
                DateToFinish = DateTime.Now.AddDays(-4),
                TaskList = tasklist3,
            };
            var task18 = new Task
            {
                Content = "Czas future simple",
                Finished = true,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now,
                TaskList = tasklist3,
            };
            var task19 = new Task
            {
                Content = "Czas past perfect",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(6),
                TaskList = tasklist3,
            };
            var task20 = new Task
            {
                Content = "Czas past perfect continuous",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Trudne,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(12),
                TaskList = tasklist3,
            };
            var task21 = new Task
            {
                Content = "Przeczytać arytkuł o zwierzętach",
                Finished = true,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist3,
            };
            var task22 = new Task
            {
                Content = "Przeczytać artykuł o kosmosie",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now.AddDays(-1),
                DateToFinish = DateTime.Now.AddDays(6),
                TaskList = tasklist3,
            };
            var task23 = new Task
            {
                Content = "Przeczytać artykuł o dyskach",
                Finished = false,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(8),
                TaskList = tasklist3,
            };
            var task24 = new Task
            {
                Content = "Nuaczyć się 30 słówek",
                Finished = false,
                Priority = Priority.Krytyczne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(2),
                TaskList = tasklist3,
            };
            var task25 = new Task
            {
                Content = "Nauczyć się 30 słówek",
                Finished = false,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(7),
                TaskList = tasklist3,
            };

            var task26 = new Task
            {
                Content = "Zadanie domowe matematyka",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Trudne,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(7),
                TaskList = tasklist2,
            };
            var task27 = new Task
            {
                Content = "Zadanie domowe geografia",
                Finished = false,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Niezdefiniowana,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(5),
                TaskList = tasklist2,
            };
            var task28 = new Task
            {
                Content = "Zadanie domowe historia",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Niezdefiniowana,
                DateCreated = DateTime.Now.AddDays(-1),
                DateToFinish = DateTime.Now.AddDays(2),
                TaskList = tasklist2,
            };
            var task29 = new Task
            {
                Content = "Zadanie domowe matymatyka",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(5),
                TaskList = tasklist2,
            };
            var task30 = new Task
            {
                Content = "Projekt z chemii",
                Finished = true,
                Priority = Priority.Niezdefiniowany,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now.AddDays(-4),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist2,
            };
            var task31 = new Task
            {
                Content = "Projekt zaliczeniowy z informatyki",
                Finished = false,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(14),
                TaskList = tasklist2,
            };
            var task32 = new Task
            {
                Content = "Prezentacja na biologię",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Łatwe,
                DateCreated = DateTime.Now.AddHours(-20),
                DateToFinish = DateTime.Now.AddDays(9),
                TaskList = tasklist2,
            };
            var task33 = new Task
            {
                Content = "Kartkówka chemia",
                Finished = false,
                Priority = Priority.Ważne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(1),
                TaskList = tasklist2,
            };
            var task34 = new Task
            {
                Content = "Sprawdzian informatyka",
                Finished = false,
                Priority = Priority.Krytyczne,
                Difficulty = Difficulty.Średnie,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(7),
                TaskList = tasklist2,
            };
            var task35 = new Task
            {
                Content = "Dodatkowe zadanie z polskiego",
                Finished = false,
                Priority = Priority.Normalne,
                Difficulty = Difficulty.Trudne,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(7),
                TaskList = tasklist2,
            };
            #endregion

            using (var context = new DayHelperContext())
            {
                context.TaskLists.AddRange(new List<TaskList> { tasklist, tasklist2, tasklist3, tasklist4 });
                context.Tasks.AddRange(new List<Task> { task, task2, task3, task4, task5, task6, task7, task8, task9, task10 });
                context.Tasks.AddRange(new List<Task> { task11, task12, task13, task14, task15});
                context.Tasks.AddRange(new List<Task> { task16, task17, task18, task19, task20, task21, task22, task23, task24, task25 });
                context.Tasks.AddRange(new List<Task> { task25, task26, task27, task28, task29, task30, task31, task22, task33, task34, task35 });
                context.SaveChanges();
            }
        }
    }
}
