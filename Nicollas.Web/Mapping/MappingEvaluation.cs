// <copyright file="MappingEvaluation.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng
{
    using AutoMapper;
    using Nicollas.Core.Entities;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.Dto;
    using Nicollas.Dto.Identity;
    using Nicollas.Ng.Extensions;

    /// <summary>
    /// The mapping profile. Map all DTOs
    /// </summary>
    public class MappingEvaluation : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingEvaluation"/> class.
        /// </summary>
        public MappingEvaluation()
        {
            this.CreateMap<EvaluationDto, Evaluation>()
                .ForMember(entity => entity.Id, opt => opt.MapFrom(dto => dto.SubmittedAnswerId))
                .ForMember(entity => entity.ApliedAt, opt => opt.MapFrom(dto => dto.SubmitDateTime))
                .ForMember(entity => entity.IsCorrect, opt => opt.MapFrom(dto => dto.Correct))
                .ForMember(entity => entity.Difficulty, opt => opt.MapFrom(dto => this.CustomMap(dto.Difficulty)))
                .ForMember(entity => entity.Subject, opt => opt.MapFrom(dto => new Subject { Description = dto.Subject }))
                .ForMember(entity => entity.Domain, opt => opt.MapFrom(dto => new Domain { Description = dto.Domain }))
                .ReverseMap()
                .ForMember(dto => dto.Difficulty, opt => opt.MapFrom(entity => entity.Difficulty.ToString(System.Globalization.CultureInfo.GetCultureInfo("EN-US"))))
                .ForMember(dto => dto.Subject, opt => opt.MapFrom(entity => entity.Subject.Description))
                .ForMember(dto => dto.Domain, opt => opt.MapFrom(entity => entity.Domain.Description));
        }

        private float CustomMap(string floatValue)
        {
            if (!float.TryParse(floatValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.GetCultureInfo("EN-US"), out var result))
            {
                return 0;
            }

            return result;
        }
    }
}
