using AutoMapper;
using SnappetTest.Service.Infrastructure.Abstract;
using SnappetTest.Model.Implementations;
using System;

namespace SnappetTest.Service.ViewModels.Mappings
{
    public static class DomainToViewMappings
    {
        public static IMapperConfigurationExpression ConfigureSubmiitedAnswerMapping(this IMapperConfigurationExpression configureThis )
        {
            var startime = new DateTime(2015, 3, 23, 0, 0, 0);
            var endtime = new DateTime(2015, 3, 24, 11, 30, 0);

            var timerange = new TimeStamp(startime, endtime);

            configureThis.CreateMap<IFetchAnswerCountProvider, SnappetViewModel>()
                .ForMember(x => x.AnswersCount, o => o.MapFrom(p => p.FetchAnswerCount(timerange)));

            configureThis.CreateMap<IFetchCorrectAnswerCountProvider, SnappetViewModel>()
                .ForMember(x => x.CorrectAnswersCount, o => o.MapFrom(p => p.FetchCorrectAnswerCount(timerange)));

            configureThis.CreateMap<IFetchProgressProvider, SnappetViewModel>()
                .ForMember(x => x.ProgessCount, o => o.MapFrom(p => p.FetchProgress(timerange)));

            configureThis.CreateMap<IFetchRequestedDateProvider, SnappetViewModel>()
                .ForMember(x => x.DateRequested, o => o.MapFrom(p => p.RequestedDate(endtime)));
            
            configureThis.CreateMap<IFetchSubjectProvider, SnappetViewModel>()
                .ForMember(x => x.Subject, o => o.MapFrom(p => p.FetchSubject(timerange)));

            return configureThis;
                
        }
    }
}
