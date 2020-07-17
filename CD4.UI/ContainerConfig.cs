using Autofac;
using AutoMapper;
using CD4.UI.Library.ViewModel;
using CD4.UI.View;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            #region Automapper

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataLibrary.Models.CountryModel, Library.Model.CountryModel>();
                cfg.CreateMap<DataLibrary.Models.SitesModel, Library.Model.SitesModel>();
                cfg.CreateMap<DataLibrary.Models.GenderModel, Library.Model.GenderModel>();
                cfg.CreateMap<DataLibrary.Models.AtollIslandModel, Library.Model.AtollIslandModel>();
                cfg.CreateMap<DataLibrary.Models.ClinicalDetailsModel, Library.Model.ClinicalDetailsOrderEntryModel>();
                cfg.CreateMap<DataLibrary.Models.TestsModel, Library.Model.TestModel>().ReverseMap();
                cfg.CreateMap<DataLibrary.Models.ProfilesAndTestModelOeModel, Library.Model.ProfilesAndTestsDatasourceOeModel>();
                cfg.CreateMap<DataLibrary.Models.PatientModel, Library.Model.PatientModel>();
                cfg.CreateMap<DataLibrary.Models.ClinicalDetailsSelectionModel, Library.Model.ClinicalDetailsOrderEntryModel>().ReverseMap();
                cfg.CreateMap<DataLibrary.Models.WorklistPatientDataModel, Library.Model.RequestSampleModel>().ReverseMap();
                cfg.CreateMap<DataLibrary.Models.WorkListResultsModel, Library.Model.ResultModel>().ReverseMap();
                cfg.CreateMap<DataLibrary.Models.AuthorizeDetailModel, Library.Model.AuthorizeDetailEventArgs>();
                cfg.CreateMap<DataLibrary.Models.StatusModel, Library.Model.StatusModel>();
                cfg.CreateMap<DataLibrary.Models.WorkstationPrintersInfo, Library.Model.WorkStationPrintersInfo>().ReverseMap();

                cfg.CreateMap<DataLibrary.Models.AnalysisRequestDataModel, Library.ViewModel.OrderEntryViewModel>()
                .ForMember(dest => dest.SelectedSiteId, opt => opt.MapFrom(src => src.SiteId))
                .ForMember(dest => dest.NidPp, opt => opt.MapFrom(src => src.NationalIdPassport))
                .ForMember(dest => dest.SelectedGenderId, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(dest => dest.SelectedAtoll, opt => opt.MapFrom(src => src.Atoll))
                .ForMember(dest => dest.SelectedIsland, opt => opt.MapFrom(src => src.Island))
                .ForMember(dest => dest.SelectedCountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.AddedTests, opt => opt.MapFrom(src => src.Tests))
                .ReverseMap();

            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            #endregion

            //register application start
            builder.RegisterType<Cd4Application>().As<ICd4Application>();

            builder.RegisterType<AutofacFormFactory>().As<IFormFactory>();

            //Register Views
            builder.RegisterAssemblyTypes(Assembly.Load("CD4.UI"))
                .Where(t => t.Namespace.Contains("UI.View"));

            //register viewModels
            builder.RegisterAssemblyTypes(Assembly.Load("CD4.UI.Library"))
                .Where(t => t.Namespace.Contains("ViewModel"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"));

            //Register Data Access Library interfaces
            builder.RegisterAssemblyTypes(Assembly.Load("CD4.DataLibrary"))
                .Where(t => t.Namespace.Contains("DataAccess"))
                .Where(t => t.FullName.Contains("Base") != true )
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"));

            return builder.Build();
        }
    }
}
