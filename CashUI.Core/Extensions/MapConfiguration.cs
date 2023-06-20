using AutoMapper;
using Cash.Core.Models;
using Cash.Dto.Dtos.UserDto;

namespace CashUI.Core.Extensions
{
    public class MapConfiguration : Profile
    {
        // Map Configuration

        public MapConfiguration()
        {
            // Mapping Transactions 

            CreateMap<UserListDto, User>().ReverseMap();
            CreateMap<UserEditDto, User>().ReverseMap();
        }
    }
}
