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
using CabanasRD.UI.Info.Views;
using CabanasRD.UI.Info.ViewModels;
using Refit;
using CabanasRD.Framework.APIs;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

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
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>();

            //Repositories & Data sources
            containerRegistry.Register<MotelsRepository>();
            containerRegistry.Register<IMotelsSource, MotelsSource>();

            //Use cases
            containerRegistry.Register<GetAllMotels>();

            //Refit APIs
            containerRegistry.RegisterInstance(RestService.For<ICabanasAPI>(Configs.AppSettingsConstants.ApiUrl));

            //AutoMapper
            containerRegistry.RegisterInstance(GetMapperConfiguration().CreateMapper());
        }

        private MapperConfiguration GetMapperConfiguration()
        {
            const string imagesExtension = "jpg";
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                //MotelServices
                cfg.CreateMap<Framework.APIs.Models.MotelResponseService, Domain.Motels.MotelService>()
               .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Service))
               .ForMember(dest => dest.Description, source => source.MapFrom(src => src.DescriptionDetail))
               .ForMember(dest => dest.Price, source => source.MapFrom(src => src.Price));

                //Motel
                cfg.CreateMap<Framework.APIs.Models.MotelResponse, Domain.Motels.Motel>()
               .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
               .ForMember(dest => dest.Id, source => source.MapFrom(src => int.Parse(src.Id)))
               .ForMember(dest => dest.Latitude, source => source.MapFrom(src => double.Parse(src.Latitude)))
               .ForMember(dest => dest.Longitude, source => source.MapFrom(src => double.Parse(src.Longitude)))
               .ForMember(dest => dest.Services, source => source.MapFrom(src => src.MotelServices))
               .ForMember(dest => dest.Images, source => source.MapFrom(src => src.Images.Select(i => new Domain.Motels.MotelImage
               {
                   Url = $"{i}.{imagesExtension}"
               })))
               .ForMember(dest => dest.Phones, source => source.MapFrom(src => src.Phones.Select(p => new Domain.Motels.MotelPhone
               {
                   Number = p
               })));


            });
            config.AssertConfigurationIsValid();
            return config;
        }
    }
}