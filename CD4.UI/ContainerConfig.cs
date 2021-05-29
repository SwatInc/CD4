using Autofac;
using AutoMapper;
using CD4.Entensibility.ReportingFramework;
using CD4.UI.Helpers;
using CD4.UI.Library.Helpers;
using CD4.UI.Library.Model;
using System.Linq;
using System.Reflection;

namespace CD4.UI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            #region Automapper

            builder.Register(context => new MapperConfiguration(config =>
            {
                config.CreateMap<DataLibrary.Models.CountryModel, Library.Model.CountryModel>();
                config.CreateMap<DataLibrary.Models.SitesModel, Library.Model.SitesModel>();
                config.CreateMap<DataLibrary.Models.GenderModel, Library.Model.GenderModel>();
                config.CreateMap<DataLibrary.Models.AtollIslandModel, Library.Model.AtollIslandModel>();
                config.CreateMap<DataLibrary.Models.ClinicalDetailsModel, Library.Model.ClinicalDetailsOrderEntryModel>();
                config.CreateMap<DataLibrary.Models.TestsModel, Library.Model.TestModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.ProfilesAndTestModelOeModel, Library.Model.ProfilesAndTestsDatasourceOeModel>();
                config.CreateMap<DataLibrary.Models.PatientModel, Library.Model.PatientModel>();
                config.CreateMap<DataLibrary.Models.ClinicalDetailsSelectionModel, Library.Model.ClinicalDetailsOrderEntryModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.WorklistPatientDataModel, Library.Model.RequestSampleModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.WorkListResultsModel, Library.Model.ResultModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.AuthorizeDetailModel, Library.Model.AuthorizeDetailEventArgs>();
                config.CreateMap<DataLibrary.Models.StatusModel, Library.Model.StatusModel>();
                config.CreateMap<DataLibrary.Models.WorkstationPrintersInfoModel, Library.Model.WorkStationPrintersInfoModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.AuditTrailModel, Library.Model.AuditTrailModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.CodifiedResultsModel, Library.Model.CodifiedResultsModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.CodifiedResultsModel, Library.Model.CodifiedResultsModel>();
                config.CreateMap<DataLibrary.Models.CommentsSelectionModel, Library.Model.CommentsSelectionModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.BarcodeDataModel, Library.Model.BarcodeDataModel>();
                config.CreateMap<DataLibrary.Models.ResultAlertModel, Library.Model.ResultAlertModel>();
                config.CreateMap<DataLibrary.Models.SampleNotesModel, Library.Model.SampleNotesModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.PatientUpdateDatabaseModel, Library.Model.PatientUpdateModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.ScientistModel, Library.Model.ScientistModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.NdaTrackingModel, Library.Model.NdaTrackingModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.CinAndReportDateModel, Library.Model.CinAndReportDateModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.CinAndFullnameModel, Library.Model.CinAndFullnameModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.GlobalSettingsModel, Library.Model.GlobalSettingsModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.DisciplineModel, Library.Model.DisciplineModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.ResultDataTypeModel, Library.Model.ResultDataTypeModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.SampleTypeModel, Library.Model.SampleTypeModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.UnitModel, Library.Model.UnitModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.TestsInsertModel, Library.Model.TestsInsertModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.TestUpdateModel, Library.Model.TestUpdateModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.ResultCommentModel, Library.Model.ResultCommentModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.HmsLinkDataModel, Library.Model.HmsLinkDataModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.BillingTestMappingModel, Library.Model.BillingTestMappingModel>().ReverseMap();
                config.CreateMap<DataLibrary.Models.AnalysisRequestDataModel, Library.Model.AnalysisRequestDataModel>().ReverseMap();
                config.CreateMap<ResultModel, TestModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Test))
                    .ForMember(dest => dest.Mask, opt => opt.MapFrom(src => src.Mask))
                    .ForMember(dest => dest.ResultDataType, opt => opt.MapFrom(src => src.DataType));

                config.CreateMap<DataLibrary.Models.AnalysisRequestDataModel, Library.ViewModel.OrderEntryViewModel>()
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
                .Where(t => t.Namespace != null)
                .Where(t => t.Namespace.Contains("ViewModel"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"));

            //Register Data Access Library interfaces
            builder.RegisterAssemblyTypes(Assembly.Load("CD4.DataLibrary"))
                .Where(t => t.Namespace.Contains("DataAccess"))
                .Where(t => t.FullName.Contains("Base") != true)
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"));

            //register auth event args
            builder.RegisterType<AuthorizeDetailEventArgs>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<LoadMultipleExtensions>().As<ILoadMultipleExtensions>().SingleInstance();

            builder.RegisterType<UserAuthEvaluator>().As<IUserAuthEvaluator>();
            builder.RegisterType<PrintingHelper>().As<IPrintingHelper>();
            builder.RegisterType<NamesAbbreviator>().As<INamesAbbreviator>();
            builder.RegisterType<BarcodeHelper>().As<IBarcodeHelper>();
            builder.RegisterType<CommentHelper>().As<ICommentHelper>();

            builder.RegisterType<GlobalSettingsHelper>().As<IGlobalSettingsHelper>().SingleInstance();

            return builder.Build();

        }
    }
}
