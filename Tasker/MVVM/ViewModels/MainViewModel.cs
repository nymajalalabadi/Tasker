using PropertyChanged;
using System.Collections.ObjectModel;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public MainViewModel()
        {
            FillData();
        }

        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<MyTask> Tasks { get; set; }


        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                    new Category
                    {
                         Id = 1,
                         CategoryName = ".NET MAUI Course",
                         Color = "#CF14DF"
                    },
                    new Category
                    {
                         Id = 2,
                         CategoryName = "Tutorials",
                         Color = "#df6f14"
                    },
                    new Category
                    {
                         Id = 3,
                         CategoryName = "Shopping",
                         Color = "#14df80"
                    }
            };



            Tasks = new ObservableCollection<MyTask>
            {
                    new MyTask
                    {
                         TaskName = "Upload exercise files",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         TaskName = "Plan next course",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         TaskName = "Upload new ASP.NET video on YouTube",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Fix Settings.cs class of the project",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Update github repository",
                         Completed = true,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Buy eggs",
                         Completed = false,
                         CategoryId = 3
                    },
                    new MyTask
                    {
                         TaskName = "Go for the pepperoni pizza",
                         Completed = false,
                         CategoryId = 3
                    },
            };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var cate in Categories)
            {
                var tasks = Tasks.Where(t => t.CategoryId == cate.Id)
                                .ToList();

                var completed = tasks.Where(t => t.Completed == true)
                                   .ToList();

                var notCompleted = tasks.Where(t => t.Completed == false)
                                   .ToList();



                cate.PendingTasks = notCompleted.Count();
                cate.Percentage = (float)completed.Count() / (float)(tasks.Count() == 0 ? 1 : tasks.Count());
            }

            foreach (var task in Tasks)
            {
                var catColor = Categories.Where(c => c.Id == task.CategoryId)
                    .Select(c => c.Color)
                    .FirstOrDefault();

                task.TaskColor = catColor ?? string.Empty; // Ensure TaskColor is never assigned a null value
            }

        }

    }
}
