using AutoMapper;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); //PhotoUrl için City'nin Photo'larından(dto city) IsMain olanın Url' ini aldık. PhotoUrl kolon ismi modelimizde olmadığı için bu şekilde map ettik.
                });

            CreateMap<City, CityForDetailDto>(); //Map edeceğimiz kolonlar modelimizde olduğu için ekstra işlem yapmamıza gerek yok.
            CreateMap<Photo, PhotoForCreationDto>();
            CreateMap<PhotoForReturnDto, Photo>();  //Photo' yu PhotoForReturnDto' ya map ediyoruz.
        }
    }
}
