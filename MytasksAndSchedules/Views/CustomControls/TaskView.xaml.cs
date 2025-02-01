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
    public TaskView()
    {
        InitializeComponent();
        BindingContext = this;
    }
    public string TaskTitle
    {
        get => (string)GetValue(TaskTitleProperty);
        set => SetValue(TaskTitleProperty, value);
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

   
}