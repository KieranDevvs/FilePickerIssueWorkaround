using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using FilePickerIssueWorkaround.DependencyInjection;

namespace FilePickerIssueWorkaround;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder.ConfigureContainer(new AutofacServiceProviderFactory(AutofacContainerBuilder.Build));
        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
