using Microsoft.Maui.Controls;

namespace FilePickerIssueWorkaround;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
