using System;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CabanasRD.Framework.DataSources;
using CabanasRD.UI.Map.Views;
using CabanasRD.UI.Map.ViewModels;
using CabanasRD.Data.Motels;
using CabanasRD.UseCases.Motels;
using CabanasRD.UI.Main.Views;
using CabanasRD.UI.Main.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CabanasRD
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainTabbedPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Views
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainTabbedPage, MainTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MotelsMapPage, MotelsMapPageViewModel>();
            containerRegistry.RegisterForNavigation<MotelDetailsPage, MotelDetailsPageViewModel>();

            //Repositories & Data sources
            containerRegistry.Register<MotelsRepository>();
            containerRegistry.Register<IMotelsSource, InMemoryMotelsSource>();

            //Use cases
            containerRegistry.Register<GetAllMotels>();
        }
    }
}