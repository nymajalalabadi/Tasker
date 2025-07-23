using System.Threading.Tasks;
using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

    private async Task AddTaskClicked(object sender, EventArgs e)
    {
		var viewModel = BindingContext as NewTaskViewModel;

		var selectedCategory = viewModel.Categories.Where(c => c.IsSelected == true).FirstOrDefault();

		if (selectedCategory != null)
		{
			var task = new MyTask
			{
				TaskName = viewModel.Task,
				CategoryId = selectedCategory.Id
			};

			viewModel.Tasks.Add(task);

			await DisplayAlert("Success", "Task added successfully.", "OK");

			await Navigation.PopAsync();

			viewModel.Task = string.Empty;
        }
		else
		{
			await DisplayAlert("Error", "Please select a category.", "OK");
        }
    }
}