using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;


namespace MytasksAndSchedules.Views.CustomControls;

public partial class TaskView : ContentView
{
    public static readonly BindableProperty TaskTitleProperty =
            BindableProperty.Create(nameof(TaskTitle), typeof(string), typeof(TaskView), string.Empty);

    public static readonly BindableProperty TaskDetailsProperty =
        BindableProperty.Create(nameof(TaskDetails), typeof(string), typeof(TaskView), string.Empty);

    public static readonly BindableProperty DeleteCommandProperty =
        BindableProperty.Create(nameof(DeleteCommand), typeof(ICommand), typeof(TaskView));

    public static readonly BindableProperty IsExpandedProperty =
           BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(TaskView), false, propertyChanged: OnExpandedChanged);

    public static readonly BindableProperty ExpandCommandProperty =
       BindableProperty.Create(nameof(ExpandCommand), typeof(ICommand), typeof(TaskView));
    public TaskView()
    {
        InitializeComponent();
        BindingContext = this;
        ToggleCommand = new Command(() => IsExpanded = !IsExpanded);
    }
    public static readonly BindableProperty TaskStatusProperty =
            BindableProperty.Create(nameof(TaskStatus), typeof(string), typeof(TaskView), "Not Completed", BindingMode.TwoWay);

    public string TaskStatus
    {
        get => (string)GetValue(TaskStatusProperty);
        set => SetValue(TaskStatusProperty, value);
    }

    public ObservableCollection<string> TaskStatusOptions { get; } = new ObservableCollection<string>
        {
            "Not Started",
            "In Progress",
            "Completed"

        };
    public string ToggleButtonText => IsExpanded ? "🔼" : "🔽";

    public ICommand ToggleCommand { get; }

    public string TaskTitle
    {
        get => (string)GetValue(TaskTitleProperty);
        set => SetValue(TaskTitleProperty, value);
    }
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }
   

    public string TaskDetails
    {
        get => (string)GetValue(TaskDetailsProperty);
        set => SetValue(TaskDetailsProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }
    public ICommand ExpandCommand
    {
        get => (ICommand)GetValue(ExpandCommandProperty);
        set => SetValue(ExpandCommandProperty, value);
    }
    private static void OnExpandedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (TaskView)bindable;
        control.OnPropertyChanged(nameof(ToggleButtonText)); // 🔥 Update button text when expanded state changes
    }
}