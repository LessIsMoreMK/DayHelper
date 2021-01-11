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
            Console.WriteLine("Sample data for User: Adam Password: Adam23 added.");
        }

        private static void InitializeDatabase()
        {
            Database.SetInitializer(new NullDatabaseInitializer<DayHelperContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<DayHelperContext>());
        }

        private static void InsertSampleData()
        {
            #region User
            var user = new User
            {
                Username = "Adam",
                Password = "Adam23",
            };
            #endregion Users

            #region TaskList
            var tasklist = new TaskList
            {
                Name = "Dom",
                User = user,
            };
            var tasklist2 = new TaskList
            {
                Name = "Szkoła",
                User = user,
            };
            var tasklist3 = new TaskList
            {
                Name = "Język Obcy",
                User = user,
            };
            var tasklist4 = new TaskList
            {
                Name = "Książki",
                User = user,
            };
            #endregion

            #region Tasks
            var task = new Task
            {
                Content = "Wynieść śmieci",
                Finished = false,
                Priority = Priority.Critical,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddHours(1),
                TaskList = tasklist,
            };
            var task2 = new Task
            {
                Content = "Odkurzyć",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddHours(2),
                TaskList = tasklist,
            };
            var task3 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = true,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(-1).AddHours(-12),
                TaskList = tasklist,
            };
            var task4 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = true,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-8),
                DateToFinish = DateTime.Now.AddDays(-6),
                TaskList = tasklist,
            };
            var task5 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddHours(4),
                TaskList = tasklist,
            };
            var task6 = new Task
            {
                Content = "Wymienić żarówkę",
                Finished = false,
                Priority = Priority.Important,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddHours(12),
                TaskList = tasklist,
            };
            var task7 = new Task
            {
                Content = "Zrobić zakupy",
                Finished = true,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now.AddDays(-4),
                DateToFinish = DateTime.Now.AddDays(-3).AddHours(-2),
                TaskList = tasklist,
            };
            var task8 = new Task
            {
                Content = "Naprawić stół",
                Finished = false,
                Priority = Priority.Critical,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddHours(6),
                TaskList = tasklist,
            };
            var task9 = new Task
            {
                Content = "Naprawić czajnik",
                Finished = false,
                Priority = Priority.Important,
                Difficulty = Difficulty.Hard,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(2).AddHours(2),
                TaskList = tasklist,
            };
            var task10 = new Task
            {
                Content = "Zrobić obiad",
                Finished = false,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddHours(3),
                TaskList = tasklist,
            };

            var task11 = new Task
            {
                Content = "George Orwell 1984",
                Finished = false,
                Priority = Priority.Critical,
                Difficulty = Difficulty.NotDefined,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(20),
                TaskList = tasklist4,
            };
            var task12 = new Task
            {
                Content = "Stanisław Lem Niezwyciężony",
                Finished = false,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(10),
                TaskList = tasklist4,
            };
            var task13 = new Task
            {
                Content = "Richard Branson Kroki W Nieznane",
                Finished = false,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(35),
                TaskList = tasklist4,
            };
            var task14 = new Task
            {
                Content = "Remigiusz Mróz Nieodnaleziona",
                Finished = false,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(90),
                TaskList = tasklist4,
            };
            var task15 = new Task
            {
                Content = "Faktfulness",
                Finished = true,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist4,
            };

            var task16 = new Task
            {
                Content = "Czas present simple",
                Finished = true,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist3,
            };
            var task17 = new Task
            {
                Content = "Czas past continuous",
                Finished = true,
                Priority = Priority.Important,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-8),
                DateToFinish = DateTime.Now.AddDays(-4).AddHours(-3),
                TaskList = tasklist3,
            };
            var task18 = new Task
            {
                Content = "Czas future simple",
                Finished = true,
                Priority = Priority.Important,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddHours(-3),
                TaskList = tasklist3,
            };
            var task19 = new Task
            {
                Content = "Czas past perfect",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(6),
                TaskList = tasklist3,
            };
            var task20 = new Task
            {
                Content = "Czas past perfect continuous",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Hard,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(12),
                TaskList = tasklist3,
            };
            var task21 = new Task
            {
                Content = "Przeczytać arytkuł o zwierzętach",
                Finished = true,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist3,
            };
            var task22 = new Task
            {
                Content = "Przeczytać artykuł o kosmosie",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now.AddDays(-1),
                DateToFinish = DateTime.Now.AddDays(6),
                TaskList = tasklist3,
            };
            var task23 = new Task
            {
                Content = "Przeczytać artykuł o dyskach",
                Finished = false,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(8),
                TaskList = tasklist3,
            };
            var task24 = new Task
            {
                Content = "Nuaczyć się 30 słówek",
                Finished = false,
                Priority = Priority.Critical,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-5),
                DateToFinish = DateTime.Now.AddDays(2),
                TaskList = tasklist3,
            };
            var task25 = new Task
            {
                Content = "Nauczyć się 30 słówek",
                Finished = false,
                Priority = Priority.Important,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(7),
                TaskList = tasklist3,
            };

            var task26 = new Task
            {
                Content = "Zadanie domowe matematyka",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Hard,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(7),
                TaskList = tasklist2,
            };
            var task27 = new Task
            {
                Content = "Zadanie domowe geografia",
                Finished = false,
                Priority = Priority.Important,
                Difficulty = Difficulty.NotDefined,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(5),
                TaskList = tasklist2,
            };
            var task28 = new Task
            {
                Content = "Zadanie domowe historia",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.NotDefined,
                DateCreated = DateTime.Now.AddDays(-1),
                DateToFinish = DateTime.Now.AddDays(2),
                TaskList = tasklist2,
            };
            var task29 = new Task
            {
                Content = "Zadanie domowe matymatyka",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(5),
                TaskList = tasklist2,
            };
            var task30 = new Task
            {
                Content = "Projekt z chemii",
                Finished = true,
                Priority = Priority.NotDefined,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now.AddDays(-4),
                DateToFinish = DateTime.Now.AddDays(-3),
                TaskList = tasklist2,
            };
            var task31 = new Task
            {
                Content = "Projekt zaliczeniowy z informatyki",
                Finished = false,
                Priority = Priority.Important,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(14),
                TaskList = tasklist2,
            };
            var task32 = new Task
            {
                Content = "Prezentacja na biologię",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Easy,
                DateCreated = DateTime.Now.AddHours(-20),
                DateToFinish = DateTime.Now.AddDays(9),
                TaskList = tasklist2,
            };
            var task33 = new Task
            {
                Content = "Kartkówka chemia",
                Finished = false,
                Priority = Priority.Important,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(1),
                TaskList = tasklist2,
            };
            var task34 = new Task
            {
                Content = "Sprawdzian informatyka",
                Finished = false,
                Priority = Priority.Critical,
                Difficulty = Difficulty.Medium,
                DateCreated = DateTime.Now,
                DateToFinish = DateTime.Now.AddDays(7),
                TaskList = tasklist2,
            };
            var task35 = new Task
            {
                Content = "Dodatkowe zadanie z polskiego",
                Finished = false,
                Priority = Priority.Normal,
                Difficulty = Difficulty.Hard,
                DateCreated = DateTime.Now.AddDays(-2),
                DateToFinish = DateTime.Now.AddDays(7).AddHours(-3),
                TaskList = tasklist2,
            };
            #endregion

            #region Tags
            var tag = new Tag
            {
                Name = "Sprzątanie",
                Task = task,
            };
            var tag2 = new Tag
            {
                Name = "Sprzątanie",
                Task = task2,
            };
            var tag3 = new Tag
            {
                Name = "Naprawa",
                Task = task6,
            };
            var tag4 = new Tag
            {
                Name = "Naprawa",
                Task = task8,
            };
            var tag5 = new Tag
            {
                Name = "Naprawa",
                Task = task9,
            };
            var tag6 = new Tag
            {
                Name = "Naprawa",
                Task = task9,
            };

            var tag7 = new Tag
            {
                Name = "Czytanie",
                Task = task11,
            };
            var tag8 = new Tag
            {
                Name = "Czytanie",
                Task = task12,
            };
            var tag9 = new Tag
            {
                Name = "Czytanie",
                Task = task13,
            };
            var tag10 = new Tag
            {
                Name = "Czytanie",
                Task = task14,
            };
            var tag11 = new Tag
            {
                Name = "Czytanie",
                Task = task15,
            };

            var tag12 = new Tag
            {
                Name = "Czytanie",
                Task = task21,
            };
            var tag13 = new Tag
            {
                Name = "Czytanie",
                Task = task22,
            };
            var tag14 = new Tag
            {
                Name = "Czytanie",
                Task = task23,
            };
            var tag15 = new Tag
            {
                Name = "Nauka",
                Task = task16,
            };
            var tag16 = new Tag
            {
                Name = "Nauka",
                Task = task17,
            };
            var tag17 = new Tag
            {
                Name = "Nauka",
                Task = task18,
            };
            var tag18 = new Tag
            {
                Name = "Nauka",
                Task = task19,
            };
            var tag19 = new Tag
            {
                Name = "Nauka",
                Task = task20,
            };
            var tag20 = new Tag
            {
                Name = "Nauka",
                Task = task21,
            };
            var tag21 = new Tag
            {
                Name = "Nauka",
                Task = task22,
            };
            var tag22 = new Tag
            {
                Name = "Nauka",
                Task = task23,
            };
            var tag23 = new Tag
            {
                Name = "Nauka",
                Task = task24,
            };
            var tag24 = new Tag
            {
                Name = "Nauka",
                Task = task25,
            };

            var tag25 = new Tag
            {
                Name = "Nauka",
                Task = task26,
            };
            var tag26 = new Tag
            {
                Name = "Nauka",
                Task = task27,
            };
            var tag27 = new Tag
            {
                Name = "Nauka",
                Task = task28,
            };
            var tag28 = new Tag
            {
                Name = "Nauka",
                Task = task29,
            };
            var tag29 = new Tag
            {
                Name = "Nauka",
                Task = task30,
            };
            var tag30 = new Tag
            {
                Name = "Nauka",
                Task = task31,
            };
            var tag31 = new Tag
            {
                Name = "Nauka",
                Task = task32,
            };
            var tag32 = new Tag
            {
                Name = "Nauka",
                Task = task33,
            };
            var tag33 = new Tag
            {
                Name = "Nauka",
                Task = task34,
            };
            var tag34 = new Tag
            {
                Name = "Nauka",
                Task = task35,
            };
            var tag35 = new Tag
            {
                Name = "Dodatkowe",
                Task = task32,
            };
            var tag36 = new Tag
            {
                Name = "Dodatkowe",
                Task = task30,
            };
            var tag37 = new Tag
            {
                Name = "Dodatkowe",
                Task = task35,
            };
            var tag38 = new Tag
            {
                Name = "Czytanie",
                Task = task35,
            };
            #endregion


            using (var context = new DayHelperContext())
            {
                context.Users.Add(user);
                context.TaskLists.AddRange(new List<TaskList> { tasklist, tasklist2, tasklist3, tasklist4 });
                context.Tasks.AddRange(new List<Task> { task, task2, task3, task4, task5, task6, task7, task8, task9, task10 });
                context.Tags.AddRange(new List<Tag> { tag, tag2, tag3, tag4, tag5, tag6 });
                context.Tasks.AddRange(new List<Task> { task11, task12, task13, task14, task15});
                context.Tags.AddRange(new List<Tag> { tag7, tag8, tag9, tag10, tag11});
                context.Tasks.AddRange(new List<Task> { task16, task17, task18, task19, task20, task21, task22, task23, task24, task25 });
                context.Tags.AddRange(new List<Tag> { tag12, tag13, tag14, tag15, tag16, tag17, tag18, tag19, tag20, tag21, tag22, tag23, tag24 });
                context.Tasks.AddRange(new List<Task> { task25, task26, task27, task28, task29, task30, task31, task22, task33, task34, task35 });
                context.Tags.AddRange(new List<Tag> { tag25, tag26, tag27, tag28, tag29, tag30, tag31, tag32, tag33, tag34, tag35, tag36, tag37, tag38});
                context.SaveChanges();
            }
        }
    }
}
