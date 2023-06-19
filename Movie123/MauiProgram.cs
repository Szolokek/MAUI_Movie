using Microsoft.Extensions.Logging;
using Movie123.View;
using Movie123.ViewModel;

namespace Movie123;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<IMovieService, MovieService>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddTransient<MovieDetailPage>();
		builder.Services.AddTransient<MovieDetailPageSmall>();
		builder.Services.AddTransient<MovieDetailViewModel>();

		builder.Services.AddTransient<PersonDetailPage>();
		builder.Services.AddTransient<PersonDetailPageSmall>();
		builder.Services.AddTransient<PersonDetailViewModel>();
		
		builder.Services.AddTransient<TvDetailPage>();
		builder.Services.AddTransient<TvDetailPageSmall>();
		builder.Services.AddTransient<TvDetailViewModel>();
		
		builder.Services.AddTransient<SearchPage>();
		builder.Services.AddTransient<SearchViewModel>();
	

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
