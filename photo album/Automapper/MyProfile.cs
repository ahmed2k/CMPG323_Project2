using AutoMapper;
using photo_album.Models;
using photo_album.ViewModels.albumsViewModel;
using photo_album.ViewModels.imageViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_album.Automapper
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Album, albumsViewModel>().ReverseMap();
            CreateMap<Album, editAlbumViewModel>().ReverseMap();
            CreateMap<Album, createAlbumViewModel>().ReverseMap();

            CreateMap<images, imageEditViewModel>().ReverseMap();
            //    CreateMap<images, createImageViewModel>.ReverseMap();
            CreateMap<images, imageViewModel>()
                .ForMember(dest => dest.albumTitle, opt => opt.MapFrom(src => src.album.Media));

        }

    }
}
