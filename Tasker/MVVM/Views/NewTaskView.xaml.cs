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

    private async void AddTaskClicked(object sender, EventArgs e)
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

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
		var viewModel = BindingContext as NewTaskViewModel;

		string newCategoryName = await DisplayPromptAsync("New Category", "Enter the new  category name:", maxLength:15, keyboard:Keyboard.Text);

		var random = new Random();

		if (!string.IsNullOrEmpty(newCategoryName))
		{
			var newCategory = new Category
			{
				Id = viewModel.Categories.Max(c => c.Id) + 1,
				CategoryName = newCategoryName,
				Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)).ToHex(),
			};

            viewModel.Categories.Add(newCategory);

			await DisplayAlert("Success", "Category added successfully.", "OK");
        }
    }

}