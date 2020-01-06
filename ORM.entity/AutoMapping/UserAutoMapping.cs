using AutoMapper;
using ORM.entity.Models;
using ORM.entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.entity.AutoMapping
{
    public static class UserAutoMapping
    {
        public static MapperConfiguration configMapper;
        public static IMapper iMapper;

        private static void initMapper()
        {
            configMapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserModel, UserViewModel>()
                  .ForMember(dest => dest.id, source => source.MapFrom(a => a.id))
                  .ForMember(dest => dest.name, source => source.MapFrom(a => a.name))
                  .ForMember(dest => dest.email, source => source.MapFrom(a => a.email))
                  .ForMember(dest => dest.password, source => source.MapFrom(a => a.password))
                  .ForMember(dest => dest.nameLowCase, source => source.MapFrom(a => a.name.ToLower()))
                  .ForMember(dest => dest.nameUpCase, source => source.MapFrom(a => a.name.ToUpper())).ReverseMap();
            });
            iMapper = configMapper.CreateMapper();
        }

        public static UserViewModel MappingModelToViewModel(UserModel user)
        {
            initMapper();
            return iMapper.Map<UserModel, UserViewModel>(user);
        }

        public static IEnumerable<UserViewModel> MappingListModelToListViewModel(IEnumerable<UserModel>  LstUser)
        {
            initMapper();
            return iMapper.Map<IEnumerable<UserModel>, IEnumerable<UserViewModel>>(LstUser);
        }

        public static UserModel MappingViewModelToModel(UserViewModel userViewModel)
        {
            initMapper();
            return iMapper.Map<UserViewModel, UserModel>(userViewModel);
        }
    }
}
