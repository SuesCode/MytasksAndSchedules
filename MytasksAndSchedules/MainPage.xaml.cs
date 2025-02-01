using System.Collections.ObjectModel;
using System.ComponentModel;
using MytasksAndSchedules.Views.CustomControls;

namespace MytasksAndSchedules
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<string> tasks = new ObservableCollection<string>();
        public ObservableCollection<string> Tasks
        {
            get => tasks;
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
            {
                AddTask(TaskEntry.Text);
                TaskEntry.Text = string.Empty;
            }
        }

        private void AddTask(string taskText)
        {
            TaskView taskView = null;
             taskView = new TaskView
            {
                TaskTitle = taskText,
                TaskDetails = "Task Details Here...",
                DeleteCommand = new Command(() => RemoveTask(taskView))
            };

            TaskList.Children.Add(taskView);
        }

        private void RemoveTask(TaskView taskView)
        {
            TaskList.Children.Remove(taskView);
        }
    }

}
