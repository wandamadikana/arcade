using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wanda.Games.TicTacToe.Utility
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Model.ViewModel.Game, Model.DTO.Game>()
                .ForMember(s => s.Move, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Model.ViewModel.Move, Model.DTO.Move>()
                .ForMember(s => s.Game, opt => opt.Ignore())
                .ForMember(s => s.Player, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Model.ViewModel.Player, Model.DTO.Player>()
                .ForMember(s => s.Move, opt => opt.Ignore())
                .ForMember(s => s.PlayerDescription, opt => opt.Ignore())
                .ForMember(s => s.LastUpdated, opt => opt.Ignore())
                .ForMember(s => s.DateCreated, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
