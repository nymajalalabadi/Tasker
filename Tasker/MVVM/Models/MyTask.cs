﻿using PropertyChanged;

namespace Tasker.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MyTask
    {
        public int CategoryId { get; set; }

        public string TaskName { get; set; }

        public bool Completed { get; set; }

        public string TaskColor { get; set; }
    }
}
