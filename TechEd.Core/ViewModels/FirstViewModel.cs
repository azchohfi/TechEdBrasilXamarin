using System.Diagnostics;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using MvvmCross.Plugins.Location;
using TechEd.Core.Services;

namespace TechEd.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		private string _weatherData;
		public string WeatherData
		{
			get
			{
				return _weatherData;
			}
			set
			{
				_weatherData = value;
				RaisePropertyChanged(() => WeatherData);
			}
		}

		public MvxCommand PegarClimaCommand { get; private set; }

		public FirstViewModel()
		{
			PegarClimaCommand = new MvxCommand(ExecutePegarClimaCommand);
		}

		private void ExecutePegarClimaCommand()
		{
			WeatherData = "Encontrando você...";

			var locationWatcher = Mvx.Resolve<IMvxLocationWatcher>();
			if (locationWatcher.Started)
			{
				return;
			}

			var options = new MvxLocationOptions
			{
				MovementThresholdInM = 10
			};

			locationWatcher.Start(options, 
				async location =>
				{
					locationWatcher.Stop();

					InvokeOnMainThread(() =>
					{
						WeatherData = "Achando o clima...";
					});
					
					var weatherData = await ServicoClima.GetWeather(
						location.Coordinates.Latitude, 
						location.Coordinates.Longitude);
					InvokeOnMainThread(() =>
					{
						WeatherData = weatherData.weather[0].main;
						Debug.WriteLine(WeatherData);
					});
				}, error =>
				{
					Debug.WriteLine(error.Code);
				});
		}
	}
}
