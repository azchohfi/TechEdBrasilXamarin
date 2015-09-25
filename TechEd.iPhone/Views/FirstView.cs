using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using TechEd.Core.ViewModels;

namespace TechEd.iPhone.Views
{
	partial class FirstView : MvxViewController
	{
		public FirstView (IntPtr handle) 
			: base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<FirstView, FirstViewModel>();
			set.Bind(label).To(vm => vm.WeatherData);
			set.Bind(pegarClima).To(vm => vm.PegarClimaCommand);
			set.Apply();
		}
	}
}
